using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDMS;

namespace TDMSforBRIO
{
    class Program
    {
        static void Main(string[] args)
        {

            TDMSApplication myapp = new TDMSApplication();

            if (!myapp.IsLoggedIn) {
                myapp.Login("sysadmin", "", "kosmos", @"192.168.16.8\tdmsserver");
            }



            Console.WriteLine(myapp.CurrentUser.Description);
            Console.ReadKey();
            myapp.Quit();
        }
    }
}
