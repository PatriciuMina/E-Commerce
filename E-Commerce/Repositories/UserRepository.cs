using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Runtime.Remoting.Contexts;
using E_Commerce;
using E_Commerce.Models;
using Microsoft.AspNet.Identity;
using Owin;
using Microsoft.AspNet.Identity.Owin;

namespace E_commerce
{
    public class UserRepository
    {
        public UserRepository() {  }

        public IEnumerable<IdentityUser> GetUsers()
        {
            List<ApplicationUser> users = new List<ApplicationUser>();
            var manager = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            users = manager.Users.ToList();
            return users;
        }

        public IdentityUser GetUser(string id)
        {
            var manager = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            return manager.FindById(id);
        }

        public IdentityResult RegisterUser(IdentityUser user, string Pass)
        {
            var manager = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = System.Web.HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();
            var user2 = new ApplicationUser() { UserName = user.UserName, Email = user.Email, PhoneNumber = user.PhoneNumber };
            IdentityResult result = manager.Create(user2, Pass);
            if (result.Succeeded)
            {
                signInManager.SignIn<ApplicationUser, string>( user2, isPersistent: false, rememberBrowser: false);
            }
            return result;
        }

        public IdentityResult CreateUser(IdentityUser user, string Pass, string Role)
        {
            var manager = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = System.Web.HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();
            var user2 = new ApplicationUser() { UserName = user.UserName, Email = user.Email, PhoneNumber = user.PhoneNumber };
            IdentityResult result = manager.Create(user2, Pass);
            var id = manager.FindByEmail(user.Email).Id;
            manager.AddToRole(id,Role);
            return result;
        }

        public SignInStatus SignInUser(string Email, string Password, bool rememberMe)
        {
            // Validate the user password
            var manager = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signinManager = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationSignInManager>();

            // This doen't count login failures towards account lockout
            // To enable password failures to trigger lockout, change to shouldLockout: true
            var result = signinManager.PasswordSignIn(Email, Password, rememberMe, shouldLockout: false);
            return result;

        }

        public void DeleteUser(string id)
        {
            var manager = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = manager.FindById(id);
            manager.Delete(user);

        }

        public bool UpdateUser(string id, IdentityUser updatedUser, string pass, string role)
        {
            var manager = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = System.Web.HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();

            var existingUser = manager.FindById(id);
            if (existingUser != null)
            {
                
                existingUser.UserName = updatedUser.UserName;
                existingUser.Email = updatedUser.Email;
                existingUser.PhoneNumber = updatedUser.PhoneNumber;
                
                

                var result = manager.Update(existingUser);
                return result.Succeeded;
            }
            else
            {
                return false;
            }
        }


    }
}