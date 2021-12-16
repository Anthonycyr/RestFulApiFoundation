using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestfulApi.Models;
// using System.Data.Entity;

namespace RestfulApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerContext _context;

        public CustomersController(CustomerContext context)
        {
            _context = context;
        }


        // GET: api/Customers/{email}
        [HttpGet("{company_email}")]
        public async Task<ActionResult<bool>> IsEmailCustomer(string company_email)
        {
            var customerlist = await _context.customers.ToListAsync();
            foreach (Customer customer in customerlist)
            {
                if((customer.company_email == $"{company_email}") == true)
                {
                    return true;
                }
            }
            return false;
        }
        
        private bool CustomerExists(long id)
        {
            return _context.customers.Any(e => e.Id == id);
        }
        // GET: api/Customers/{email}
        [HttpGet("/getId/{company_email}")]
        public async Task<ActionResult<long>> IdCustomer(string company_email)
        {
            var customerlist = await _context.customers.ToListAsync();
            foreach (Customer customer in customerlist)
            {
                if((customer.company_email == $"{company_email}") == true)
                {
                    return customer.Id;
                }
            }
            return null;
        }
    }
}
