using Microsoft.AspNetCore.Server.Kestrel.Core;
using PoC.gRPC.CodeFirst.Server.Services;
using ProtoBuf.Grpc.Server;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseKestrel(c => c.ConfigureEndpointDefaults(co => co.Protocols = HttpProtocols.Http2));

builder.Services.AddCodeFirstGrpc();

var app = builder.Build();

app.MapGrpcService<GreeterService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client");

app.Run();
