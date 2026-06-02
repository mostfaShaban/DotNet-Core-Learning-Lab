using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS05_OOP.Q2
{
    internal class BasicAuthenticationService : IAuthenticationService
    {

        //the AuthenticateUser method compares the provided username and password with the stored credentials.
        //It returns true if the user is authenticated and false otherwise. 

        const string storedUsername = "admin";
        const string storedPassword = "password123";
        const string storedRole = "Administrator";
        public bool AuthenticateUser(string username, string password)
        {
            if (username.ToLower() == storedUsername.ToLower() && password.ToLower() == storedPassword.ToLower())
                return true;
            else
                return false;

        }

        public bool AuthorizeUser(string username, string role)
        {
            return username == storedUsername && role == storedRole;

            
        }
    }
}
