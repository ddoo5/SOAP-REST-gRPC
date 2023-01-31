using System;
using MasterServiceNamespace;

namespace SlaveService.Service
{
	public class FromSlaveToMasterService : IFromSlaveToMasterService
	{
        private readonly MasterServiceClient _service;



		public FromSlaveToMasterService(HttpClient client)
		{
            _service = new MasterServiceClient("http://localhost:5230", client);
		}



        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            return await _service.GetWeatherForecastAsync();
        }
    }
}

