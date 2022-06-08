namespace homeworkEF.Models.ViewModel
{
    public class MakeupViewModel
    {
        public MakeupParams SearchParams { get; set; }
        public List<TblMakeup> Makeups { get; set; }

        public MakeupViewModel()
        {
            SearchParams = new MakeupParams();
            Makeups = new List<TblMakeup>();
        }
    }
    public class MakeupParams
    {
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
        public int Color { get; set; }
    }

}
