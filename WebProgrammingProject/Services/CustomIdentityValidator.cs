using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using Microsoft.Extensions.Localization;
using WebProgrammingProject.Services;

namespace BusinessLayer.ValidationRules
{
    public class CustomIdentityValidator:IdentityErrorDescriber
    {
        private readonly LanguageService languageService;

        public CustomIdentityValidator(LanguageService languageService)
        {
            this.languageService = languageService;
        }

        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError
            {
                Code = "PasswordTooShort",
                Description = languageService.GetKey("Services.PasswordTooShort").Value
            };
        }
        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError
            {
                Code = "PasswordRequiresUpper",
                Description = languageService.GetKey("Services.PasswordRequiresUpper").Value
            };
        }
        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError
            {
                Code= "PasswordRequiresLower",
                Description= languageService.GetKey("Services.PasswordRequiresLower").Value
            };
        }
        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError
            {
                Code= "PasswordRequiresNonAlphanumeric",
                Description= languageService.GetKey("Services.PasswordRequiresNonAlphanumeric").Value
            };
        }
        
    }
}
