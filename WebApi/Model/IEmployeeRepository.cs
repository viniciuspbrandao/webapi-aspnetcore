namespace WebApi.Model
{
    public interface IEmployeeRepository
    {
        void Add(Employee employee);

        List<Employee> Get(int pageNumber, int pageQuantity);

        Employee? Get(int id);// "?" (Permite que o retorno seja nulo)
    }
}
