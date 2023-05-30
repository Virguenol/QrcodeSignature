using Grs.BioRestock.Infrastructure.Models.Identity;
using Grs.BioRestock.Application.Specifications.Base;

namespace Grs.BioRestock.Infrastructure.Specifications
{
    public class UserFilterSpecification : HeroSpecification<UniUser>
    {
        public UserFilterSpecification(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                Criteria = p => p.FirstName.Contains(searchString) || p.LastName.Contains(searchString) || p.Email.Contains(searchString) || p.PhoneNumber.Contains(searchString) || p.UserName.Contains(searchString);
            }
            else
            {
                Criteria = p => true;
            }
        }
    }
}