using System;
using System.Collections.Generic;

namespace homeworkEF.Models
{
    public partial class TblHero
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Atk { get; set; }
        public int? Hp { get; set; }
    }
}
