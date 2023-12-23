using System.Runtime.Serialization;

namespace PoC.gRPC.CodeFirst.Shared.Contract.DataContract;

[DataContract]
public class HelloRequest
{
    [DataMember(Order = 1)]
    public string Name { get; set; }
}