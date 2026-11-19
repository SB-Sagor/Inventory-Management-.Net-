using Microsoft.AspNetCore.Mvc;//mvc er necessery classes and attribute use korte dey 
//library initialize kore namespace and puro folder path ta ke ekta cirtain name a group kore dey 
namespace InventoryManagement.Controllers;//namespace code ke logical group er modde rakhe
//ei dorener controlelr use korte addcontrollers needed in program.cs
[ApiController]//webapi er jonno special behaivour dey 
[Route("[controller]")]//controller er name theke route create kore 
public class WeatherForecastController : ControllerBase//api controller er jonno necessary base functinality
{
    private static readonly string[] Summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];

    [HttpGet(Name = "GetWeatherForecast")]//endpoint er name 
    public IEnumerable<WeatherForecast> Get()
    {//5 ta object create kortese 
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();//object to array te convert kore

    }
}
