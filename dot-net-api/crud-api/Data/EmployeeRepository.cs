using Microsoft.EntityFrameworkCore;

namespace crud_api.Data
{
    public class EmployeeRepository
    {
        private readonly AppDbContext _context;
        public EmployeeRepository( AppDbContext context)
        {
            _context = context;
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            await _context.Set<Employee>().AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Employee>> GetEmployeeAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task UpdateEmployeeAsync(int id, Employee model)
        {
            var employee = await _context.Employees.FindAsync(id);
            if(employee == null)
            {
                throw new Exception("Employee not found");
            }

            employee.Name = model.Name;
            employee.Phone = model.Phone;
            employee.Age = model.Age;
            employee.Salary = model.Salary;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmployeeAsnyc(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if(employee == null)
            {
                throw new Exception("Employee not found");
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<Employee> GetEmployeeByEmail(string email)
        {
            return await _context.Employees.Where(x=> x.Email == email).FirstOrDefaultAsync();
        }
    }
}
