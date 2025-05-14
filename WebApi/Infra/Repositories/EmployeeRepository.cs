using WebApi.Domain.DTOs;
using WebApi.Domain.Model;

namespace WebApi.Infra.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();

        public void Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public List<EmployeeDTO> Get(int pageNumber, int pageQuantity)
        {
            return _context.Employees
                .Skip(pageNumber * pageQuantity) // Pula os registros das páginas anteriores (ex: página 2 com 10 itens/página → pula 20)
                .Take(pageQuantity)              // Seleciona apenas a quantidade de registros desejada para a página atual
                .Select(b =>
                new EmployeeDTO()
                {
                    Id = b.id,
                    NameEmployee = b.name,
                    Photo = b.photo
                })
                .ToList();                       // Executa a query e converte o resultado para uma lista em memória   
        }

        public Employee? Get(int id)
        {
            return _context.Employees.Find(id);

        }
    }
}
