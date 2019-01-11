using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BangladeshToday.Models
{
    public class AdsDetails
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string Companyurl { get; set; }
        public string Picture { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal DailyRate { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
