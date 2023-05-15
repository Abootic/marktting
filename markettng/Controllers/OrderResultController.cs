using AutoMapper;
using Base.Models.Dto;
using Base.Models.Entity;
using markettng.Controllers.Base;
using markettng.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;

namespace markettng.Controllers
{
    [Authorize]
    public class OrderResultController : BaseApiController
    {
        private readonly IMapper _mapper;

        public OrderResultController(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<IActionResult> Index(string id)
        {
            try
            {
                TempData["fid"] = int.Parse( ServiceManager.SecurityDataProtector.Decode(id));
                OrderResultVm commonVm = new OrderResultVm();
                commonVm.orderResultVm = new List<OrderResultDto>();
                var res=await RepositoryManager.departmentRepository.GetAll();
                if(res.Status.Succeeded)
                {
                    var map =_mapper.Map<IEnumerable<DepartmentDto>>(res.Data);
                    commonVm.departmentVm = map.ToList();
                    return PartialView("Index", commonVm);
                }
                return BadRequest(res.Status.message);
            }catch(Exception ex)
            {
                string exMsg=ex.InnerException!=null? ex.InnerException.Message: ex.Message;
                return BadRequest(exMsg);

            }
        }
        public async Task<IActionResult> GetDepartmentServices(int id)
        {
            try
            {

                var listDict = new List<Dictionary<string, dynamic>> ();
                var res = await RepositoryManager.departmentServiceRepository.Find(a => a.DepartmentId == id);
                if (res.Status.Succeeded)
                {
                    foreach (var item in res.Data)
                    {
                        var dict=new Dictionary<string, dynamic>();
                        dict.Add("name", item.ServiceName);
                        dict.Add("id", item.Id);
                        listDict.Add(dict);
                    }
                    return Ok(listDict);
                }
                return BadRequest(res.Status.message);
            }
            catch (Exception ex)
            {
                string exMsg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest(exMsg);
            }
           
        }

        [HttpPost]
      [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(OrderResultVm1 orderResultDtos)
        {
            try
            {
               
                string message = "";
                bool success = false;
                int FacilityId = int.Parse(ServiceManager.SecurityDataProtector.Decode(orderResultDtos.FacilityId));
                foreach (var item in orderResultDtos.DepartmentServiceId)
                {
                    Console.WriteLine($"rrrrrrrrrrrrrrrrrrrrrrrrr  {item}  ");
                    OrderResultDto dto = new OrderResultDto()
                    {
                        DepartmentServiceId = item,
                        FacilityId = FacilityId,
                        Note = orderResultDtos.Note,
                        other = orderResultDtos.other
                    };


                    var entity = _mapper.Map<OrderResult>(dto);
                    var res = await RepositoryManager.orderResultRepository.Add(entity);
                    if (res.Status.Succeeded)
                    {
                        success = true;
                        message = res.Status.message;
                        await RepositoryManager.UnitOfWork.CompleteAsync();
                    }
                    else
                    { message = res.Status.message;
                        success = false;
                    }

                }
                if(success)
                {
                    return Ok(message);
                }
                else
                {
                    return BadRequest(message);
                }
            }
            catch(Exception ex) 
            {
                Console.WriteLine($"eroooooooooooor  {ex.Message}");
              //  string exMsg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return BadRequest(ex.Message);
            }
        }
        //public async Task<IActionResult> Index()
        //{
        //    OrderResultVm vm = new OrderResultVm();
        //    vm.departmentVm = new List<DepartmentVm>();
        //    vm.departmentServiceVm = new List<DepartmentServiceVm>();
        //       var dept=await RepositoryManager.departmentRepository.GetAll();

        //    if(dept.Status.Succeeded) {
        //        var deptmap=_mapper.Map<List<DepartmentDto>>(dept.Data);
        //    foreach(var item in dept.Data)
        //        {
        //            vm.departmentVm.Add( new DepartmentVm { Id = item.Id, Name = item.Name });
                   
                  
        //            var deptserv=await RepositoryManager.departmentServiceRepository.Find(a=>a.DepartmentId==item.Id);
               
        //            if(deptserv.Status.Succeeded) {
        //            foreach(var dsItem in deptserv.Data)
        //                {
        //                    vm.departmentServiceVm.Add(new DepartmentServiceVm { departmentServiceId = dsItem.Id, ServiceName = dsItem.ServiceName, DepartmentId = dsItem.DepartmentId });
                          



        //                }
        //            }
        //        }

            
        //        return View(vm);
        //    }
        //    return View();

          
        //}

        //public async Task<List<string>> GetDeptList(int Id)
        //{
        //    var deptservV = await RepositoryManager.departmentRepository.GetAll();

        //    var LISTT = deptservV;
        //    var LISTTM = new List<String>();
        //    var LISTMTM = new List<DepartmentServiceVm>();
        //    var LISTMTMM = new List<DepartmentServiceVm>();
        //    foreach (var dsItem in deptservV.Data)
        //    {

        //        var deptserv = await RepositoryManager.departmentServiceRepository.Find(a => a.DepartmentId == Id);

        //        if (deptserv.Data != null)
        //        {
        //            foreach (var dsIteMm in deptserv.Data)
        //            {
        //                LISTMTM.Add(new DepartmentServiceVm { departmentServiceId = dsIteMm.Id, ServiceName = dsIteMm.ServiceName, DepartmentId = dsIteMm.DepartmentId });
        //            }
        //        }

        //    }
        //    if (LISTMTM.Count() != 0)
        //    {
        //        var scx = deptservV.Data.Count();
        //        var db = LISTMTM.MaxBy(x=>x.DepartmentId);
        //        for (int g=0;g<LISTMTM.Count;g++)
        //        {

        //            var d = LISTMTM.Where(x => x.DepartmentId == deptservVV.Id).ToList();

        //        }



        //    }
        //}
    }
}
