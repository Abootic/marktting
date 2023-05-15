using Base.Models.Entity;
using markettng.Controllers.Base;
using markettng.Services;
using markettng.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;

namespace markettng.Controllers
{
    [Authorize(Roles = "admin")]
    public class ReportsController : BaseApiController
    {

        public IActionResult Index()
        {
            return PartialView("Index");
        }

        public IActionResult Report(int? id)
        {
            MainReportVm mainReportVm = new MainReportVm();
            mainReportVm.data = new List<ReportListVm>();
            mainReportVm.reportVm = new ReportVm();
            mainReportVm.printReportVm = new PrintReportVm();
            if (id != null)
            {
                if (id == 0)
                {
                    // mainReportVm.reportVm.userId = "null";
                    mainReportVm.viewNumber = 0;
                }
                else if (id == 1)
                {
                    mainReportVm.viewNumber = 1;
                }
                else if (id == 2)
                {
                    mainReportVm.viewNumber = 2;
                }
                else if (id == 3)
                {
                    mainReportVm.viewNumber = 3;
                }
            }

            return PartialView("_Report", mainReportVm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReportViaUser(ReportVm reportVm)
        {
            MainReportVm mainReportVm = new MainReportVm();
            TempData["check"] = null;

            try
            {



                if (reportVm.userId != "null")
                {
                    List<ReportListVm> reportListVm = new List<ReportListVm>();

                    var user = await RepositoryManager.UserRepository.FindByIdAsync(reportVm.userId);
                    string reportName = string.Format(" تقرير بالزيارات المنفذة من قبل الأخ/{0} خلال الفترة من {1} الى الفترة{2} ", user.Data.FullName, reportVm.fromDate, reportVm.toDate);
                    TempData.SetTemp<string>("reportName", reportName);
                    var res = await RepositoryManager.facilityRepository.Find(a => a.UserId == reportVm.userId);
                    if (res.Status.Succeeded)
                    {

                        foreach (var facility in res.Data)
                        {
                            var vist = await RepositoryManager.VisitRepository.Find(a => a.VisitTime.Date >= reportVm.fromDate.Date && a.VisitTime.Date <= reportVm.toDate.Date && a.FacilityId == facility.Id);
                            //var vist = await RepositoryManager.VisitRepository.Find(a => (a.VisitTime >= reportVm.fromDate && a.VisitTime <= reportVm.toDate)  && a.FacilityId == facility.Id );


                            if (vist.Status.Succeeded)
                            {

                                if (vist.Data.Any())
                                {
                                    foreach (var v in vist.Data)
                                    {

                                        var vistResult = await RepositoryManager.VisitResultRepository.Find(a => a.FacilityId == v.FacilityId.Value);

                                        var channel = await RepositoryManager.communicationChannelRepository.Find(a => a.FacilityId == v.FacilityId.Value);


                                        var ftype = await RepositoryManager.FacilityTypeRepository.Find(a => a.Id == facility.FacilityTypeId.Value);


                                        reportListVm.Add(new ReportListVm
                                        {
                                            Date = vist.Data.First().VisitTime,
                                            facilityName = facility.TradeName,
                                            facilityType = ftype.Data.First().Name,
                                            phoneNubmer = channel.Data.First().PhoneNumber,
                                            vistType = vistResult.Data.First().ResultType,
                                            vistId = vist.Data.First().Id,
                                            facilityActivity = facility.FacilityActivity,
                                            address = facility.Address,
                                            Note = vistResult.Data.First().Note


                                        });
                                    }
                                    TempData.SetTemp<string>("reportTime", DateTime.Now.ToString());
                                    TempData["check"] = "print";
                                    mainReportVm.data = reportListVm;
                                }
                                

                               
                            }
                            else
                            {

                                mainReportVm.data = new List<ReportListVm>();

                                TempData["reportErr"] = "لا يوجد تقرير ل هذا المسوق";
                                return BadRequest(vist.Status.message);
                                //return PartialView("_Report", mainReportVm);
                            }

                        }
                   //     mainReportVm.data = new List<ReportListVm>();
                        mainReportVm.reportVm = new ReportVm();
                        mainReportVm.printReportVm = new PrintReportVm();
                        mainReportVm.viewNumber = 0;
                        return PartialView("_Report", mainReportVm);
                    }

                    TempData["reportErr"] = "لا يوجد تقرير ل هذا المسوق";
                    return PartialView("_Report", mainReportVm);
                }
                else
                {


                    List<ReportListVm> reportListVm = new List<ReportListVm>();


                    TempData.SetTemp<string>("reportName", $" تقرير بالزيارات المنفذة من قبل كل المسوقين خلال الفترة من  {reportVm.fromDate} الى الفترة {reportVm.toDate}      ");
                    var res = await RepositoryManager.facilityRepository.GetAll();
                    if (res.Status.Succeeded)
                    {

                        foreach (var facility in res.Data)
                        {


                            var vist = await RepositoryManager.VisitRepository.Find(a => a.VisitTime.Date >= reportVm.fromDate.Date && a.VisitTime.Date <= reportVm.toDate.Date && a.FacilityId == facility.Id);
                            //var vist = await RepositoryManager.VisitRepository.Find(a => (a.VisitTime >= reportVm.fromDate && a.VisitTime <= reportVm.toDate)  && a.FacilityId == facility.Id );


                            if (vist.Status.Succeeded)
                            {

                                if (vist.Data.Any())
                                {
                                    foreach (var v in vist.Data)
                                    {

                                        var vistResult = await RepositoryManager.VisitResultRepository.Find(a => a.FacilityId == v.FacilityId.Value);

                                        var channel = await RepositoryManager.communicationChannelRepository.Find(a => a.FacilityId == v.FacilityId.Value);


                                        var ftype = await RepositoryManager.FacilityTypeRepository.Find(a => a.Id == facility.FacilityTypeId.Value);


                                        reportListVm.Add(new ReportListVm
                                        {
                                            Date = vist.Data.First().VisitTime,
                                            facilityName = facility.TradeName,
                                            facilityType = ftype.Data.First().Name,
                                            phoneNubmer = channel.Data.First().PhoneNumber,
                                            vistType = vistResult.Data.First().ResultType,
                                            vistId = vist.Data.First().Id,
                                            facilityActivity = facility.FacilityActivity,
                                            address = facility.Address,
                                            Note = vistResult.Data.First().Note


                                        });
                                    }
                                }
                                TempData.SetTemp<string>("reportTime", DateTime.Now.ToString());
                                TempData["check"] = "print";
                                mainReportVm.data = reportListVm;
                            }
                            else
                            {

                                mainReportVm.data = new List<ReportListVm>();

                                return BadRequest("لا يوجد تقارير ل هذا المسوق");
                            }

                        }
                        mainReportVm.reportVm = new ReportVm();
                        mainReportVm.printReportVm = new PrintReportVm();
                        mainReportVm.viewNumber = 0;
                        return PartialView("_Report", mainReportVm);
                    }

                    return BadRequest("لا يوجد تقارير ل هذا المسوق");

                }
            }
            catch (Exception ex)
            {
                string exMsg = ex.InnerException == null ? ex.Message : ex.InnerException.Message;

                return BadRequest(exMsg);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReportViaFacilityType(ReportVm reportFtypeVm)
        {
            TempData["check"] = null;
            MainReportVm mainReportVm = new MainReportVm();
            List<ReportListVm> reportListVm = new List<ReportListVm>();
            var Fres = await RepositoryManager.FacilityTypeRepository.GetById(reportFtypeVm.FacilityTypeId.Value);
            string reportName = string.Format(" تقرير بالمنشأت التي تم زيارتها( {0} ) خلال الفترة من {1} الى الفترة{2} ", Fres.Data.Name, reportFtypeVm.fromDate, reportFtypeVm.toDate);
            TempData.SetTemp<string>("reportName", reportName);
            var res = await RepositoryManager.facilityRepository.Find(a => a.FacilityTypeId == Fres.Data.Id);

            if (res.Status.Succeeded)
            {
                foreach (var facility in res.Data)
                {

                    var vist = await RepositoryManager.VisitRepository.Find(a => (a.VisitTime.Date >= reportFtypeVm.fromDate.Date && a.VisitTime.Date <= reportFtypeVm.toDate && a.FacilityId == facility.Id));


                    if (vist.Status.Succeeded)
                    {

                        if (vist.Data.Any())
                        {
                            foreach (var v in vist.Data)
                            {
                                var vistResult = await RepositoryManager.VisitResultRepository.Find(a => a.FacilityId == v.FacilityId);

                                var channel = await RepositoryManager.communicationChannelRepository.Find(a => a.FacilityId == v.FacilityId);
                                var fType = await RepositoryManager.FacilityTypeRepository.Find(a => a.Id == facility.FacilityTypeId);
                                reportListVm.Add(new ReportListVm
                                {
                                    Date = vist.Data.First(a => a.FacilityId == facility.Id).VisitTime,
                                    facilityName = facility.TradeName,
                                    facilityType = fType.Data.First().Name,
                                    phoneNubmer = channel.Data.First().PhoneNumber,
                                    vistType = vistResult.Data.First().ResultType,
                                    vistId = vist.Data.First().Id,
                                    facilityActivity = facility.FacilityActivity,
                                    address = facility.Address,
                                    Note = vistResult.Data.First().Note

                                });
                            }
                        }

                        TempData.SetTemp<string>("reportTime", DateTime.Now.ToString());

                        TempData["check"] = "print";
                        mainReportVm.data = reportListVm;

                    }
                    else
                    {

                        mainReportVm.data = new List<ReportListVm>();


                    }

                }

                mainReportVm.reportVm = new ReportVm();
                mainReportVm.printReportVm = new PrintReportVm();
                mainReportVm.viewNumber = 1;
                return PartialView("_Report", mainReportVm);
            }

            mainReportVm.data = reportListVm;
            mainReportVm.reportVm = new ReportVm();
            mainReportVm.printReportVm = new PrintReportVm();
            mainReportVm.viewNumber = 1;
            return PartialView("_Report", mainReportVm);
            //}
            //catch(Exception ex)
            //{
            //    Console.WriteLine($"Error1: {ex.Message}");
            //    mainReportVm.reportVm = new ReportVm();
            //    mainReportVm.viewNumber = 1;

            //    return PartialView("_Report", mainReportVm);
            //}
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReportViaFacilityName(ReportVm reportTradeNameVm)
        {
            TempData["check"] = null;
            MainReportVm mainReportVm = new MainReportVm();
            List<ReportListVm> reportListVm = new List<ReportListVm>();
            string reportName = string.Format(" تقرير بالزيارات المنفذة الى المنشأة/{0} خلال الفترة من {1} الى الفترة{2} ", reportTradeNameVm.TradeName, reportTradeNameVm.fromDate, reportTradeNameVm.toDate);
            TempData.SetTemp<string>("reportName", reportName);
            var res = await RepositoryManager.facilityRepository.Find(a => a.TradeName == reportTradeNameVm.TradeName);
            if (res.Status.Succeeded)
            {
                foreach (var facility in res.Data)
                {


                    var vist = await RepositoryManager.VisitRepository.Find(a => a.VisitTime.Date >= reportTradeNameVm.fromDate.Date && a.VisitTime.Date <= reportTradeNameVm.toDate.Date && a.FacilityId == facility.Id);


                    if (vist.Status.Succeeded)
                    {

                        if (vist.Data.Any())
                        {
                            foreach (var v in vist.Data)
                            {
                                var vistResult = await RepositoryManager.VisitResultRepository.Find(a => a.FacilityId == v.FacilityId);

                                //  var channel = await RepositoryManager.communicationChannelRepository.Find(a => a.FacilityId == v.FacilityId);
                                var user = await RepositoryManager.UserRepository.FindByIdAsync(facility.UserId);
                                //  var fType = await RepositoryManager.FacilityTypeRepository.Find(a => a.Id == facility.FacilityTypeId);
                                reportListVm.Add(new ReportListVm
                                {
                                    Date = vist.Data.First(a => a.FacilityId == facility.Id).VisitTime,
                                    facilityName = facility.TradeName,
                                    vistId = vist.Data.First().Id,
                                    username = user.Data.FullName,
                                    vistType = vistResult.Data.First().ResultType,
                                    facilityActivity = facility.FacilityActivity,
                                    address = facility.Address,
                                    Note = vistResult.Data.First().Note



                                });
                            }
                        }
                        TempData.SetTemp<string>("reportTime", DateTime.Now.ToString());
                        TempData["check"] = "print";
                        mainReportVm.data = reportListVm;
                    }
                    else
                    {

                        mainReportVm.data = new List<ReportListVm>();


                    }

                }

                mainReportVm.reportVm = new ReportVm();
                mainReportVm.printReportVm = new PrintReportVm();
                mainReportVm.viewNumber = 2;
                return PartialView("_Report", mainReportVm);
            }

            mainReportVm.data = reportListVm;
            mainReportVm.reportVm = new ReportVm();
            mainReportVm.printReportVm = new PrintReportVm();
            mainReportVm.viewNumber = 2;
            return PartialView("_Report", mainReportVm);

        }
        public async Task<IActionResult> ReportSucessOrderResult()
        {
            TempData["check"] = null;
            Console.WriteLine("dddddddddddddddddddd");
            try
            {
                //TempData["check"] = null;
                MainReportVm mainReportVm = new MainReportVm();
                List<ReportListVm> reportListVm = new List<ReportListVm>();
                string reportName = string.Format("تقرير بالطلبات الناجحة");
                TempData.SetTemp<string>("reportName", reportName);
                var vistResuiltres = await RepositoryManager.VisitResultRepository.Find(a => a.ResultType == "تم تقديم الطلب");
                if (vistResuiltres.Status.Succeeded)
                {
                    foreach (var vresult in vistResuiltres.Data)
                    {
                        var facilityRes = await RepositoryManager.facilityRepository.Find(a => a.Id == vresult.FacilityId);
                        var channel = await RepositoryManager.communicationChannelRepository.Find(a => a.FacilityId == vresult.FacilityId);
                        var fType = await RepositoryManager.FacilityTypeRepository.Find(a => a.Id == facilityRes.Data.First().FacilityTypeId);
                        var vist = await RepositoryManager.VisitRepository.Find(a => a.FacilityId == vresult.FacilityId);

                        reportListVm.Add(new ReportListVm
                        {
                            Date = vist.Data.First().VisitTime,
                            facilityName = facilityRes.Data.First().TradeName,
                            facilityType = fType.Data.First().Name,
                            phoneNubmer = channel.Data.First().PhoneNumber,
                            vistType = vresult.ResultType,
                            vistId = vist.Data.First().Id,
                            facilityActivity = facilityRes.Data.First().FacilityActivity,
                            address = facilityRes.Data.First().Address,
                            Note = vresult.Note

                        });

                    }
                    mainReportVm.data = reportListVm;
                    mainReportVm.reportVm = new ReportVm();
                    mainReportVm.printReportVm = new PrintReportVm();
                    mainReportVm.viewNumber = 3;
                    TempData.SetTemp<string>("reportTime", DateTime.Now.ToString());
                    TempData["check"] = "print";
                    return PartialView("_Report", mainReportVm);
                }
                else
                {
                    mainReportVm.data = reportListVm;
                    mainReportVm.reportVm = new ReportVm();
                    mainReportVm.printReportVm = new PrintReportVm();
                    mainReportVm.viewNumber = 3;
                    return BadRequest("لايوجد طلب ناجح");
                }


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PrintReport(PrintReportVm printReportVm)
        {

            List<ReportListVm> report = new List<ReportListVm>();


            report = ServiceManager.CustomConventer.DecodeJson<List<ReportListVm>>(printReportVm.reportName);
            TempData["PrintReport"] = "yes";
            //  return View(report);
            return PartialView("_PrintReport", report);


        }
    }
}
