using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BangladeshToday.Models
{
    public partial class Newsinfo
    {
        public int Newsserial { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        [DisplayName("Published Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true )]
        public DateTime Datetime { get; set; }
        public string Keyword { get; set; }
        public string CaptionPicture { get; set; }
        public string Editor { get; set; }
        public string FeatureNews { get; set; }
        public string HotNews { get; set; }
        public string SlideShow { get; set; }
        public string SubFeatureNews { get; set; }
    }
}
