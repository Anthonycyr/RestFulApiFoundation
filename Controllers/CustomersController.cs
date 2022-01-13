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

        [HttpGet("CustomerInfo/{id}")]
        public async Task<ActionResult<Customer>> GetCustomerInfo(long id)
        {
            var customer = await _context.customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        [HttpPut("ContactUpdate/{id}&{company_name}&{company_headquarter}&{company_contact}&{company_description}&{service_technical_authority_name}&{technical_authority_phone}&{service_technical_authority_email}")]
        public string ContactUpdate(long id, string company_name, string company_headquarter, string company_contact, string company_description, string service_technical_authority_name, string technical_authority_phone, string service_technical_authority_email)
        {
            var InfoCustomer = _context.customers.Find(id);
            if (InfoCustomer == null)
            {
                return "Please use a valid customer id";
            }
            else
            {
                InfoCustomer.company_name = $"{company_name}";
                InfoCustomer.company_headquarter = $"{company_headquarter}";
                InfoCustomer.company_contact = $"{company_contact}";
                InfoCustomer.company_description = $"{company_description}";
                InfoCustomer.service_technical_authority_name = $"{service_technical_authority_name}";
                InfoCustomer.technical_authority_phone = $"{technical_authority_phone}";
                InfoCustomer.service_technical_authority_email = $"{service_technical_authority_email}";

                _context.customers.Update(InfoCustomer);
                _context.SaveChanges();
                return "The company's infos has been successfully changed";
            }
        }




        // GET: api/Customers/{email}
        [HttpGet("{company_email}")]
        public async Task<ActionResult<bool>> IsEmailCustomer(string company_email)
        {
            var customerlist = await _context.customers.ToListAsync();
            foreach (Customer customer in customerlist)
            {
                if ((customer.company_email == $"{company_email}") == true)
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
                if (customer.company_email == company_email)
                {
                    return customer.Id;
                }
            }
            return null;
        }

    }
}
