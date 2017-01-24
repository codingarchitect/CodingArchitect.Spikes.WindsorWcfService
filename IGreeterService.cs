using System.ServiceModel;

namespace CodingArchitect.Spikes.WindsorWcfService
{
    [ServiceContract]
    public interface IGreeterService
    {
        [OperationContract]
        string Greet();
    }
}
