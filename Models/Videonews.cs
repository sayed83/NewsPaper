using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BangladeshToday.Models
{
    public partial class Videonews
    {
        public Videonews()
        {
            Allvideo = new HashSet<Allvideo>();
        }

        public int VideoNewsId { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        [DisplayName("Keywords")]
        public string Keyword { get; set; }
        [DisplayName("Date")]
        [DataType(DataType.Date)]
        public DateTime Datetime { get; set; }
        [DisplayName("Video")]
        public string Path { get; set; }

        public ICollection<Allvideo> Allvideo { get; set; }
    }
}
