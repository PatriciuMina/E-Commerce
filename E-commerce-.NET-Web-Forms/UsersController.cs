using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;

namespace E_commerce
{
    public class UsersController : ApiController
    {
        static readonly UserRepository userRepository = new UserRepository();


        public IEnumerable<User> GetAllUsers()
        {
            return userRepository.GetUsers();
        }

        public User GetUser(int id)
        {
            User user = userRepository.GetUser(id);
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

        public User PostUser(User user)
        {
            user = userRepository.AddUser(user);
            return user;
        }

        public void PutUser(int id, User user)
        {
            user.Id = id;
            if (!userRepository.UpdateUser(user))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void DeleteUser(int id)
        {
            userRepository.DeleteUser(id);
        }
    }
}