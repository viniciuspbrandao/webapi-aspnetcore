using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Model;
using WebApi.ViewModel;

namespace WebApi.Controllers
{

    [ApiController]
    [Route("api/v1/employee")]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException();
        }

        
        [Authorize]
        [HttpPost]
        public IActionResult Add([FromForm]EmployeeViewModel employeeView)
        {
            var filePath = Path.Combine("Storage", employeeView.Photo.FileName);
            using Stream fileStream = new FileStream(filePath, FileMode.Create);//arquivos
            employeeView.Photo.CopyTo(fileStream);//salva o arquivo na pasta Storage

            var employee = new Employee(employeeView.Name, employeeView.Age, filePath);
            _employeeRepository.Add(employee);
            return Ok();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get(int pageNumber, int pageQuantity)
        {
            var employess = _employeeRepository.Get(pageNumber, pageQuantity);
            return Ok(employess);
        }


        [Authorize]
        [HttpPost]
        [Route("{id}/download")]
        public IActionResult DownloadPhoto(int id)
        {
            var employee = _employeeRepository.Get(id);
            var dataBytes = System.IO.File.ReadAllBytes(employee.photo);

            return File(dataBytes, "image/png");

        }

    }
}
