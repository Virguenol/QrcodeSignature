namespace Grs.BioRestock.Transfer.Requests.Identity
{
    public class UpdateUserRequest
    {
        public string Id { get; set; }
        public string EmployeeID { get; set; }
        public string SiteID { get; set; }
        public int UserType { get; set; }
    }
}