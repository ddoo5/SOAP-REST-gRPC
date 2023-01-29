using MasterServiceNamespace;
using Microsoft.AspNetCore.Mvc;
using SlaveService.Service;

namespace SlaveService.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IFromSlaveToMasterService _service;



    public WeatherForecastController(ILogger<WeatherForecastController> logger, IFromSlaveToMasterService service)
    {
        _logger = logger;
        _service = service;
    }




    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        return await _service.Get();
    }
}

