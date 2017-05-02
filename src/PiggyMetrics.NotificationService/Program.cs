using System;
using Google.Protobuf;
using PiggyMetrics.Common;

namespace PiggyMetrics.NotificationService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            User u =new User();
            u.Account = "xuanye";
            u.Password = "password";

            string jsonStr =  JsonFormatter.Default.Format(u);
            Console.WriteLine(jsonStr);
            var user2 = User.Descriptor.Parser.ParseJson(jsonStr);
            if( u.Equals(user2) )
            {
                Console.WriteLine("前后一致");
            }
        }
    }
}
