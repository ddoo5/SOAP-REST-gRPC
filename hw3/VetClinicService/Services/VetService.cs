using System;
using Grpc.Core;
using VetClinicService.Library.DBContext;
using VetClinicService.Library.Models;

namespace VetClinicService.Services
{
	public class VetService : VetClinicService.VetClinicServiceBase
	{
        private readonly VetClinicDbContext _dbContext;



        public VetService(VetClinicDbContext dbContext)
        {
            _dbContext = dbContext;
        }



        public override Task<CreateClientResponse> CreateClient(CreateClientRequest request, ServerCallContext context)
        {
            try
            {
                var client = new Client
                {
                    Document = request.Document,
                    Lastname = request.Lastname,
                    Firstname = request.Firstname,
                    Patronymic = request.Patronymic
                };

                _dbContext.Clients.Add(client);
                _dbContext.SaveChangesAsync();

                var response = new CreateClientResponse
                {
                    ClientId = client.Id,
                    ErrorCode = 0,
                    ErrorMessage = ""
                };

                return Task.FromResult(response);
            }
            catch(Exception ex)
            {
                var response = new CreateClientResponse
                {
                    ErrorCode = 1,
                    ErrorMessage = $"{ex.Message}"
                };

                return Task.FromResult(response);
            }
        }

        public override Task<GetClientsResponse> GetClients(GetClientsRequest request, ServerCallContext context)
        {
            try
            {
                var response = new GetClientsResponse();

                var clients = _dbContext.Clients.Select(x => new ClientResponse
                {
                    ClientId = x.Id,
                    Document = x.Document,
                    Firstname = x.Firstname,
                    Lastname = x.Lastname,
                    Patronymic = x.Patronymic
                }).ToList();

                response.Clients.AddRange(clients);

                return Task.FromResult(response);
            }
            catch(Exception ex)
            {
                var response = new GetClientsResponse
                {
                    ErrorCode = 1,
                    ErrorMessage = $"{ex.Message}"
                };

                return Task.FromResult(response);
            }
        }
    }
}

