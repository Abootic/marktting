namespace Base.Common.Interface
{
    public interface ISecurityDataProtector
    {
        public string Encode(string value);
        public string Decode(string value);
    }
}
