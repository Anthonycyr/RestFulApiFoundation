using System.Collections.Generic;

namespace RestfulApi.Models
{
    public class Customer
    {
        public long Id { get; set; }
        public string company_name { get; set; }
        public string company_email { get; set; }
    }
}