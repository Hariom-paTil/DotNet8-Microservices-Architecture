using Microsoft.AspNetCore.Identity;

namespace Services.AuthAPI.Model
{
    // This class build only for the purpose of adding extra properties to the IdentityUser class.
    /// <summary>
    ///  simple word we create over custom class and iherit from the IdentityUser.
    ///  so it have all the properties of IdentityUser class and we can add our own properties to it.
    ///  but the new that we created that also have to be added in the DbContext class as well.
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        public string name { get; set; }
    }
}
