using System.Collections.Generic;
using System;

namespace RestfulApi.Models
{
    public class Intervention
    {
        public long id { get; set; }
        public int author { get; set; }
        public int customer_id { get; set; }
        public int building_id { get; set; }
        public int battery_id { get; set; }
        public int? column_id { get; set; }
        public int? elevator_id { get; set; }
        public int? employee_id { get; set; }
        public DateTime? intervention_start_date_time { get; set; }
        public DateTime? intervention_end_date_time { get; set; }
        public string result { get; set; }
        public string report { get; set; }
        public string status_opt { get; set; }
    }
}