
namespace Base.Wrapper
{
    public class Result : IResult
    {
        public Result()
        {

        }

        public MessageResult Status { get; set; }
       // public bool Succeeded { get; set; }
        public static IResult Fail() => new Result { Status=new MessageResult { Succeeded = false } };
        public static IResult Fail(string message, int code)
        {
           // return new Result { Succeeded = false, Status = new MessageResult { message = message, code = code,Succeeded=false } };
            return new Result {  Status = new MessageResult { message = message, code = code,Succeeded=false } };
        }
        public static Task<IResult> FailAsync(string message, int code = 500)
        {
            return Task.FromResult(Fail(message, code));
        }
        public static IResult Sucess()
        {
            return new Result {Status =new MessageResult { Succeeded = true } };
        }
        public static IResult Sucess(string message, int code)
        {
            return new Result {  Status = new MessageResult { message = message, code = code,Succeeded=true } };
           // return new Result { Succeeded = true, Status = new MessageResult { message = message, code = code,Succeeded=true } };
        }
        public static Task<IResult> SucessAsync() => Task.FromResult(Sucess());
        public static Task<IResult> SucessAsync(string message, int code = 200)
        {
            return Task.FromResult(Sucess(message, code));
        }



    }
    public class Result<T> : IResult<T>
    {
        public MessageResult Status { get; set; }
       // public bool Succeeded { get; set; }

        public Result()
        {

        }
        public T Data { get; set; }


        public static Result<T> Fail() => new Result<T> { Status=new MessageResult { Succeeded = false } };
        public static Result<T> Fail(string message, int code)
        {
            return new Result<T> { Status = new MessageResult { message = message, code = code, Succeeded = false } };
           // return new Result<T> { Succeeded = false, Status = new MessageResult { message = message, code = code, Succeeded = false } };
        }
        public static Task<Result<T>> FailAsync(string message, int code = 500)
        {
            return Task.FromResult(Fail(message, code));
        }
        public static Result<T> Sucess()
        {
            return new Result<T> {Status=new MessageResult { Succeeded = true } };
        }
        public static Result<T> Sucess(string message, int code)
        {
          //  return new Result<T> { Succeeded = true, Status = new MessageResult{ message = message, code = code , Succeeded = true } };
            return new Result<T> {Status = new MessageResult{ message = message, code = code , Succeeded = true } };
        }
        public static Result<T> Sucess(T data)
        {
            return new Result<T> {Status=new MessageResult { Succeeded = true }, Data = data };
          //  return new Result<T> { Succeeded = true, Data = data };
        }

        public static Result<T> Sucess(T data, string message, int code)
        {
            return new Result<T> { Data = data, Status = new MessageResult{ message = message, code = code, Succeeded = true, } };
           // return new Result<T> { Succeeded = true, Data = data, Status = new MessageResult{ message = message, code = code, Succeeded = true, } };

        }

        public static Task<Result<T>> SucessAsync() => Task.FromResult(Sucess());

        public static Task<Result<T>> SucessAsync(string message, int code = 200)
        {
            return Task.FromResult(Sucess(message, code));
        }


        public static Task<Result<T>> SucessAsync(T data, string message, int code = 200)
        {
            return Task.FromResult(Sucess(data, message, code));
        }



        public static Task<Result<T>> SucessAsync(T data)
        {
            return Task.FromResult(Sucess(data));
        }




    }
}
