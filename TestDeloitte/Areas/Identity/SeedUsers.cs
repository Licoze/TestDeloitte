using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TestDeloitte.Areas.Identity.Data;
using TestDeloitte.Services;

namespace TestDeloitte.Areas.Identity
{
    public static class MyIdentityDataInitializer
    {

        public static void SeedUsers(this UserManager<ApplicationUser> userManager, IModelExtractionService<List<UserDataModel>> extractionService)
        {
            var model= extractionService.ExctractModelFromFile();
            model.ForEach(u => {
                userManager.CreateAsync(new ApplicationUser { 
                Login=u.Login,
                UserName=u.Name
                }, u.Password);
            });
            
        }
        public class UserDataModel
        {
            public string Login { get; set; }
            public string Name { get; set; }
            public string Password { get; set; }

        }
    }
}
