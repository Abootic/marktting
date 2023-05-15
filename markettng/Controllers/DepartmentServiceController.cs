using AutoMapper;
using Base.Models.Dto;
using Base.Models.Entity;
using markettng.Controllers.Base;
using markettng.Filter;
using markettng.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace markettng.Controllers
{
    [Authorize(Roles = "admin,manager")]
    public class DepartmentServiceController : BaseApiController
    {

        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;

        public DepartmentServiceController(IMapper mapper, IHttpContextAccessor contextAccessor)
        {
            _mapper = mapper;
            _contextAccessor = contextAccessor;

        }
        [HttpGet]
        public async Task<IActionResult> Index(string id)
        {
            TempData["deptId"]=id;
            //if (string.IsNullOrWhiteSpace(id))
            //{

            //    var res = await RepositoryManager.departmentServiceRepository.GetAll();
            //    if (res.Status.Succeeded)
            //    {
            //        CommonVm<DepartmentDto> commonVm = new CommonVm<DepartmentDto>();
            //        var map = _mapper.Map<IEnumerable<DepartmentDto>>(res.Data);
            //        commonVm.obj = new DepartmentDto();
            //        commonVm.data = map;
            //        return PartialView("Index", commonVm);
            //    }
            //    return BadRequest(res.Status.message);
            //}
            //else
            //{

                var dept=await RepositoryManager.departmentRepository.GetById(int.Parse(ServiceManager.SecurityDataProtector.Decode(id)));
                if(dept.Status.Succeeded)
                {
                    TempData["deptName"] = dept.Data.Name;
                }
                var Deptres = await RepositoryManager.departmentServiceRepository.Find(d=>d.DepartmentId==int.Parse(ServiceManager.SecurityDataProtector.Decode(id)));

                if (Deptres.Status.Succeeded)
                {
                    CommonVm<DepartmentServiceDto> commonVm = new CommonVm<DepartmentServiceDto>();
                    var map = _mapper.Map<IEnumerable<DepartmentServiceDto>>(Deptres.Data);
                    commonVm.obj = new DepartmentServiceDto();
                    commonVm.obj.DepartmentId = int.Parse(ServiceManager.SecurityDataProtector.Decode(id));
                    commonVm.data = map;
                    return PartialView("Index", commonVm);
                }
                return BadRequest(Deptres.Status.message);
         //   }
        }

        [HttpPost]
        [CurrentUserFiltterAttrubite()]

        public async Task<IActionResult> Add(DepartmentServiceDto departmentServiceDto)
        {

            try
            {

                if (departmentServiceDto == null) return BadRequest("empty DepartmentDto");

                DepartmentService entity = _mapper.Map<DepartmentService>(departmentServiceDto);

                var res = await RepositoryManager.departmentServiceRepository.AddAndReturn(entity);


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
                    var res = await RepositoryManager.departmentServiceRepository.GetById(int.Parse(ServiceManager.SecurityDataProtector.Decode(id)));
                    if (res.Status.Succeeded)
                    {
                        var map = _mapper.Map<DepartmentServiceDto>(res.Data);

                        CommonVm<DepartmentServiceDto> commonVm = new CommonVm<DepartmentServiceDto>();

                        commonVm.obj = map;
                      

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
        [HttpPost]
        [CurrentUserFiltterAttrubite()]
        public async Task<IActionResult> Edit(DepartmentService departmentServiceEdit)
        {


            try
            {
                if (departmentServiceEdit == null) return BadRequest("empty departmentDto");

                departmentServiceEdit.State = 1;
                DepartmentService entity = _mapper.Map<DepartmentService>(departmentServiceEdit);

                var res = await RepositoryManager.departmentServiceRepository.Update(entity);
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
                var res = await RepositoryManager.departmentServiceRepository.GetById(int.Parse(ServiceManager.SecurityDataProtector.Decode(id)));
                if (res.Status.Succeeded)
                {
                    var deletedres = await RepositoryManager.departmentServiceRepository.Remove(res.Data);
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
