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
            #region create tdms application and login 
            TDMSApplication myapp = new TDMSApplication();

            if (!myapp.IsLoggedIn) {
                myapp.Login("sysadmin", "", "kosmos", @"192.168.16.8\tdmsserver");
            }

            #endregion

            #region get object_tom and files

            //подключаемся к объекту по GUID
            string GUID = "{49DFA37A-E760-4C83-A084-9C270A47DA39}";
            TDMSObject buildingObject = myapp.GetObjectByGUID(GUID);

            // получаем все Томы (object_tom) данного Объекта (object_object). Чертежи хранятся в файловом составе Томов
            // лучше создать ручную выборку для получения Томов в примере получение черерз метод ContentAll - сквозной состав объекта

            TDMSObjects toms = buildingObject.ContentAll.ObjectsByDef("OBJECT_TOM"); //метод ObjectsByDef позволяет во всей коллекции объектов осуществить фильтр по типу объекта

            TDMSObject firstTom = toms[0]; 
            TDMSFiles tomsFiles = firstTom.Files;
            TDMSFile firstFile = tomsFiles[0];

            firstFile.CheckOut(firstFile.WorkFileName);
            #endregion

            Console.ReadKey();
            myapp.Quit();
        }
    }
}
