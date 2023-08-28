using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using E_Commerce.Models;
using E_Commerce;
using Microsoft.AspNet.Identity.Owin;
using Newtonsoft.Json.Linq;

namespace E_commerce
{
    public class UsersController : ApiController
    {
        UserRepository userRepository = new UserRepository();


        public IEnumerable<IdentityUser> GetAllUsers()
        {
            return userRepository.GetUsers();
        }

        public IdentityUser GetUser(string id)
        {
            IdentityUser user = userRepository.GetUser(id);
            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return user;
        }


        //public HttpResponseMessage PostUser(User user)
        //{
        //    user = userRepository.AddUser(user);
        //    var response = Request.CreateResponse<User>(HttpStatusCode.Created, user);
        //    string uri = Url.Link("DefaultApi", new { id = user.Id });
        //    response.Headers.Location = new Uri(uri);
        //    return response;
        //}

        public IdentityResult RegisterUser(IdentityUser user, string Pass)
        {
            var result = userRepository.RegisterUser(user, Pass);
            return result;
        }

        public IdentityResult CreateUser([FromBody] JObject jsonData)
        {
            IdentityUser user = new ApplicationUser() { UserName = jsonData["UserName"].ToString(), Email = jsonData["Email"].ToString(), PhoneNumber = jsonData["PhoneNumber"].ToString() };
            string pass = jsonData["Pass"].ToString();
            string role = jsonData["Role"].ToString();
            var result = userRepository.CreateUser(user, pass, role);
            return result;
        }

        public SignInStatus SignInUser(string Email, string Password, bool rememberMe)
        {
            var result = userRepository.SignInUser(Email, Password, rememberMe);
            return result;
        }

        public void PutUser(string id, IdentityUser user)
        {
            user.Id = id;
            if (!userRepository.UpdateUser(user))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void DeleteUser(string id)
        {
            userRepository.DeleteUser(id);
        }
    }
}