using System;
using real;

namespace www
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var stuffHolder = new RealStuffHolder("real stuff", TimeSpan.FromMilliseconds(500));
            new ApiServer(8080, stuffHolder).Run();
        }
    }
}
