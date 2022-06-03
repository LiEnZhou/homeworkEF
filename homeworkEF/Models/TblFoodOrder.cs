using System;
using System.Collections.Generic;

namespace homeworkEF.Models
{
    public partial class TblFoodOrder
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int FoodId { get; set; }
        public DateTime OrderDateTime { get; set; }
        public DateTime? PaidDateTime { get; set; }
    }
}
