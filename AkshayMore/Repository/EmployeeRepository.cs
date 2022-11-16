using AkshayMore.Model;

namespace AkshayMore.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApiContext _context;
        public EmployeeRepository(ApiContext apiContext)
        {
            _context = apiContext;
        }

        public async Task<int> CreateEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee!);
            return await _context.SaveChangesAsync();
        }

        public async Task<Employee> GetEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            return employee!;
        }

        public List<Employee> GetEmployees()
        {
            return _context.Employees.ToList();
        }

        public async Task UpdateEmployee(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }
    }
}
