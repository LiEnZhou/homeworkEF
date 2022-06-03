using System;
using System.Collections.Generic;

namespace homeworkEF.Models
{
    public partial class TblFood
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Style { get; set; }
        public int? Starts { get; set; }
        public decimal? Price { get; set; }
        public string? Comment { get; set; }
    }
}
