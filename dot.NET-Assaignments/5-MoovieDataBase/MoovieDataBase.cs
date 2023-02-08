using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Assaignment_ConsoleApp;
using FrameWorksApp;
using System.IO;
using System.Xml.Serialization;

namespace Assaignment_ConsoleApp
{
    [Serializable]
    public  class MoovieClass
    {
        public int MoovieId { get; set; }
        public string MoovieName { get; set; }
        public string MoovieProduction { get; set; }
        public double MoovieRating { get; set; }
        public override string ToString()
        {
            return ($"{MoovieId}, {MoovieName}, {MoovieProduction}, {MoovieRating}\n");
        }
    }
    interface IMoovieMethods
    {
        void AddMoovie(MoovieClass data);
        void UpdateMoovie(MoovieClass data);
        void RemoveMoovie(int Id);
        void FindMoovie(int Id);
    }
    class MoovieRepo : IMoovieMethods
    {
        static List<MoovieClass> _moovieArray = new List<MoovieClass>();

        public void initializerFuns(List<MoovieClass> data)
        {
            _moovieArray = data;
            //Console.WriteLine("DEserialization successfull");
        }
        public void AddMoovie(MoovieClass data)
        {
            _moovieArray.Add(data);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Your Moovie {data.MoovieName} is added successfully");
            Console.ForegroundColor = ConsoleColor.Black;
            SerializerClass.PushData(_moovieArray);
            return;
        }
        public void exceptionManager()
        {
            if (_moovieArray.Count == 0)
            {
                throw new Exception("Please Add The Moovie First");
            }
            
        }
        public bool Confirmer(int id)
        {

            foreach (var item in _moovieArray)
            {
                if (item.MoovieId == id)
                {
                    return true;
                }
                  
            }
            throw new Exception("Moovie Id Not Found To Update");
           
        }

        public void UpdateMoovie(MoovieClass data)
        {
            foreach (var item in _moovieArray)
            {
                if (item.MoovieId == data.MoovieId)
                {
                    item.MoovieName = data.MoovieName;
                    item.MoovieProduction = data.MoovieProduction;
                    item.MoovieRating = data.MoovieRating;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Moovie {item.MoovieName} Updated Successfully");
                    Console.ForegroundColor = ConsoleColor.Black;
                    SerializerClass.PushData(_moovieArray);
                    return;
                }
            }
        }

        public void RemoveMoovie(int Id)
        {
            foreach (var item in _moovieArray)
            {
                if (item.MoovieId == Id)
                {
                    MoovieClass data = item;
                    _moovieArray.Remove(data);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Moovie Removed Successfully!!");
                    Console.ForegroundColor = ConsoleColor.Black;
                    SerializerClass.PushData(_moovieArray);
                    return;
                }

            }
            throw new Exception("Moovie ID not Found To Remove");
        }
        public void FindMoovie(int Id)
        {
            foreach (var item in _moovieArray)
            {

                if (item.MoovieId == Id)
                {
                    MoovieClass data = item;
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine($"Moovie Id:              {data.MoovieId}");
                    Console.WriteLine($"Moovie Name:            {data.MoovieName}");
                    Console.WriteLine($"Moovie Production:      {data.MoovieProduction}");
                    Console.WriteLine($"Moovie Rating:          {data.MoovieRating}");
                    Console.ForegroundColor = ConsoleColor.Black;
                    SerializerClass.PushData(_moovieArray);
                    return;
                }

            }
            throw new Exception("Moovie ID Not Found To Display");
        }
        public void ShowMoovies()
        {
            Console.WriteLine("___________________________________________________________________________");
            Console.WriteLine("******************************MOOVIE DATABASE******************************");
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("Moovie Id\tMoovie Name\tMoovie Production\tMoovie Rating");
            Console.WriteLine("---------------------------------------------------------------------------");

            foreach (var item in _moovieArray)
            {
                Console.WriteLine($"   {item.MoovieId}          {item.MoovieName}          {item.MoovieProduction}                {item.MoovieRating}");
            }
            Console.WriteLine("___________________________________________________________________________");
            SerializerClass.PushData(_moovieArray);
        }
        internal bool checkDuplicate(int id)
        {
            if(_moovieArray.Count == 0)
            {
                return true;
            }
            foreach (var item in _moovieArray)
            {
                if(item.MoovieId == id)
                {
                    throw new Exception("moovie Id Already Exists Try different");
                }
            }
            return true; 
        }
    }
    class SerializerClass
    {

        public static void PushData(List<MoovieClass> lists)
        {
            FileStream fs = new FileStream("Moovie_Database.xml", FileMode.Create, FileAccess.Write);
            XmlSerializer pusher = new XmlSerializer(typeof(List<MoovieClass>));
            pusher.Serialize(fs, lists);
            fs.Flush();
            fs.Close();
        }

        public static void GetData()
        {
            MoovieRepo obj = new MoovieRepo();
            List<MoovieClass> moovieList = null;
            if (!File.Exists("Moovie_Database.xml"))
            {
                FileStream fs = new FileStream("Moovie_Database.xml", FileMode.CreateNew, FileAccess.Write);
                fs.Close();
                return;
            }
            else
            {

                FileStream fs = new FileStream("Moovie_Database.xml", FileMode.Open, FileAccess.Read);
                XmlSerializer getter = new XmlSerializer(typeof(List<MoovieClass>));
                moovieList = getter.Deserialize(fs) as List<MoovieClass>;
                fs.Close();
                obj.initializerFuns(moovieList);
            }


        }
    }
    public class MoovieUIClass
    {
        static MoovieRepo obj;
        public static void DisplayMenu()
        {
            int choice = 0;
            obj = new MoovieRepo();
            Console.WriteLine("**********************Moovie DataBase**********************\n" +
                                    "1).---------Add Moovies------------------ > Press 1.\n" +
                                    "2).---------Update Moovie---------------- > Press 2.\n" +
                                    "3).---------remove Moovie---------------- > Press 3.\n" +
                                    "4).---------Find Moovie------------------ > Press 4.\n"+
                                    "5).---------Show All Moovies------------- > Press 5.\n");
        RETRY:
            choice = HelperClasses.GetNumber("Enter The Choice You Want to Perform");

            switch (choice)
            {
                case 1:
                    AddingMoovieManager();
                    break;
                case 2:
                    UpdateMoovieManger();
                    break;
                case 3:
                    RemoveMoovieManager();
                    break;
                case 4:
                    FindMoovieManager();
                    break;
                case 5:
                    ShowAllMoovieManager();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("invalid choice please enter valid Number");
                    Console.ForegroundColor = ConsoleColor.Black;
                    goto RETRY;
            }
        }
        private static void ShowAllMoovieManager()
        {
            SerializerClass.GetData();
            try
            {
                obj.exceptionManager();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.Black;
                HelperClasses.GetValue("Press Enter to Go For MENU");
                Console.Clear();

                DisplayMenu();
            }
            obj.ShowMoovies();
            HelperClasses.GetValue("Press Enter to Clear The Console");
            Console.Clear();
            DisplayMenu();
        }
        private static void FindMoovieManager()
        {
            SerializerClass.GetData();
            try
            {
                obj.exceptionManager();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.Black;
                HelperClasses.GetValue("Press Enter to Go For MENU");
                Console.Clear();

                DisplayMenu();
            }
        RETRY:
            int moovieId = HelperClasses.GetNumber("Enter the Moovie Id You Want to display");
            try
            {
                obj.FindMoovie(moovieId);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.Black;
            RETRY2:
                int choose = HelperClasses.GetNumber("Enter 8 for Retry    OR  Enter 9 for MENU");
                if (choose == 8)
                    goto RETRY;
                else if (choose == 9)
                {
                    Console.Clear();
                    DisplayMenu();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Choice   PLease Select Properly");
                    Console.ForegroundColor = ConsoleColor.Black;
                    goto RETRY2;
                }
            }
            HelperClasses.GetValue("Press Enter to Clear The Console");
            Console.Clear();
            DisplayMenu();
        }
        private static void RemoveMoovieManager()
        {
            SerializerClass.GetData();
            try
            {
                obj.exceptionManager();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.Black;
                HelperClasses.GetValue("Press Enter to Go For MENU");
                Console.Clear();
                DisplayMenu();
            }
        RETRY:
            int moovieId = HelperClasses.GetNumber("Enter the Moovie Id You Want to Remove");
            try
            {
                obj.RemoveMoovie(moovieId);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.Black;
            RETRY2:
                int choose = HelperClasses.GetNumber("Enter 8 for Retry    OR  Enter 9 for MENU");
                if (choose == 8)
                    goto RETRY;
                else if (choose == 9)
                {
                    Console.Clear();
                    DisplayMenu();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Choice   PLease Select Properly");
                    Console.ForegroundColor = ConsoleColor.Black;
                    goto RETRY2;
                }                
            }
            HelperClasses.GetValue("Press Enter to Clear The Console");
            Console.Clear();
            DisplayMenu();
        }
        private static void UpdateMoovieManger()
        {
            SerializerClass.GetData();
            try
            {
                obj.exceptionManager();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.Black;
                HelperClasses.GetValue("Press Enter to Go For MENU");
                Console.Clear();
                DisplayMenu();
            }
            RETRY:
            int moovieId = HelperClasses.GetNumber("Enter the Moovie Id You Want to Update");
            bool check = false;
            try
            {
                check = obj.Confirmer(moovieId);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.Black;
                RETRY2:
                int choose = HelperClasses.GetNumber("Enter 8 for Retry    OR  Enter 9 for MENU");
                if (choose == 8)
                    goto RETRY;
                else if (choose == 9)
                {
                    Console.Clear();
                    DisplayMenu();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Choice   PLease Select Properly");
                    Console.ForegroundColor = ConsoleColor.Black;
                    goto RETRY2;
                }
            }
            if (check == true)
            {
                string moovieName = HelperClasses.GetValue("Enter the Moovie Name");
                string moovieProduction = HelperClasses.GetValue("Enter the Production Name");
                RETRY1:
                double moovieRating = HelperClasses.GetDouble("Enter the Rating for the Moovie Between [1-5]");
                if (moovieRating > 0 && moovieRating <=5)
                {
                    var moovieObject = new MoovieClass { MoovieId = moovieId, MoovieName = moovieName, MoovieProduction = moovieProduction, MoovieRating = moovieRating };
                    obj.UpdateMoovie(moovieObject);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("enter the Number Between [1-5]");
                    Console.ForegroundColor = ConsoleColor.Black;
                    goto RETRY1;
                }
                HelperClasses.GetValue("Press Enter to Clear The Console");
                Console.Clear();
                DisplayMenu();
            }

        }
        private static void AddingMoovieManager()
        {
            SerializerClass.GetData();
            bool check = true;
            RETRY2:
            int moovieId = HelperClasses.GetNumber("Enter The Moovie Id");
            try
            {
                check = obj.checkDuplicate(moovieId);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.Black;
                goto RETRY2;
            }
            if (check == true)
            {               
                string moovieName = HelperClasses.GetValue("Enter the Moovie Name");
                string moovieProduction = HelperClasses.GetValue("Enter the Production Name");
            RETRY:
                double moovieRating = HelperClasses.GetDouble("Enter the Rating for the Moovie Between [1-5]");
                if (moovieRating > 0 && moovieRating <= 5)
                {
                    var moovieObject = new MoovieClass { MoovieId = moovieId, MoovieName = moovieName, MoovieProduction = moovieProduction, MoovieRating = moovieRating };
                    obj.AddMoovie(moovieObject);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("enter the Number Between [1-5]");
                    Console.ForegroundColor = ConsoleColor.Black;
                    goto RETRY;
                }
            }
            
            HelperClasses.GetValue("Press Enter to Clear The Console");
            Console.Clear();
            DisplayMenu();


        }
    }
    class MoovieDataBase
    {
        static void Main(string[] args)
        {
            MoovieUIClass.DisplayMenu();
        }
    }
}