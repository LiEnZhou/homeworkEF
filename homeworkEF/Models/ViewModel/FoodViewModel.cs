namespace homeworkEF.Models.ViewModel
{
    public class FoodViewModel
    {
        public FoodParams SearchParams { get; set; }
        public List<TblFood> Foods { get; set; }

        public FoodViewModel()
        {
            SearchParams = new FoodParams();
            Foods = new List<TblFood>();
        }
    }
    public class FoodParams
    {
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
        public int Starts { get; set; }
    }
}
