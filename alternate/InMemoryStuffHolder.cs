using core;

namespace alternate
{
    public class InMemoryStuffHolder : IStuffHolder
    {
        private string stuff;

        public InMemoryStuffHolder() {
            this.stuff = "fake stuff";
        }

        public string Get() {
            return stuff;
        }

        public void Put(string stuff) {
            this.stuff = stuff;
        }
    }
}