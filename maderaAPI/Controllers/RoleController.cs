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
    public class RoleController : ControllerBase
    {
        private readonly MaderaContext _context;
        private readonly IRepository<Role> _roleRepository;

        public RoleController(MaderaContext context, IRepository<Role> roleRepository)
        {
            _context = context;
            _roleRepository = roleRepository;
        }

        // GET: api/Role
        [HttpGet]
        public IQueryable<Role> GetAllRoles()
        {
            return _roleRepository.Table;
        }

        // GET: api/Role/5
        [HttpGet("{id}")]
        public Role GetRole(int id)
        {
            return _roleRepository.GetById(id);
        }

        // PUT: api/Role/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        public void UpdateRole(Role role)
        {
            try
            {
                if (role == null)
                    throw new ArgumentNullException(nameof(role));

                _roleRepository.Update(role);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }

        }

        // POST: api/Role
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public void PostRole(Role role)
        {
            try
            {
                if (role == null)
                    throw new ArgumentNullException(nameof(role));

                _roleRepository.Insert(role);
            } catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }        
        }

        // DELETE: api/Role/5
        [HttpDelete("{id}")]
        public void DeleteRole(int id)
        {
            try
            {
                var role = _context.Role.Find(id);
                if (role == null)
                    throw new ArgumentNullException(nameof(role));

                _roleRepository.Delete(role);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
        }
    }
}
