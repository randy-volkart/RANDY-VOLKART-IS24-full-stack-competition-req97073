using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using products.Data;

namespace products.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<Product> Get()
    {
        if (System.IO.File.Exists(MockData.FileName))
        {
            var json = System.IO.File.ReadAllText(MockData.FileName);
            var data = JsonSerializer.Deserialize<Products>(json);

            if (data != null)
                return data.products.ToArray();
            else
                return new List<Product>().ToArray();
        }
        else
        {
            var data = MockData.CreateProductsList(40);
            string json = JsonSerializer.Serialize(data);

            System.IO.File.WriteAllText(MockData.FileName, json);

            return data.products.ToArray();
        }
    }
}
