namespace Web.Utility
{
    public class Response<T>
    {
        public bool success { get; set; }
        public T? body { get; set; }
    }
}
