using Grpc.Net.Client;
using VetClinicService;
using static VetClinicService.VetClinicService;

AppContext.SetSwitch("System.Net.Http.SocetsHttpHandler.Http2UnencryptedSupport", true);
using var channel = GrpcChannel.ForAddress("http://localhost:5230");

VetClinicServiceClient clinicClient = new(channel);

var createClientResponse = clinicClient.CreateClient(new CreateClientRequest
{
    Document = "Some passport",
    Firstname = "Calisto",
    Lastname = "Moriarty",
    Patronymic = "Garcia"
});


if(createClientResponse.ErrorCode == 0)
{
    Console.WriteLine($"client with id: {createClientResponse.ClientId} created");
}
else
{
    Console.WriteLine($"Create client error.\n " +
        $"error message: {createClientResponse.ErrorMessage}\n" +
        $" error code: {createClientResponse.ErrorCode}");
}



Console.WriteLine("-------------");

var getClients = clinicClient.GetClients(new GetClientsRequest());

foreach(var cl in getClients.Clients)
{
    Console.WriteLine($"client id: {cl.ClientId}\n" +
        $"client name: {cl.Firstname}\n" +
        $"client documents: {cl.Document}");
}