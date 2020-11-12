using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using maderaAPI;
using maderaAPI.Models;
using maderaAPI.Repositories;

namespace maderaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly MaderaContext _context;
        private readonly IRepository<Employee> _employeeRepository;

        public EmployeeController(MaderaContext context, IRepository<Employee> employeeRepository)
        {
            _context = context;
            _employeeRepository = employeeRepository;
        }

        // GET: api/Employee
        [HttpGet]
        public IQueryable<Employee> GetAllEmployees()
        {
            return _employeeRepository.Table;
        }

        // GET: api/Employee/5
        [HttpGet("{id}")]
        public Employee GetEmployee(int id)
        {
            return _employeeRepository.GetById(id);
        }

        // PUT: api/Employee/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        public void UpdateEmployee(Employee employee)
        {
            try
            {
                if (employee == null)
                    throw new ArgumentNullException(nameof(employee));

                _employeeRepository.Update(employee);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

        }

        // POST: api/Employee
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public void PostEmployee(Employee employee)
        {
            try
            {
                if (employee == null)
                    throw new ArgumentNullException(nameof(employee));

                _employeeRepository.Insert(employee);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
        }

        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public void DeleteEmployee(int id)
        {
            try
            {
                var employee = _context.Employee.Find(id);
                if (employee == null)
                    throw new ArgumentNullException(nameof(employee));

                _employeeRepository.Delete(employee);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
        }
    }
}
