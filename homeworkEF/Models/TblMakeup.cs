using System;
using System.Collections.Generic;

namespace homeworkEF.Models
{
    public partial class TblMakeup
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string Color { get; set; } = null!;
    }
}
