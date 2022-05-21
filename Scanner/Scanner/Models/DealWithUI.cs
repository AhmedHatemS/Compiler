namespace Compiler.Models
{
    public class DealWithUI
    {
        public string text { get; set; }
        public bool Accepted { get; set; }
        public int nOfErrors { get; set; }
        public List<TokenData> Tokens { get; set; }
        public List<TokenData> Errors { get; set; }
        public List<TokenData> MatchedTokens { get; set; }
        public List<TokenData> NotMatchedTokens { get; set; }
    }
}
