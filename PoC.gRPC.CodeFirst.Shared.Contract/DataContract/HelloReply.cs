using System.Runtime.Serialization;

namespace PoC.gRPC.CodeFirst.Shared.Contract.DataContract;

[DataContract]
public class HelloReply
{
    [DataMember(Order = 1)]
    public string Message { get; set; }

    [DataMember(Order = 2)]
    public Guid[] UnitUniqueIdentifiers { get; set; }

    [DataMember(Order = 3)]
    public Dictionary<Guid, int[]> KeyValues { get; set; }

    [DataMember(Order = 4)]
    public JustEnum EnumExample { get; set; }
}