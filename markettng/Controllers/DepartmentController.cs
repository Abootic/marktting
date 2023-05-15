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
using System.Data;

namespace markettng.Controllers
{

    [Authorize(Roles = "admin,manager")]
    public class DepartmentController : BaseApiController
    {

        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;

        public DepartmentController(IMapper mapper, IHttpContextAccessor contextAccessor)
        {
            _mapper = mapper;
            _contextAccessor = contextAccessor;

        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var res = await RepositoryManager.departmentRepository.GetAll();



            if (res.Status.Succeeded)
            {
                CommonVm<DepartmentDto> commonVm = new CommonVm<DepartmentDto>();

                var map = _mapper.Map<IEnumerable<DepartmentDto>>(res.Data);
                //foreach (var facility in res.Data) {
                //    var channelres = await RepositoryManager.communicationChannelRepository.Find(a => a.FacilityId ==facility.Id);



                commonVm.obj = new DepartmentDto();



                commonVm.data = map;
                return PartialView("Index", commonVm);
            }
            return BadRequest(res.Status.message);
        }

        [CurrentUserFiltterAttrubite()]
        public async Task<IActionResult> Add(DepartmentDto departmentDto)
        {

            try
            {
              
                if (departmentDto == null) return BadRequest("empty DepartmentDto");

                Department entity = _mapper.Map<Department>(departmentDto);

                var res = await RepositoryManager.departmentRepository.Add(entity);


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
                    var res = await RepositoryManager.departmentRepository.GetById(int.Parse(ServiceManager.SecurityDataProtector.Decode(id)));
                    if (res.Status.Succeeded)
                    {
                        var map = _mapper.Map<DepartmentDto>(res.Data);

                        CommonVm<DepartmentDto> commonVm = new CommonVm<DepartmentDto>();
                     
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
            }catch (Exception ex)
            {

                string exMsg = ex.InnerException == null ? ex.Message : ex.InnerException.Message;

                return BadRequest(exMsg);
            }
        }
        //[HttpPost]
        [CurrentUserFiltterAttrubite()]
        public async Task<IActionResult> Edit(DepartmentDto departmentDto)
        {
          

            try
            {
                if (departmentDto == null) return BadRequest("empty departmentDto");
                

                Department entity = _mapper.Map<Department>(departmentDto);

                var res = await RepositoryManager.departmentRepository.Update(entity);
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
                var res = await RepositoryManager.departmentRepository.GetById(int.Parse(ServiceManager.SecurityDataProtector.Decode(id)));
                if (res.Status.Succeeded)
                {
                    var deletedres = await RepositoryManager.departmentRepository.Remove(res.Data);
                    await RepositoryManager.UnitOfWork.CompleteAsync();

                    if (deletedres.Status.Succeeded)
                    {
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
