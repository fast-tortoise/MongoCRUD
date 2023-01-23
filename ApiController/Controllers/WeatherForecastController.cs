//using Microsoft.AspNetCore.Mvc;
//using CRUDBusiness;
//using CRUDRepository;

//namespace ApiController.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class WeatherForecastController : ControllerBase
//    {
//        private static readonly string[] Summaries = new[]
//        {
//        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//        };

//        private readonly ILogger<WeatherForecastController> _logger;

//        private readonly ICreate _create;
//        private readonly IDelete _delete;
//        private readonly IUpdate _update;
//        private readonly IRead _read;

//        public WeatherForecastController(ILogger<WeatherForecastController> logger)
//        {
//            _logger = logger;
//        }

//        [HttpGet]
//        public IEnumerable<WeatherForecast> Get()
//        {
//            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
//            {
//                Date = DateTime.Now.AddDays(index),
//                TemperatureC = Random.Shared.Next(-20, 55),
//                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
//            })
//            .ToArray();

//        }
//    }
//}