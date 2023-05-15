namespace markettng.ViewModel
{
    public class MainReportVm
    {
       public IEnumerable<ReportListVm> data {  get; set; }
        public ReportVm reportVm { get; set; }
        public PrintReportVm printReportVm { get; set; }

        public int viewNumber { get; set; }
    }
}
