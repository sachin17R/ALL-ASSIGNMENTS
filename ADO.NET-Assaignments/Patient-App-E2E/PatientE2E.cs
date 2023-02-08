using ADOConsoleApp.E2E_App;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOConsoleApp.E2E_App
{
    class PatientAppE2E
    {
        public string PatientName { get; set; }
        public string PatientAddress { get; set; }
        public int BillAmount { get; set; }
        public int DoctorId { get; set; }

    }
    class DoctorsData
    {
        public string DoctroName { get; set; }
        public string Specialization { get; set; }
    }

    interface ICRUDonE2E
    {
        void FetchSingle(int id);
        void FetchAllData();
        void Insertdata(PatientAppE2E obj);
        void UpdateData(PatientAppE2E obj, int id);
        void RemovePatient(int id);
    }

    class RepoPatient : ICRUDonE2E
    {
        #region
        const string STRCONNECTION = "Data Source=192.168.171.36;Initial Catalog=3338;Integrated Security=True";
        const string SINGLECMD = "select * from tblPatient Where PatientId = @patientId";
        const string AllDataFetch = "select * from tblPatient";
        const string INSERTDATA = "insert into tblPatient Values(@name,@Address,@Bill,@Doctorid)";
        const string IdChecker = "select * from tblPatient Where PatientId = @id";
        const string UPDATESTR = "update tblPatient set PatientName = @name1,PatientAddress = @address1,BillAmount = @bill where PatientId = @id1";
        const string DoctorsData = "Select * from tblDoctors Where DoctorId = @docid";
        const string ALLDOCTORS = "select * from tblDoctors";
        const string REMOVEPATIENT = "delete from tblPatient where PatientId = @PatId";
        const string ADDNEWDOCTOR = "insert into tblDoctors values(@dname,@special)";
        #endregion
        public void FetchAllData()
        {
            SqlConnection conn = new SqlConnection(STRCONNECTION);
            SqlCommand cmd = new SqlCommand(AllDataFetch, conn);
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"Patient Id :{reader[0]}");
                    Console.WriteLine($"Patient Name :{reader[1]}");
                    Console.WriteLine($"Patient Address :{reader[2]}");
                    Console.WriteLine($"Bill Amount :{reader[3]}");
                    Console.WriteLine($"DoctorID :{reader[4]}");
                    doctorDataFetcher((int)reader[4]);
                    Console.WriteLine();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        public void RemovePatient(int id)
        {
            SqlConnection conn = new SqlConnection(STRCONNECTION);
            SqlCommand cmd = new SqlCommand(REMOVEPATIENT, conn);
            cmd.Parameters.AddWithValue("@PatId", id);
            conn.Open();
            var reader = cmd.ExecuteReader();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Patient Removed Successfully");
            Console.ForegroundColor = ConsoleColor.Black;
            conn.Close();
        }
        public void FetchSingle(int id)
        {
            int doc = 0;
            SqlConnection con = new SqlConnection(STRCONNECTION);
            SqlCommand cmd = new SqlCommand(SINGLECMD, con);
            try
            {

                cmd.Parameters.AddWithValue("@patientId", id);
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"Patient Id :{reader[0]}");
                    Console.WriteLine($"Patient Name :{reader[1]}");
                    Console.WriteLine($"Patient Address :{reader[2]}");
                    Console.WriteLine($"Bill Amount :{reader[3]}");
                    Console.WriteLine($"DoctorID :{reader[4]}");
                    doc = (int)reader[4];
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();

                doctorDataFetcher(doc);
            }

        }

        private void doctorDataFetcher(int docid)
        {
            SqlConnection conn = new SqlConnection(STRCONNECTION);
            SqlCommand cmd = new SqlCommand(DoctorsData, conn);
            cmd.Parameters.AddWithValue("@docid", docid);
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"Doctor Name: {reader[1]} \nSpecialization: {reader[2]}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void Insertdata(PatientAppE2E obj)
        {
            SqlConnection connec = new SqlConnection(STRCONNECTION);
            SqlCommand cmd = new SqlCommand(INSERTDATA, connec);
            cmd.Parameters.AddWithValue("@name", obj.PatientName);
            cmd.Parameters.AddWithValue("@address", obj.PatientAddress);
            cmd.Parameters.AddWithValue("@Bill", obj.BillAmount);
            cmd.Parameters.AddWithValue("@Doctorid", obj.DoctorId);

            try
            {
                connec.Open();
                var rowAffect = cmd.ExecuteNonQuery();
                if (rowAffect != 1)
                {
                    Console.WriteLine(" data not inserted");
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Patient Added Successfully");
                Console.ForegroundColor = ConsoleColor.Black;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connec.Close();
            }
        }

        public void UpdateData(PatientAppE2E obj, int id)
        {
            SqlConnection con = new SqlConnection(STRCONNECTION);
            SqlCommand cmd = new SqlCommand(UPDATESTR, con);
            cmd.Parameters.AddWithValue("@id1", id);
            cmd.Parameters.AddWithValue("@name1", obj.PatientName);
            cmd.Parameters.AddWithValue("@address1", obj.PatientAddress);
            cmd.Parameters.AddWithValue("@bill", obj.BillAmount);
            try
            {
                con.Open();
                var reader = cmd.ExecuteReader();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("data updated successfully");
                Console.ForegroundColor = ConsoleColor.Black;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        internal bool IdCHecking(int id)
        {
            SqlConnection conn = new SqlConnection(STRCONNECTION);
            SqlCommand cmd = new SqlCommand(IdChecker, conn);

            cmd.Parameters.AddWithValue("@id", id);
            conn.Open();
            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return true;
            }
            conn.Close();
            return false;
        }

        internal void doctorSelector()
        {
            SqlConnection con = new SqlConnection(STRCONNECTION);
            SqlCommand cmd = new SqlCommand(ALLDOCTORS, con);
            con.Open();
            var reader = cmd.ExecuteReader();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"Doctor Id\tDoctor Name\tSpeciality");
            Console.ForegroundColor = ConsoleColor.Black;

            while (reader.Read())
            {
                Console.WriteLine($"{reader[0]}\t\t{reader[1]}\t{reader[2]}");
            }
            con.Close();
        }

        internal void AddNewDoctor(DoctorsData data)
        {
            SqlConnection conn = new SqlConnection(STRCONNECTION);
            SqlCommand cmd = new SqlCommand(ADDNEWDOCTOR, conn);
            cmd.Parameters.AddWithValue("@dname", data.DoctroName);
            cmd.Parameters.AddWithValue("@special", data.Specialization);
            conn.Open();
            var reader = cmd.ExecuteReader();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Doctor Data Added Successfully");
            Console.ForegroundColor = ConsoleColor.Black;
            conn.Close();
        }

    }

    class UIPatientInfo
    {
        public static void DisplayMenu()
        {

            int choice = 0;
            Console.WriteLine($"****************PATIENT INFORMATION APP**************************\n\n" +

                                    "Add New Patient ------------------------------------->PRESS 1\n" +
                                    "Update Existing Patient ----------------------------->PRESS 2\n" +
                                    "Remove Patient -------------------------------------->PRESS 3\n" +
                                    "Fetch Single Patient -------------------------------->PRESS 4\n" +
                                    "Fetch All Patient ----------------------------------->PRESS 5\n" +
                                    "Add New Doctor -------------------------------------->PRESS 6\n" +
                                    "View All Doctors ------------------------------------>PRESS 7\n");
        RETRY2:
            choice = helper.Number("enter the choice you want to perform");
            if (choice == 1)
            {
                AddNewPatientManager();
            }
            else if (choice == 2)
            {
                UpdatePatientManager();
            }
            else if (choice == 3)
            {
                RemovePatientManager();
            }
            else if (choice == 4)
            {
                SinglePatientManager();
            }
            else if (choice == 5)
            {
                AllPatientManager();
            }
            else if (choice == 6)
            {
                AddNewDoctorManager();
            }
            else if (choice == 7)
            {
                ViewAllDoctors();
            }
            else
            {
                Console.WriteLine("wrong choice retry again");
                goto RETRY2;
            }
        }

        private static void ViewAllDoctors()
        {
            RepoPatient repo = new RepoPatient();
            repo.doctorSelector();
            helper.Text("press enter to clear the console");
            Console.Clear();
            DisplayMenu();
        }

        private static void AddNewDoctorManager()
        {
            RepoPatient repo = new RepoPatient();
            string name = helper.Text("Doctor Name with Prefix(Dr)");
            string Special = helper.Text("enter the speciality of Doctor");
            var data = new DoctorsData { DoctroName = name, Specialization = Special };
            repo.AddNewDoctor(data);
            helper.Text("press enter to clear the console");
            Console.Clear();
            DisplayMenu();
        }

        private static void RemovePatientManager()
        {
            RepoPatient repo = new RepoPatient();
            int id = helper.Number("enter the Patient Id u Want to Remove");
            repo.RemovePatient(id);
            helper.Text("press enter to clear the console");
            Console.Clear();
            DisplayMenu();
        }

        private static void UpdatePatientManager()
        {
            RepoPatient repo = new RepoPatient();
            int id = helper.Number("enter the Id you want to update");
            bool confirm = repo.IdCHecking(id);
            if (confirm == true)
            {
                string name = helper.Text("enter the name for update");
                string addtess = helper.Text("enter the address for update");
                int bill = helper.Number("enter the bill ");

                var data = new PatientAppE2E { PatientName = name, PatientAddress = addtess, BillAmount = bill };
                repo.UpdateData(data, id);
            }
            helper.Text("press enter to clear the console");
            Console.Clear();
            DisplayMenu();
        }

        private static void AddNewPatientManager()
        {
            RepoPatient repo = new RepoPatient();
            string name = helper.Text("enter patient name");
            string address = helper.Text("enter the address of the patient");
            int Bill = helper.Number("enter the bill amount");
            repo.doctorSelector();
            int docid = helper.Number("enter doctor id");
            var data = new PatientAppE2E { PatientName = name, PatientAddress = address, BillAmount = Bill, DoctorId = docid };

            repo.Insertdata(data);
            helper.Text("press enter to clear the console");
            Console.Clear();
            DisplayMenu();
        }

        private static void AllPatientManager()
        {
            RepoPatient repo = new RepoPatient();
            repo.FetchAllData();
            helper.Text("press enter to clear the console");
            Console.Clear();
            DisplayMenu();
        }

        private static void SinglePatientManager()
        {
            RepoPatient repo = new RepoPatient();

            int patientId = helper.Number("enter the patient Id ");
            repo.FetchSingle(patientId);
            helper.Text("press enter to clear the console");
            Console.Clear();
            DisplayMenu();
        }
    }


    class PatientMainClass
    {
        static void Main(string[] args)
        {
            UIPatientInfo.DisplayMenu();
        }
    }
}
