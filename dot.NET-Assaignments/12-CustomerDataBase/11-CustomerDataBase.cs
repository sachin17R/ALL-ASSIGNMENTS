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
    public class CustomerClass
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerProduction { get; set; }
        public double CustomerRating { get; set; }
        public override string ToString()
        {
            return ($"{CustomerId}, {CustomerName}, {CustomerProduction}, {CustomerRating}\n");
        }
    }
    interface ICustomerMethods
    {
        void AddCustomer(CustomerClass data);
        void UpdateCustomer(CustomerClass data);
        void RemoveCustomer(int Id);
        void FindCustomer(int Id);
    }
    class CustomerRepo : ICustomerMethods
    {
        static List<CustomerClass> _CustomerArray = new List<CustomerClass>();

        public void initializerFuns(List<CustomerClass> data)
        {
            _CustomerArray = data;
            //Console.WriteLine("DEserialization successfull");
        }
        public void AddCustomer(CustomerClass data)
        {
            _CustomerArray.Add(data);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Your Customer {data.CustomerName} is added successfully");
            Console.ForegroundColor = ConsoleColor.Black;
            SerializerClass.PushData(_CustomerArray);
            return;
        }
        public void exceptionManager()
        {
            if (_CustomerArray.Count == 0)
            {
                throw new Exception("Please Add The Customer First");
            }

        }
        public bool Confirmer(int id)
        {

            foreach (var item in _CustomerArray)
            {
                if (item.CustomerId == id)
                {
                    return true;
                }

            }
            throw new Exception("Customer Id Not Found To Update");

        }

        public void UpdateCustomer(CustomerClass data)
        {
            foreach (var item in _CustomerArray)
            {
                if (item.CustomerId == data.CustomerId)
                {
                    item.CustomerName = data.CustomerName;
                    item.CustomerProduction = data.CustomerProduction;
                    item.CustomerRating = data.CustomerRating;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Customer {item.CustomerName} Updated Successfully");
                    Console.ForegroundColor = ConsoleColor.Black;
                    SerializerClass.PushData(_CustomerArray);
                    return;
                }
            }
        }

        public void RemoveCustomer(int Id)
        {
            foreach (var item in _CustomerArray)
            {
                if (item.CustomerId == Id)
                {
                    CustomerClass data = item;
                    _CustomerArray.Remove(data);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Customer Removed Successfully!!");
                    Console.ForegroundColor = ConsoleColor.Black;
                    SerializerClass.PushData(_CustomerArray);
                    return;
                }

            }
            throw new Exception("Customer ID not Found To Remove");
        }
        public void FindCustomer(int Id)
        {
            foreach (var item in _CustomerArray)
            {

                if (item.CustomerId == Id)
                {
                    CustomerClass data = item;
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.WriteLine($"Customer Id:              {data.CustomerId}");
                    Console.WriteLine($"Customer Name:            {data.CustomerName}");
                    Console.WriteLine($"Customer Production:      {data.CustomerProduction}");
                    Console.WriteLine($"Customer Rating:          {data.CustomerRating}");
                    Console.ForegroundColor = ConsoleColor.Black;
                    SerializerClass.PushData(_CustomerArray);
                    return;
                }

            }
            throw new Exception("Customer ID Not Found To Display");
        }
        public void ShowCustomers()
        {
            Console.WriteLine("___________________________________________________________________________");
            Console.WriteLine("******************************Customer DATABASE******************************");
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("Customer Id\tCustomer Name\tCustomer Production\tCustomer Rating");
            Console.WriteLine("---------------------------------------------------------------------------");

            foreach (var item in _CustomerArray)
            {
                Console.WriteLine($"   {item.CustomerId}          {item.CustomerName}          {item.CustomerProduction}                {item.CustomerRating}");
            }
            Console.WriteLine("___________________________________________________________________________");
            SerializerClass.PushData(_CustomerArray);
        }
        internal bool checkDuplicate(int id)
        {
            if (_CustomerArray.Count == 0)
            {
                return true;
            }
            foreach (var item in _CustomerArray)
            {
                if (item.CustomerId == id)
                {
                    throw new Exception("Customer Id Already Exists Try different");
                }
            }
            return true;
        }
    }
    class SerializerClass
    {

        public static void PushData(List<CustomerClass> lists)
        {
            FileStream fs = new FileStream("Customer_Database.xml", FileMode.Create, FileAccess.Write);
            XmlSerializer pusher = new XmlSerializer(typeof(List<CustomerClass>));
            pusher.Serialize(fs, lists);
            fs.Flush();
            fs.Close();
        }

        public static void GetData()
        {
            CustomerRepo obj = new CustomerRepo();
            List<CustomerClass> CustomerList = null;
            if (!File.Exists("Customer_Database.xml"))
            {
                FileStream fs = new FileStream("Customer_Database.xml", FileMode.CreateNew, FileAccess.Write);
                fs.Close();
                return;
            }
            else
            {

                FileStream fs = new FileStream("Customer_Database.xml", FileMode.Open, FileAccess.Read);
                XmlSerializer getter = new XmlSerializer(typeof(List<CustomerClass>));
                CustomerList = getter.Deserialize(fs) as List<CustomerClass>;
                fs.Close();
                obj.initializerFuns(CustomerList);
            }


        }
    }
    public class CustomerUIClass
    {
        static CustomerRepo obj;
        public static void DisplayMenu()
        {
            int choice = 0;
            obj = new CustomerRepo();
            Console.WriteLine("**********************Customer DataBase**********************\n" +
                                    "1).---------Add Customers------------------ > Press 1.\n" +
                                    "2).---------Update Customer---------------- > Press 2.\n" +
                                    "3).---------remove Customer---------------- > Press 3.\n" +
                                    "4).---------Find Customer------------------ > Press 4.\n" +
                                    "5).---------Show All Customers------------- > Press 5.\n");
        RETRY:
            choice = HelperClasses.GetNumber("Enter The Choice You Want to Perform");

            switch (choice)
            {
                case 1:
                    AddingCustomerManager();
                    break;
                case 2:
                    UpdateCustomerManger();
                    break;
                case 3:
                    RemoveCustomerManager();
                    break;
                case 4:
                    FindCustomerManager();
                    break;
                case 5:
                    ShowAllCustomerManager();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("invalid choice please enter valid Number");
                    Console.ForegroundColor = ConsoleColor.Black;
                    goto RETRY;
            }
        }
        private static void ShowAllCustomerManager()
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
            obj.ShowCustomers();
            HelperClasses.GetValue("Press Enter to Clear The Console");
            Console.Clear();
            DisplayMenu();
        }
        private static void FindCustomerManager()
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
            int CustomerId = HelperClasses.GetNumber("Enter the Customer Id You Want to display");
            try
            {
                obj.FindCustomer(CustomerId);
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
        private static void RemoveCustomerManager()
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
            int CustomerId = HelperClasses.GetNumber("Enter the Customer Id You Want to Remove");
            try
            {
                obj.RemoveCustomer(CustomerId);
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
        private static void UpdateCustomerManger()
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
            int CustomerId = HelperClasses.GetNumber("Enter the Customer Id You Want to Update");
            bool check = false;
            try
            {
                check = obj.Confirmer(CustomerId);
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
                string CustomerName = HelperClasses.GetValue("Enter the Customer Name");
                string CustomerProduction = HelperClasses.GetValue("Enter the Production Name");
            RETRY1:
                double CustomerRating = HelperClasses.GetDouble("Enter the Rating for the Customer Between [1-5]");
                if (CustomerRating > 0 && CustomerRating <= 5)
                {
                    var CustomerObject = new CustomerClass { CustomerId = CustomerId, CustomerName = CustomerName, CustomerProduction = CustomerProduction, CustomerRating = CustomerRating };
                    obj.UpdateCustomer(CustomerObject);
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
        private static void AddingCustomerManager()
        {
            SerializerClass.GetData();
            bool check = true;
        RETRY2:
            int CustomerId = HelperClasses.GetNumber("Enter The Customer Id");
            try
            {
                check = obj.checkDuplicate(CustomerId);
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
                string CustomerName = HelperClasses.GetValue("Enter the Customer Name");
                string CustomerProduction = HelperClasses.GetValue("Enter the Production Name");
            RETRY:
                double CustomerRating = HelperClasses.GetDouble("Enter the Rating for the Customer Between [1-5]");
                if (CustomerRating > 0 && CustomerRating <= 5)
                {
                    var CustomerObject = new CustomerClass { CustomerId = CustomerId, CustomerName = CustomerName, CustomerProduction = CustomerProduction, CustomerRating = CustomerRating };
                    obj.AddCustomer(CustomerObject);
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
    class CustomerDataBase
    {
        static void Main(string[] args)
        {
            CustomerUIClass.DisplayMenu();
        }
    }
}
