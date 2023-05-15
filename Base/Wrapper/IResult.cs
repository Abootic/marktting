
namespace Base.Wrapper
{
  
    public interface IResult
    {
        MessageResult Status { get; set; }
      
    }
    public interface IResult<out T> : IResult
    {

        T Data { get; }

    }
}
