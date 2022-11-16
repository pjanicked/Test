using AkshayMore.Model;

namespace AkshayMore.Repository
{
    public interface IEmployeeRepository
    {
        public List<Employee> GetEmployees();
        Task<Employee> GetEmployee(int id);
        Task UpdateEmployee(Employee employee);
        Task<int> DeleteEmployee(int id);
        Task<int> CreateEmployee(Employee employee);
    }
}
