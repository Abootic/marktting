namespace Base.Common.Interface
{
    public interface ICustomConventer
    {
        public string EncodeJson(object obj);
        public T DecodeJson<T>(string json) where T:class;
      
    }
}
