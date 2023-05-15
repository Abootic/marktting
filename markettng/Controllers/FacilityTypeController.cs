using AutoMapper;
using Base.Models.Dto;
using Base.Models.Entity;
using markettng.Controllers.Base;
using markettng.Filter;
using markettng.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace markettng.Controllers
{
    [Authorize]
    public class FacilityTypeController : BaseApiController
    {
        private readonly IMapper _mapper;

        public FacilityTypeController(IMapper mapper)
        {
            _mapper = mapper;
         

        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var res = await RepositoryManager.FacilityTypeRepository.GetAll();



            if (res.Status.Succeeded)
            {
                CommonVm<FacilityTypeDto> commonVm = new CommonVm<FacilityTypeDto>();

                var map = _mapper.Map<IEnumerable<FacilityTypeDto>>(res.Data);
                //foreach (var facility in res.Data) {
                //    var channelres = await RepositoryManager.communicationChannelRepository.Find(a => a.FacilityId ==facility.Id);



                commonVm.obj = new FacilityTypeDto();



                commonVm.data = map;
                return PartialView("Index", commonVm);
            }
            return BadRequest(res.Status.message);
        }

        [CurrentUserFiltterAttrubite()]
        public async Task<IActionResult> Add(FacilityTypeDto facilityTypeDto)
        {

            try
            {

                if (facilityTypeDto == null) return BadRequest("empty DepartmentDto");

                FacilityType entity = _mapper.Map<FacilityType>(facilityTypeDto);

                var res = await RepositoryManager.FacilityTypeRepository.Add(entity);


                if (res.Status.Succeeded)
                {
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

        public async Task<IActionResult> GetEdit(string id)
        {
            try
            {

                if (!string.IsNullOrWhiteSpace(id))
                {
                    var res = await RepositoryManager.FacilityTypeRepository.GetById(int.Parse(ServiceManager.SecurityDataProtector.Decode(id)));
                    if (res.Status.Succeeded)
                    {
                        var map = _mapper.Map<FacilityTypeDto>(res.Data);

                        CommonVm<FacilityTypeDto> commonVm = new CommonVm<FacilityTypeDto>();

                        commonVm.obj = map;
                        //commonVm.obj = new DepartmentDto()
                        //{
                        //    Id = map.Id,
                        //    Name = map.Name,
                        //    other = map.other,
                        //    State = map.State,


                        //};

                        return PartialView("_Edit", commonVm);
                    }
                    return BadRequest(res.Status.message);

                }
                return BadRequest("Sorry! this data not exsit");
            }
            catch (Exception ex)
            {

                string exMsg = ex.InnerException == null ? ex.Message : ex.InnerException.Message;

                return BadRequest(exMsg);
            }
        }
        //[HttpPost]
        [CurrentUserFiltterAttrubite()]
        public async Task<IActionResult> Edit(FacilityTypeDto facilityTypeDto)
        {


            try
            {
                if (facilityTypeDto == null) return BadRequest("empty departmentDto");


                FacilityType entity = _mapper.Map<FacilityType>(facilityTypeDto);

                var res = await RepositoryManager.FacilityTypeRepository.Update(entity);
                await RepositoryManager.UnitOfWork.CompleteAsync();

                if (res.Status.Succeeded) return Ok(res.Status.message);

                return BadRequest(res.Status.message);
            }
            catch (Exception ex)
            {

                string exMsg = ex.InnerException == null ? ex.Message : ex.InnerException.Message;

                return BadRequest(exMsg);
            }
        }
        [CurrentUserFiltterAttrubite()]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return BadRequest("null value");
            try
            {
                var res = await RepositoryManager.FacilityTypeRepository.GetById(int.Parse(ServiceManager.SecurityDataProtector.Decode(id)));
                if (res.Status.Succeeded)
                {
                    var deletedres = await RepositoryManager.FacilityTypeRepository.Remove(res.Data);
                    

                    if (deletedres.Status.Succeeded)
                    {
                        await RepositoryManager.UnitOfWork.CompleteAsync();
                        return Ok(deletedres.Status.message);
                    }
                    return BadRequest(deletedres.Status.message);
                }
                return BadRequest(res.Status.message);
            }
            catch (Exception ex)
            {
                string exMsg = ex.InnerException == null ? ex.Message : ex.InnerException.Message;

                return BadRequest(exMsg);
            }

        }
    }
}
