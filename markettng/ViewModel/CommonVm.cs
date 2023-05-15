using Base.Models.Dto;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace markettng.ViewModel
{
  
    public class CommonCildVm
    {
        public IEnumerable<CommunicationChannelDto> child { get; set; }
      
    } 
    public class CommonVm<T> 
    {
        public T obj { get; set; }
        public IEnumerable<T> data { get; set; }
     public CommunicationChannelDto? commonCildVm { get; set; }

    }
}
