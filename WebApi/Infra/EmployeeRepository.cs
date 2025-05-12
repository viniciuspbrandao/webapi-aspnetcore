using WebApi.Model;

namespace WebApi.Infra
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();

        public void Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public List<Employee> Get(int pageNumber, int pageQuantity)
        {
            return _context.Employees
                .Skip(pageNumber * pageQuantity) // Pula os registros das páginas anteriores (ex: página 2 com 10 itens/página → pula 20)
                .Take(pageQuantity)              // Seleciona apenas a quantidade de registros desejada para a página atual
                .ToList();                       // Executa a query e converte o resultado para uma lista em memória   
        }

        public Employee? Get(int id)
        {
            return _context.Employees.Find(id);

        }
    }
}
