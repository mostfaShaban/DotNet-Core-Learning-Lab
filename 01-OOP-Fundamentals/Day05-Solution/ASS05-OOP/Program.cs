using ASS05_OOP.Q1;
using ASS05_OOP.Q2;
using ASS05_OOP.Q3;

namespace ASS05_OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Q1-Define an interface IShape  Create two interfaces, ICircle and IRectangle

            //that inherit from IShape. Implement these interfaces in classes Circle and Rectangle.
            //Test your implementation by creating instances of both classes and displaying their shape information.

            //Circle circle = new Circle { Radius = 5 };
            //Rectangle rectangle = new Rectangle { Width = 4, Height = 6 };
            //Console.WriteLine("Circle:");
            //circle.DisplayShapeInfo();
            //Console.WriteLine("\nRectangle:");
            //rectangle.DisplayShapeInfo();

            #endregion

            #region Question 02: defining the IAuthenticationService 

            //IAuthenticationService basic1 =new BasicAuthenticationService();
            //Console.WriteLine(basic1.AuthenticateUser("mostaf", "123658"));
            //Console.WriteLine(basic1.AuthenticateUser("admin", "password123"));

            //Console.WriteLine(basic1.AuthorizeUser("Admin", "admin"));
            //Console.WriteLine(basic1.AuthorizeUser("admin", "Administrator"));

            #endregion

            #region Q3 : define the INotificationService interface ,EmailNotificationService, SmsNotificationService, and PushNotificationService
            //INotificationService notification01 = new EmailNotificationService();
            //notification01.SendNotification("mostfa", "Hallo Mostafa");
            //notification01.BrintedBy("mostfa");// valid


            //EmailNotificationService notification02 = new EmailNotificationService();
            //notification02.SendNotification("mostfa", "Hallo Mostafa");
            ////notification02.BrintedBy(); //invalid


            //INotificationService notification03 = new SmsNotificationService();
            //notification03.SendNotification("mostfa", "Hallo Mostafa");

            //INotificationService notification04 = new PushNotificationService();
            //notification04.SendNotification("mostfa", "Hallo Mostafa");




            #endregion
        }
    }
}
