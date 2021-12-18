using System.Collections.Generic;
using System;
namespace RestfulApi.Models
{
    public class Battery
    {
        public long Id { get; set; }
        public string status { get; set; }
        public int building_id { get; set; }
        public DateTime Creation_Date { get; set; }
        public DateTime Last_Inspect { get; set; }
    }
}