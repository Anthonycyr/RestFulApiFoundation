using System.Collections.Generic;

namespace RestfulApi.Models
{
    public class Customer
    {
        public long Id { get; set; }
        public string company_name { get; set; }
        public string company_email { get; set; }
        public string company_headquarter { get; set; }
        public string company_contact { get; set; }
        public string company_description { get; set; }
        public string service_technical_authority_name { get; set; }
        public string technical_authority_phone { get; set; }
        public string service_technical_authority_email { get; set; }
    }
}