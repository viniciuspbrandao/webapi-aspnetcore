using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.ViewModel;
using WebApi.Domain.Model;
using WebApi.Domain.DTOs;

namespace WebApi.Controllers
{

    [ApiController]
    [Route("api/v1/employee")]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<EmployeeController> _logger;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeRepository employeeRepository, ILogger<EmployeeController> logger, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
            _mapper = mapper;
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
            _logger.Log(LogLevel.Error, "Erro"); //exemplo de como adicionar log de erro
            //throw new Exception("Erro de teste");//lancando erro para exemplificar a chamada
            var employess = _employeeRepository.Get(pageNumber, pageQuantity);
            _logger.LogInformation("Executando metodo get com paginacao");
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

        [Authorize]
        [HttpGet]
        [Route("{id}")]
        public IActionResult Search(int id)
        {
            _logger.LogInformation("Executando metodo de busca por id, e fazendo o mapeamento da Entidade para o DTO");
            var employess = _employeeRepository.Get(id);
            var employeesDTOs = _mapper.Map<EmployeeDTO>(employess);
            return Ok(employess);
        }

    }
}
