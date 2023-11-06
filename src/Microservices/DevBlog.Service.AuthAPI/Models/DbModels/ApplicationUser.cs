namespace DevBlog.Service.AuthAPI.Models.DbModels
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;

    using static DevBlog.Service.AuthAPI.Constants.AuthApiConstants.ApplicationUserConstants;

    public class ApplicationUser : IdentityUser
    {
        [StringLength(ApplicationUserFirstNameMaxLenght, MinimumLength = ApplicationUserFirstNameMinLenght)]
        public string FirstName { get; set; } = null!;

        [StringLength(ApplicationUserLastNameMaxLenght, MinimumLength = ApplicationUserLastNameMinLenght)]
        public string LastName { get; set; } = null!;
    }
}