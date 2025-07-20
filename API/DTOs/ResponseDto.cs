namespace API.DTOs
{
    public class ResponseDto<T>
    {
        public T Data { get; set; } = default!;
    }
}
