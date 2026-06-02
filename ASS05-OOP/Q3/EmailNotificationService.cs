using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASS05_OOP.Q3
{
    internal class EmailNotificationService : INotificationService
    {
        public void SendNotification(string notificationId, string message)
        {
            Console.WriteLine($"Email sending by {notificationId} at massege is {message}");
        }
    }
}
