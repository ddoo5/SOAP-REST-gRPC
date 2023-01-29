using System;
using MasterServiceNamespace;

namespace SlaveService.Service
{
	public interface IFromSlaveToMasterService
	{
        public Task<IEnumerable<WeatherForecast>> Get();
	}
}

