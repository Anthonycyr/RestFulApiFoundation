using System.Collections.Generic;
using System;

namespace RestfulApi.Models
{
    public class Column
    {
        public long Id { get; set; }
        public string status { get; set; }
        public int number_of_floors_served { get; set; }
        public DateTime created_at { get; set; }
        public int battery_id { get; set; }
    }
}