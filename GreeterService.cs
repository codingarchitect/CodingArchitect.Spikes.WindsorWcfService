namespace CodingArchitect.Spikes.WindsorWcfService
{
    public class GreeterService : IGreeterService
    {
        private readonly IGreeter greeter;
        public GreeterService(IGreeter greeter)
        {
            this.greeter = greeter;                
        }
        public string Greet()
        {
            return "Hello World from Web Service";
        }
    }
}