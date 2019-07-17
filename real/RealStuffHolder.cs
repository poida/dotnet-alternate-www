using System;
using System.Threading;
using core;

namespace real
{
    public class RealStuffHolder : IStuffHolder
    {
        private string stuff;
        private TimeSpan delay;

        public RealStuffHolder(string initialStuff, TimeSpan delay) {
            this.stuff = initialStuff;
            this.delay = delay;
        }

        public string Get()
        {
            PretendToDoImportantThings();
            return stuff;
        }

        public void Put(string stuff) {
            PretendToDoImportantThings();
            this.stuff = stuff;
        }

        private void PretendToDoImportantThings()
        {
            Thread.Sleep(this.delay);
        }
    }
}