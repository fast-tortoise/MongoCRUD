using Microsoft.AspNetCore.Mvc;
using CRUDBusiness;
using CRUDRepository;
using CRUDModel;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace ApiController.Controllers
{
    [ApiController]
    [ApiVersion("3.0")]
    [Route("weather/forecast")]
    public class ClassV2Controller : ControllerBase
    {
        private readonly IServiceClass _serviceClass;
        private readonly ModelClass _modelClass;

        public ClassV2Controller(IServiceClass serviceClass, ModelClass modelClass)
        {
            _serviceClass = serviceClass;
            _modelClass = modelClass;
        }

        [Route("getAllClass")]
        [HttpGet]
        public IActionResult ReadAllClass()
        {
            var allClass = _serviceClass.ReadAllCollectionInClass();
            if (allClass == null)
                return BadRequest("No class data");
            return Ok("this is version2 baby.");
        }
    }
}
