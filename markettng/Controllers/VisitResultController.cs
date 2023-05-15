using AutoMapper;
using Base.Models.Dto;
using Base.Models.Entity;
using markettng.Controllers.Base;
using markettng.Filter;
using markettng.Services;
using markettng.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace markettingApp.Controllers
{
    [Authorize]
    public class VisitResultController : BaseApiController
    {
        private readonly IMapper _mapper;

        public VisitResultController(IMapper mapper)
        {
            _mapper = mapper;
        }
       
        public async Task<IActionResult> Index(string? id)
        {
            if (id!=null)
            {
                TempData.SetTemp<int>("FacilityId",int.Parse( ServiceManager.SecurityDataProtector.Decode(id)));
            }

            var res = await RepositoryManager.VisitResultRepository.GetAll();
                if (res.Status.Succeeded)
            {
                CommonVm<VisitResultDto> commonVm = new CommonVm<VisitResultDto>();

                var map = _mapper.Map<IEnumerable<VisitResultDto>>(res.Data);
              

                commonVm.obj = new VisitResultDto();
                commonVm.data = map;
                return PartialView("Index", commonVm);
            }
            return BadRequest(res.Status.message);
        }
        [CurrentUserFiltterAttrubite()]
        public async Task<IActionResult> Add(VisitResultDto visitResultDto)
        {

            try
            {
           
                if (visitResultDto == null) return BadRequest("empty facilatyDto");
                
                VisitResult entity = _mapper.Map<VisitResult>(visitResultDto);

                var res = await RepositoryManager.VisitResultRepository.AddAndReturn(entity);


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
            if (string.IsNullOrWhiteSpace(id))
            {
                var res = await RepositoryManager.VisitResultRepository.GetById(int.Parse(ServiceManager.SecurityDataProtector.Decode(id)));
                if (res.Status.Succeeded)
                {
                    var map = _mapper.Map<VisitResultDto>(res.Data);
                    CommonVm<VisitResultDto> commonVm = new CommonVm<VisitResultDto>();
                    commonVm.obj=new VisitResultDto();
                    commonVm.obj = _mapper.Map(map, commonVm.obj);

                    return PartialView("_Edit", commonVm);
                }
                return BadRequest(res.Status.message);

            }
            return BadRequest("Sorry! this data not exsit");
        }
        //[HttpPost]
        [CurrentUserFiltterAttrubite()]
        public async Task<IActionResult> Edit(VisitResultDto visitResultDto)
        {

            try
            {
                if (visitResultDto == null) return BadRequest("empty facilatyDto");
               
                VisitResult entity = _mapper.Map<VisitResult>(visitResultDto);

                var res = await RepositoryManager.VisitResultRepository.Update(entity);
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
                var res = await RepositoryManager.VisitResultRepository.GetById(int.Parse(ServiceManager.SecurityDataProtector.Decode(id)));
                if (res.Status.Succeeded)
                {
                    var deletedres = await RepositoryManager.VisitResultRepository.Remove(res.Data);
                  

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
