namespace Scanner.Models
{
    public class DealWithUI
    {
        public string text { get; set; }
        public int nOfErrors { get; set; }
        public List<TokenData> Tokens { get; set; }
        public List<TokenData> Errors { get; set; }
    }
}
