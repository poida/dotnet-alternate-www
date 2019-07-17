namespace www
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new ApiServer(8080).Run();
        }
    }
}
