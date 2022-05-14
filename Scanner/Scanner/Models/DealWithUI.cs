namespace Scanner.Models
{
    public class DealWithUI
    {
        public string text { get; set; }
        public int nOfErrors { get; set; }
        public List<OutputItems> Tokens { get; set; }
        public List<OutputItems> Errors { get; set; }
    }
}
