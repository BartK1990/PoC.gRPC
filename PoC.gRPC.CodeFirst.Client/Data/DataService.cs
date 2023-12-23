using Grpc.Net.Client;
using PoC.gRPC.CodeFirst.Shared.Contract;
using PoC.gRPC.CodeFirst.Shared.Contract.DataContract;
using ProtoBuf.Grpc.Client;

namespace PoC.gRPC.CodeFirst.Client.Data;

public class DataService
{
    public async Task<HelloReply?> GetData()
    {
        using var channel = GrpcChannel.ForAddress("http://localhost:5999");
        var client = channel.CreateGrpcService<IGreeterService>();
        HelloReply? reply = await client.SayHelloAsync(new HelloRequest { Name = "GreeterClient" });
        return reply;
    }

    public async IAsyncEnumerable<HelloReply?> GetDataStream()
    {
        using var channel = GrpcChannel.ForAddress("http://localhost:5999");
        var client = channel.CreateGrpcService<IGreeterService>();

        var call = client.SayHellosAsync(new HelloRequest { Name = "World" });

        await foreach (var response in call)
        {
            yield return response;
        }
    }
}