using Microsoft.AspNetCore.Mvc;
using CRUDBusiness;
using CRUDRepository;
using CRUDModel;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace ApiController.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("weather/forecast")]
    public class ClassController : ControllerBase
    {
        private readonly IServiceClass _serviceClass;
        private readonly ModelClass _modelClass;
        public ClassController(IServiceClass serviceClass, ModelClass modelClass)
        {
            _serviceClass = serviceClass;
            _modelClass = modelClass;
        }


        [Route("addClass/{classId}/{className}/{subjectId}")]
        [HttpGet]
        public IActionResult AddClass(int classId, string className, int subjectId)
        {
            if (string.IsNullOrWhiteSpace(className))
            {
                return BadRequest("Name cannot be empty or null");
            }
            var insertedClass = _modelClass.CreateClass(classId, className, null);
            if (insertedClass == null)
            {
                return BadRequest("class registration failed");
            }
            return Ok(insertedClass);
        }

        [Route("getAllClass")]
        [HttpGet]
        public IActionResult ReadAllClass()
        {
            var allClass = _serviceClass.ReadAllCollectionInClass();
            if (allClass == null)
                return BadRequest("No class data");
            return Ok(allClass);
        }

        [Route("updateClassName/{oldCollection}/{newName}")]
        [HttpGet]

        public IActionResult UpdateClassName(string oldCollection, string newName)
        {
            if (string.IsNullOrWhiteSpace(oldCollection) || string.IsNullOrWhiteSpace(newName))
            {
                return BadRequest("Collection name cannot be empty or null");
            }
            _serviceClass.UpdateClassName(oldCollection, newName);
            return Ok();
        }

        [Route("deleteClass/{classToBeDeleted}")]
        [HttpGet]

        public IActionResult DeleteClass(string classToBeDeleted)
        {
            if (string.IsNullOrWhiteSpace(classToBeDeleted))
            {
                return BadRequest("Collection name cannot be empty or null");
            }
            _serviceClass.DeleteClass(classToBeDeleted);

            return Ok();

        }
    }
}
