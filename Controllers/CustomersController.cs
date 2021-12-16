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

        [HttpPatch ("HeadquarterUpdate/{id}&{company_headquarter}")]
        public string HeadquarterUpdate (long id,string company_headquarter)
        {
            var InfoCustomer = _context.customers.Find(id);
            if (InfoCustomer == null) {
                return "Please use a valid customer id" ;
            }
            else {
                    InfoCustomer.company_headquarter = $"{company_headquarter}";
 
                _context.customers.Update (InfoCustomer);
                _context.SaveChanges ();
                return "The company headquarter has been successufully changed to "+$"{company_headquarter}";
            }   
        }

        [HttpPatch ("ContactUpdate/{id}&{company_contact}")]
        public string ContactUpdate (long id,string company_contact)
        {
            var InfoCustomer = _context.customers.Find(id);
            if (InfoCustomer == null) {
                return "Please use a valid customer id" ;
            }
            else {
                    InfoCustomer.company_contact = $"{company_contact}";
 
                _context.customers.Update (InfoCustomer);
                _context.SaveChanges ();
                return "The company contact has been successufully changed to "+$"{company_contact}";
            }   
        }

        [HttpPatch ("DescriptionUpdate/{id}&{company_description}")]
        public string DescriptionUpdate (long id,string company_description)
        {
            var InfoCustomer = _context.customers.Find(id);
            if (InfoCustomer == null) {
                return "Please use a valid customer id" ;
            }
            else {
                    InfoCustomer.company_description = $"{company_description}";
 
                _context.customers.Update (InfoCustomer);
                _context.SaveChanges ();
                return "The company description has been successufully changed to "+$"{company_description}";
            }   
        }

        [HttpPatch ("TechNameUpdate/{id}&{service_technical_authority_name}")]
        public string TechNameUpdate (long id,string service_technical_authority_name)
        {
            var InfoCustomer = _context.customers.Find(id);
            if (InfoCustomer == null) {
                return "Please use a valid customer id" ;
            }
            else {
                    InfoCustomer.service_technical_authority_name = $"{service_technical_authority_name}";
 
                _context.customers.Update (InfoCustomer);
                _context.SaveChanges ();
                return "The company's technical authority name has been successufully changed to "+$"{service_technical_authority_name}";
            }   
        }

        [HttpPatch ("TechPhoneUpdate/{id}&{technical_authority_phone}")]
        public string TechPhoneUpdate (long id,string technical_authority_phone)
        {
            var InfoCustomer = _context.customers.Find(id);
            if (InfoCustomer == null) {
                return "Please use a valid customer id" ;
            }
            else {
                    InfoCustomer.technical_authority_phone = $"{technical_authority_phone}";
 
                _context.customers.Update (InfoCustomer);
                _context.SaveChanges ();
                return "The company's technical authority phone # has been successufully changed to "+$"{technical_authority_phone}";
            }   
        }

        [HttpPatch ("TechEmailUpdate/{id}&{service_technical_authority_email}")]
        public string TechEmailUpdate (long id,string service_technical_authority_email)
        {
            var InfoCustomer = _context.customers.Find(id);
            if (InfoCustomer == null) {
                return "Please use a valid customer id" ;
            }
            else {
                    InfoCustomer.service_technical_authority_email = $"{service_technical_authority_email}";
 
                _context.customers.Update (InfoCustomer);
                _context.SaveChanges ();
                return "The company's technical authority email has been successufully changed to "+$"{service_technical_authority_email}";
            }   
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
