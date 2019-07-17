using www;

namespace alternate
{
    class AlternateProgram
    {
        static void Main(string[] args)
        {
            new ApiServer(8080, new InMemoryStuffHolder()).Run();
        }
    }
}
