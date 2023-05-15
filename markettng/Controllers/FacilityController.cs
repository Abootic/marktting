
using markettng.Controllers.Base;

using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Base.Models.Dto;
using markettng.ViewModel;
using Base.Models.Entity;
using System.Security.Claims;
using markettng.Filter;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using Microsoft.AspNetCore.Mvc.Filters;
using markettng.Services;
using Microsoft.AspNetCore.Authorization;
using Base.Repositories.Implementations;
using Base.Common.Interface;

namespace markettingApp.Controllers
{
    [Authorize]
    public class FacilityController : BaseApiController
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;
      
        public FacilityController(IMapper mapper, IHttpContextAccessor contextAccessor)
        {
            _mapper = mapper;
            _contextAccessor = contextAccessor;
         
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                FacilityVm facilityVm = new FacilityVm();
                facilityVm.obj = new FacilityDto();
                facilityVm.obj.VisitDto = new VisitDto();
                facilityVm.obj.communicationChannelDto = new CommunicationChannelDto();
                facilityVm.obj.visitResultDto = new VisitResultDto();
                facilityVm.obj.FacilityTypeDto = new FacilityTypeDto();
                var uId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                string userId = "";
                if (uId != null)
                {
                    userId = uId;

                }
              
               // string userId = TempData.GetTempSave<string>("userId");
                var res = await RepositoryManager.facilityRepository.Find(a => a.UserId == userId);



                facilityVm.facilityDatas = new List<FacilityData>();



                if (res.Status.Succeeded)
                {

                    foreach (var facility in res.Data)
                    {
                        var channel = await RepositoryManager.communicationChannelRepository.Find(a => a.FacilityId == facility.Id);
                        var vist = await RepositoryManager.VisitRepository.Find(a => a.FacilityId == facility.Id);
                        var vistResuilt = await RepositoryManager.VisitResultRepository.Find(a => a.FacilityId == facility.Id);
                        var ftype = await RepositoryManager.FacilityTypeRepository.Find(a => a.Id == facility.FacilityTypeId);
                        facilityVm.facilityDatas.Add(new FacilityData()
                        {
                            Address = facility.Address,
                            FacilityActivity = facility.FacilityActivity,
                            FacilityType = ftype.Data.First().Name,
                            SpecialistAdjective = facility.SpecialistAdjective,
                            SpecialistName = facility.SpecialistName,
                            TradeName = facility.TradeName,
                            Id = facility.Id,
                            OwnerName = facility.other,
                            FPhoneNumber = channel.Data.Where(a => a.FacilityId == facility.Id).First().PhoneNumber,
                            Code = vistResuilt.Data.First(a => a.FacilityId == facility.Id).Code,
                            Message = vistResuilt.Data.First(a => a.FacilityId == facility.Id).Message,
                            ResultType = vistResuilt.Data.First(a => a.FacilityId == facility.Id).ResultType,
                            Note = vistResuilt.Data.First(a => a.FacilityId == facility.Id).Note,
                            OPhoneNumber = channel.Data.First(a => a.FacilityId == facility.Id).other,
                            Link = channel.Data.First(a => facility.Id == facility.Id).Link,
                            Reason = vist.Data.First(a => a.FacilityId == facility.Id).Reason,

                            VisitTime = vist.Data.First(a => a.FacilityId == facility.Id).VisitTime,

                        });







                    }



                    return PartialView("Index", facilityVm);
                }
                return PartialView("Index", facilityVm);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [CurrentUserFiltterAttrubite()]
        public async Task<IActionResult> Add(FacilityDto facilityDto)
        {

            try
            {
                bool sucess = false;
                if (facilityDto == null) return BadRequest("empty facilatyDto");
              

                var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (userId != null)
                {
                    facilityDto.UserId = userId;


                }

                Facility entity = _mapper.Map<Facility>(facilityDto);

                var res = await RepositoryManager.facilityRepository.AddAndReturn(entity);
            

                if (res.Status.Succeeded)
                {
                  await RepositoryManager.UnitOfWork.CompleteAsync();
                   
                 
                    CommunicationChannelDto channelDto = new CommunicationChannelDto()
                    {
                        FacilityId = res.Data.Id,
                        PhoneNumber = facilityDto.communicationChannelDto.PhoneNumber,
                        Link = facilityDto.communicationChannelDto.Link,
                        other = facilityDto.communicationChannelDto.other

                    };
                    var channelEntity=_mapper.Map<CommunicationChannel>(channelDto);
                    var channel = await RepositoryManager.communicationChannelRepository.Add(channelEntity);
                   

                    VisitDto visitDto = new VisitDto()
                    {
                        FacilityId = res.Data.Id,
                        Reason = facilityDto.VisitDto.Reason,
                        VisitTime = DateTime.Now
                };
                    
                   var  visitDtoMap = _mapper.Map<Visit>(visitDto);
                var visitRes = await RepositoryManager.VisitRepository.Add(visitDtoMap);
                    VisitResultDto visitResultDto = new VisitResultDto()
                    {
                        FacilityId = res.Data.Id,
                        Message = facilityDto.visitResultDto.Message,
                        Code=facilityDto.visitResultDto.Code,
                        ResultType=facilityDto.visitResultDto.ResultType,
                     other=facilityDto.visitResultDto.other,
                     Note=facilityDto.visitResultDto.Note,
                       
                    };
                    VisitResult visitResult = _mapper.Map<VisitResult>(visitResultDto);

                    var visitResultRes = await RepositoryManager.VisitResultRepository.Add(visitResult);
                    await RepositoryManager.UnitOfWork.CompleteAsync();
                    return Ok(res.Status.message);
                }

                return BadRequest(res.Status.message);
            }
            catch (Exception ex)
            {
                string exMsg= ex.InnerException==null?ex.Message:ex.InnerException.Message;

                return BadRequest(exMsg);
            }
        }

        public async Task<IActionResult> GetEdit(string id)
        {
          
            if (!string.IsNullOrWhiteSpace(id))
            {
                var res = await RepositoryManager.facilityRepository.GetById(int.Parse(ServiceManager.SecurityDataProtector.Decode(id)));
                if (res.Status.Succeeded)
                {
                    var map = _mapper.Map<FacilityDto>(res.Data);
                    FacilityVm facilityVm = new FacilityVm();
                  
                    var vistResuilt =await RepositoryManager.VisitResultRepository.Find(a => a.FacilityId == res.Data.Id);
                    
                    VisitResultDto vistResuiltDto = new VisitResultDto
                    {
                        Id= vistResuilt.Data.First().Id,
                        FacilityId = res.Data.Id,
                        Message = vistResuilt.Data.First().Message,
                        Note=vistResuilt.Data.First().Note,
                        other=vistResuilt.Data.First().other,
                        ResultType=vistResuilt.Data.First().ResultType,
                        Code = vistResuilt.Data.First().Code,
                        
                        
                    };
                    var vist=await RepositoryManager.VisitRepository.Find(a=>a.FacilityId==res.Data.Id);
                    VisitDto visitDto = new VisitDto
                    {
                        Id = vist.Data.First().Id,
                        FacilityId = vist.Data.First().FacilityId,
                        other = vist.Data.First().other,
                        Reason = vist.Data.First().Reason,
                        VisitTime = vist.Data.First().VisitTime,

                    };
                    var fType=await RepositoryManager.FacilityTypeRepository.Find(a=>a.Id==res.Data.FacilityTypeId);
                    FacilityTypeDto facilityTypeDto = new FacilityTypeDto
                    {
                        Id= fType.Data.First().Id,
                        Name= fType.Data.First().Name,
                        other = fType.Data.First().other,

                    };
                    var channel = await RepositoryManager.communicationChannelRepository.Find(a => a.FacilityId == res.Data.Id);
                    CommunicationChannelDto communicationChannelDto = new CommunicationChannelDto
                    {
                        Id = channel.Data.First().Id,
                        FacilityId = channel.Data.First().FacilityId,
                        ChannelType = channel.Data.First().ChannelType,
                        Link = channel.Data.First().Link,
                        other = channel.Data.First().other,
                        PhoneNumber = channel.Data.First().PhoneNumber,
                        
                    };
                    facilityVm.obj = new FacilityDto()
                    {
                        Id = map.Id,
                        Address = map.Address,
                        FacilityActivity = map.FacilityActivity,
                        // FacilityType = map.FacilityType,
                        FacilityTypeId=map.FacilityTypeId,
                    //    Importance = map.Importance,
                        other = map.other,
                        SpecialistAdjective = map.SpecialistAdjective,
                        SpecialistName = map.SpecialistName,
                        TradeName = map.TradeName,
                        UserId = map.UserId,
                        communicationChannelDto = communicationChannelDto,
                        VisitDto = visitDto,
                        visitResultDto = vistResuiltDto,
                        FacilityTypeDto=facilityTypeDto,
                        
                        


                    };
                    return PartialView("_Edit", facilityVm);
                }
                return BadRequest(res.Status.message);

            }
            return BadRequest("Sorry! this data not exsit");
        }
        //[HttpPost]
        [CurrentUserFiltterAttrubite()]
        public async Task<IActionResult> Edit(FacilityDto facilityEdit)
        {
            try
            {
               
                if (facilityEdit == null) return BadRequest("empty facilatyDto");
                
                var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (userId != null)
                {
                    facilityEdit.UserId = userId;

                  
                } 
              
                Facility entity = _mapper.Map<Facility>(facilityEdit);

                var res = await RepositoryManager.facilityRepository.Update(entity);


                if (res.Status.Succeeded)
                {
                    await RepositoryManager.UnitOfWork.CompleteAsync();

                    
                    CommunicationChannelDto channelDto = new CommunicationChannelDto()
                    {
                        Id = facilityEdit.communicationChannelDto.Id,
                        FacilityId=res.Data.Id,
                        PhoneNumber = facilityEdit.communicationChannelDto.PhoneNumber,
                        Link = facilityEdit.communicationChannelDto.Link,
                        other = facilityEdit.communicationChannelDto.other

                    };
                    var channelEntity = _mapper.Map<CommunicationChannel>(channelDto);
                    var channel = await RepositoryManager.communicationChannelRepository.Update(channelEntity);
                   

                    VisitDto visitDto = new VisitDto()
                    {
                        Id = facilityEdit.VisitDto.Id,
                        FacilityId = res.Data.Id,
                        Reason = facilityEdit.VisitDto.Reason,
                        VisitTime = facilityEdit.VisitDto.VisitTime
                    };

                    var visitDtoMap = _mapper.Map<Visit>(visitDto);
                    var visitRes = await RepositoryManager.VisitRepository.Update(visitDtoMap);
                    VisitResultDto visitResultDto = new VisitResultDto()
                    {
                        FacilityId = res.Data.Id,
                        Message = facilityEdit.visitResultDto.Message,
                        Code = facilityEdit.visitResultDto.Code,
                        ResultType = facilityEdit.visitResultDto.ResultType,
                        other = facilityEdit.visitResultDto.other,
                        Id = facilityEdit.visitResultDto.Id,
                        Note = facilityEdit.visitResultDto.Note,

                    };
                    VisitResult visitResult = _mapper.Map<VisitResult>(visitResultDto);

                    var visitResultRes = await RepositoryManager.VisitResultRepository.Update(visitResult);
                    await RepositoryManager.UnitOfWork.CompleteAsync();
                    return Ok(res.Status.message);
                }

                return BadRequest(res.Status.message);
            }
            catch (Exception ex)
            {
                string exMsg = ex.InnerException == null ? ex.Message : ex.InnerException.Message;

                return BadRequest(exMsg);
            }
        }
        [CurrentUserFiltterAttrubite()]
        public async Task<IActionResult>Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return BadRequest("null value");
            try
            {
                var res = await RepositoryManager.facilityRepository.GetById(int.Parse(ServiceManager.SecurityDataProtector.Decode(id)));
                if (res.Status.Succeeded)
                {
                    var channel = await RepositoryManager.communicationChannelRepository.Find(a => a.FacilityId ==res.Data.Id );
                    await RepositoryManager.communicationChannelRepository.Remove(channel.Data.First());
                    var visitReuilt = await RepositoryManager.VisitResultRepository.Find(a => a.FacilityId == res.Data.Id);
                    await RepositoryManager.VisitResultRepository.Remove(visitReuilt.Data.First());
                    var visit = await RepositoryManager.VisitRepository.Find(a => a.FacilityId == res.Data.Id);
                    await RepositoryManager.VisitRepository.Remove(visit.Data.First());
                    //await RepositoryManager.UnitOfWork.CompleteAsync();
                    var deletedres = await RepositoryManager.facilityRepository.Remove(res.Data);
                    await RepositoryManager.UnitOfWork.CompleteAsync();

                    if (deletedres.Status.Succeeded)
                    {
                      
                        return Ok(deletedres.Status.message);
                    }
                   

                    return BadRequest(deletedres.Status.message);
                }
                return BadRequest(res.Status.message);
            }catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }

        }
    }
}
