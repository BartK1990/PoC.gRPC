using Grpc.Core;
using PoC.gRPC.CodeFirst.Shared.Contract;
using PoC.gRPC.CodeFirst.Shared.Contract.DataContract;
using ProtoBuf.Grpc;

namespace PoC.gRPC.CodeFirst.Server.Services;

public class GreeterService : IGreeterService
{
    public Task<HelloReply> SayHelloAsync(HelloRequest request, CallContext context = default)
    {
        return Task.FromResult(
            new HelloReply
            {
                Message = $"Hello {request.Name} with GUID: {Guid.NewGuid()}"
            });
    }

    public async IAsyncEnumerable<HelloReply> SayHellosAsync(HelloRequest request, CallContext context = default)
    {
        Random rnd = new Random();
        for (int i = 0; i <= 100; i++)
        {
            await Task.Delay(40);
            yield return new HelloReply
            {
                Message = $"Hello {request.Name} with Id: {i}",
                UnitUniqueIdentifiers = new[] { Guid.NewGuid(), Guid.NewGuid() },
                KeyValues = new Dictionary<Guid, int[]>
                {
                    {Guid.NewGuid(), new[] {rnd.Next(1,10), rnd.Next(11,20), rnd.Next(21,30)}},
                    {Guid.NewGuid(), new[] {rnd.Next(31,40), rnd.Next(41,50), rnd.Next(51,60)}},
                },
                EnumExample = JustEnum.One
            };
        }
    }
}