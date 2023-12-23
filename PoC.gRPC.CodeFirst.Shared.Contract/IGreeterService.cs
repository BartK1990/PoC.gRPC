using PoC.gRPC.CodeFirst.Shared.Contract.DataContract;
using ProtoBuf.Grpc;
using System.ServiceModel;

namespace PoC.gRPC.CodeFirst.Shared.Contract;

[ServiceContract]
public interface IGreeterService
{
    [OperationContract]
    Task<HelloReply> SayHelloAsync(HelloRequest request, CallContext context = default);

    [OperationContract]
    IAsyncEnumerable<HelloReply> SayHellosAsync(HelloRequest request, CallContext context = default);
}