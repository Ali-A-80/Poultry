namespace Poultry.Application.Core;

public class ResultDto<T>
{
    public bool IsSuccess { get; set; }
    public T Data { get; set; }
    public List<string> Errors { get; set; }

    public static ResultDto<T> Success(T data) => new ResultDto<T>() { Data = data, IsSuccess = true };
    public static ResultDto<T> Failure(List<string> errors) => new ResultDto<T>() { Errors = errors, IsSuccess = false };

}
