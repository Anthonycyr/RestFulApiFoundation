using System.Collections.Generic;
using System;
namespace RestfulApi.Models
{
    public class Elevator
    {
        public long Id { get; set; }
        public int serial_number { get; set; }
        public string model { get; set; }
        public string status { get; set; }
        public DateTime date_of_last_inspection { get; set; }
        public DateTime created_at { get; set; }
        public int column_id { get; set; }
    }
}