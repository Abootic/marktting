
using Base.Common.Interface;
using System.Text.Json;


namespace Base.Common.Classes
{
    public class CustomConventer : ICustomConventer
    {
      

        public string EncodeJson(object obj)
        {

            return JsonSerializer.Serialize(obj);
        }

        public T DecodeJson<T>(string json) where T : class
        {


            return JsonSerializer.Deserialize<T>(json); ;
        }

    }

}
