using System;
using System.Collections.Generic;
using System.IO;

namespace FrameWorksApp
{
    class Patient
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public long PatientPhone { get; set; }
        public double BillAmount { get; set; }
        public override string ToString()
        {
            return ($"{PatientId},\t{PatientName},\t{PatientPhone},\t{BillAmount}\n");
        }
    }
    class FileOperator
    {
        static string filePath = "../../PatientData.csv";
        public static void startFunc()
        {
        RETRY:
            int id = HelperClasses.GetNumber("enter 1 for Add    2 for View");
            if (id == 1)
                Uploader();
            else if (id == 2)
                FileOperator.Receiver();
            else
            {
                Console.WriteLine("wrong selection try again");
                goto RETRY;
            }
        }
        public static void Uploader()
        {
            int id = HelperClasses.GetNumber("enter patient id");
            string name = HelperClasses.GetValue("enter the patient name");
            long num = HelperClasses.GetNumber("enter the phone number");
            double bill = HelperClasses.GetDouble("enter the bill amount");
            Patient data = new Patient { PatientId = id, PatientName = name, PatientPhone = num, BillAmount = bill };
            File.AppendAllText(filePath, data.ToString());
            Console.WriteLine("file Uploaded SuccessFully");
            HelperClasses.GetValue("press enter to clear console");
            Console.Clear();
            startFunc();
        }
        public static void Receiver()
        {
            List<Patient> allPatients = new List<Patient>();
            var alldata = File.ReadAllLines(filePath);
            foreach (var item in alldata)
            {
                var single = item.Split(',');
                Patient pat = new Patient();
                pat.PatientId = int.Parse(single[0]);
                pat.PatientName = single[1];
                pat.PatientPhone = long.Parse(single[2]);
                pat.BillAmount = double.Parse(single[3]);

                //Console.WriteLine($"P-Id     P-Name    P-Phone   P-Bill  ");
                allPatients.Add(pat);

            }
            //Console.WriteLine($"P-Id\t  P-Name \t    P-Phone\t   P-Bill");
            foreach (var item in allPatients)
            {
                Console.WriteLine(item.ToString());
            }
            HelperClasses.GetValue("press enter to clear the console");
            Console.Clear();
            startFunc();

        }
    }
    class PatientDataBase
    {
        static void Main(string[] args)
        {
            FileOperator.startFunc();
        }
    }
}
