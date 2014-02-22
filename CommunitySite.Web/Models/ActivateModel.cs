namespace CommunitySite.Web.Models
{
    public class ActivateModel
    {
        public bool Exists { get; set; }
        public string Email { get; set; }
    }

    public class UnsubscribeModel
    {
        public bool Exists { get; set; }
        public string Email { get; set; }
    }
}