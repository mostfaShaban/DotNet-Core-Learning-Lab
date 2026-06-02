using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS05_OOP.Q3
{
    internal interface INotificationService
    {
        // method SendNotification that takes a recipient and a message as parameters

        public void SendNotification(string notificationId, string message);

        public void BrintedBy(string notificationId)
        {
            Console.WriteLine($" prited by {notificationId}");
             
            
        }




    }
}
