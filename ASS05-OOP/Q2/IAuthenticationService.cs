using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS05_OOP.Q2
{
    internal interface IAuthenticationService
    {
        // Define a method for user authentication named AuthenticateUser 

        bool AuthenticateUser(string username, string password);

        // Define a method AuthorizeUser.
        bool AuthorizeUser(string username, string role);



    }
}
