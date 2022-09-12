namespace TokenAuthentication.Models
{
    public class TokenModel
    {
        public string? Token { get; set; }
        public bool IsAuthenticated { get; set; }
        public string? Message { get; set; }
        public long UserId { get; set; }
        public string? UserName { get; set; }
        public string? UserType { get; set; }
        public int StatusCode { get; set; }

    }
}
