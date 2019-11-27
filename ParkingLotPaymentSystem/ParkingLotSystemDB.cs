using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Finisar.SQLite;
namespace ParkingLotSystem{
    public class ParkingLotSystemDB{
        /*variable declarations*/
        private SQLiteDataReader mydatareader = null;
        private SQLiteCommand mycmd = new SQLiteCommand();
        private SQLiteConnection myconn;
        public string cnn = "Data Source=C:/Users/iczcool/Desktop/Seng prj/Test/Test/bin/Debug/database.db;Version=3;New=False;Compress=False;"; //path to database file

        /*definition of AddClient method*/
        public void AddClient()
        {
            myconn = new SQLiteConnection(cnn); //new connection object
            myconn.Open();
            mycmd = myconn.CreateCommand();
            Console.Write("\n\n\t\tHow many clients do you want to register?\t[ ]\b\b");
            int numOfClients = 0;
            /* numerical validation */
            while (!int.TryParse(Console.ReadLine(), out numOfClients))
            {
                Console.WriteLine("\t\tInvalid!! Must Be A Number");
                Console.Write("\n\n\t\tPlease How Many Clients Do You Want To Register?[ ]\b\b");
            }
            /*for loop to control number of clients to be added*/
            for (int i = 1; i <= numOfClients; i++) 
            {
                Console.Write("\n\n\t\tClient {0}'s ID is: \t\t\t\t[   ]\b\b\b\b", i);
                int id = 0;
                /* numerical validation */
                while (!int.TryParse(Console.ReadLine(), out id))
                {
                    Console.WriteLine("\t\tInvalid! ID Must Be A Number");
                    Console.Write("\n\n\t\tEnter Client {0}'s ID: \t\t\t\t[   ]\b\b\b\b", i);
                }
                Console.Write("\n\n\t\tClient {0}'s Name is:   \t\t\t[                   ]\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b", i);
                string name = Console.ReadLine();
                /*input validation*/
                while (string.IsNullOrWhiteSpace(name)) 
                {
                    Console.Write("\t\tYou Hit A Wrong Key Or Must Not Include Number!");
                    Console.Write("\n\n\t\tPlease Enter {0}'s Name : \t\t[                   ]\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b", i);
                    name = Console.ReadLine();
                }
                /*getting the parking period*/
                Console.Write("\n\n\t\tClient {0}'s Parking Period is:\t\t\t[         ]\b\b\b\b\b\b\b\b\b\b", i);
                string parkingperiod = Console.ReadLine();
                /*input validation*/
                while (string.IsNullOrWhiteSpace(parkingperiod))
                {
                    Console.WriteLine("\t\tParking Period Is Not Valid!");
                    Console.Write("\n\n\t\tPlease Enter Client {0}'s Parking Period:   [         ]\b\b\b\b\b\b\b\b\b\b", i);
                    parkingperiod = Console.ReadLine();
                }
                /*gettint the type of vehicle*/
                Console.Write("\n\n\t\tClient {0}'s Vehicle is:         \t\t[    ]\b\b\b\b\b", i);
                string vehicle = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(vehicle))
                {
                    Console.WriteLine("\t\tInvalid Input!");
                    Console.Write("\n\n\t\tPlease Enter Client {0}'s Vehicle: \t\t[    ]\b\b\b\b\b", i);
                    vehicle = Console.ReadLine();
                }

                /*gettint the entry time*/
                Console.Write("\n\n\t\tClient {0}'s Entry Time is: \t\t[            ]\b\b\b\b\b\b\b\b\b\b\b\b\b", i);
                string entrytime = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(entrytime))
                {
                    Console.WriteLine("\t\tInvalid Input!");
                    Console.Write("\n\n\t\tPlease Enter Client {0}'s Entry Time: \t\t[            ]\b\b\b\b\b\b\b\b\b\b\b\b\b", i);
                    entrytime = Console.ReadLine();
                }
                /*command to insert into database*/
                var addClient = String.Format("INSERT INTO clients ([ID], [Name], [Parking_Period], [Vehicle], [Entry_Time])" +
                                             "VALUES ('{0}','{1}','{2}','{3}','{4}')", id, name, parkingperiod, vehicle, entrytime);
                mycmd.CommandText = addClient;
                mycmd.ExecuteNonQuery();
            }
            myconn.Close(); //close the database connection
        }

        /*definition for SelectClient method*/
        public void SelectClient() 
        {

                Console.Write("\n\n\t\tPlease Enter An ID Number: [   ]\b\b\b\b");
                int id = 0;
                /*input validation*/
                while (!int.TryParse(Console.ReadLine(), out id))
                {
                    Console.WriteLine("\t\tInvalid! ID Must Be A Number..");
                    Console.Write("\n\n\t\tPlease Enter An ID Number: [   ]\b\b\b\b");
                }
                /*command to perform database selection*/
                var selectClient = String.Format("SELECT * FROM clients" +
                                         " WHERE [ID] = '{0}'", id);
                myconn = new SQLiteConnection(cnn);
                myconn.Open();
                mycmd = myconn.CreateCommand();
                mycmd.CommandText = selectClient;
                mycmd.ExecuteNonQuery();
                mydatareader = mycmd.ExecuteReader();
                /*while loop to read and display all the data on a row*/
                while (mydatareader.Read())
                {
                    Console.WriteLine();
                    Console.Write("\n\n\n");
                    Console.Write("\t-------------------------------------------------------------\n\n");
                    Console.Write("\t\t");
                    Console.Write(mydatareader["ID"]);
                    Console.Write("\t");
                    Console.Write(mydatareader["Name"]);
                    Console.Write("\t");
                    Console.Write(mydatareader["Parking_Period"]);
                    Console.Write("\t");
                    Console.Write(mydatareader["Vehicle"]);
                    Console.Write("\t");
                    Console.Write(mydatareader["Entry_Time"]);
                    Console.Write("\n\n\t-------------------------------------------------------------");
                }
                myconn.Close(); //close the database connection
            }
            
           
        

        /*the View client method*/
        public void ViewAllClients()
        {
            var viewAllClients = "SELECT * FROM clients"; //select command to query database
            myconn = new SQLiteConnection(cnn); //create a new connection object
            try
            {               
                myconn.Open(); //open connection
                mycmd = myconn.CreateCommand();
                mycmd.CommandText = viewAllClients; 
                mycmd.ExecuteNonQuery();
                mydatareader = mycmd.ExecuteReader();
                Console.WriteLine("\n\n");
                Console.WriteLine(
      "ID             NAME         PARKING PPERIOD     ENTRY TIME          VEHICLE");
                Console.WriteLine(
    "---      ---------------    -------------       -------------     -------------");
                /*while loop to read and display all the data on a row*/
                while (mydatareader.Read())
                {
                    /*getting the results of each column*/
                    Int64 _id = (Int64)mydatareader["ID"];
                    string _name = (string)mydatareader["Name"];
                    string _parkingperiod = (string)mydatareader["Parking_Period"];
                    string _vehicle = (string)mydatareader["Vehicle"]; 
                    string _entrytime = (string)mydatareader["Entry_Time"];

                    /* printing out the results */
                    Console.Write("{0,-10}", mydatareader["ID"]);
                    Console.Write("{0,-20}", _name);
                    Console.Write("{0,-40}", _parkingperiod);
                    Console.Write("{0,-60}", _vehicle);
                    Console.Write("{0,-100}", _entrytime);
                    Console.WriteLine();
                }
            }
            finally
            {
                //close the reader
                if (mydatareader != null)
                {
                    mydatareader.Close();
                }

                //close the connection
                if (myconn != null)
                {
                    myconn.Close();
                }
            }
        } 
        	

        /*definition of Udate Client method*/
        public void UpdateClient()
        {
            myconn = new SQLiteConnection(cnn);
            myconn.Open();

            Console.Write("\n\t\tWhat Are You Updating? \n\t\t N:Name \n\t\t P: Parking Period \n\t\t V: Vehicle \n\t\t T: Entry Time \n\t\t [ ]\b\b");
            string updatetype = Console.ReadLine();
            /*input validation to update either name, parking period, vehicle or entry time*/
            while (((updatetype != "n") && (updatetype != "p") && (updatetype != "v") && (updatetype != "t")) && ((updatetype != "N") && (updatetype != "P") && (updatetype != "V") && (updatetype != "T")))
            {
                Console.WriteLine("\n\t\tInvalid Selection For Update!!");
                Console.Write("\n\t\tWhat Are You Updating? \n\t\t N:Name \n\t\t P: Parking Period \n\t\t V: Vehicle \n\t\t T: Entry Time \n\t\t [ ]\b\b");
                updatetype = Console.ReadLine();
            }

            if ((updatetype == "N") || (updatetype == "n"))
            {
                Console.Write("\n\n\t\tEnter Existing ID: [   ]\b\b\b\b");
                int id = 0;
                /*input validation*/
                while (!int.TryParse(Console.ReadLine(), out id))
                {
                    Console.WriteLine("\n\n\t\tInvalid! ID Must Be A Mumber..");
                    Console.Write("\t\tPlease Enter Existing ID: [   ]\b\b\b\b");
                }
                Console.Write("\n\t\tEnter Existing Parking Period: [                   ]\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b");
                string parkingperiod = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(parkingperiod))
                {
                    Console.WriteLine("\n\n\t\tInvalid!");
                    Console.Write("\n\t\tEnter Existing Parking Period: [                   ]\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b");
                    parkingperiod = Console.ReadLine();
                }

                Console.Write("\n\t\tEnter Existing Vehicle: [    ]\b\b\b\b\b");
                string vehicle = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(vehicle))
                {
                    Console.WriteLine("\n\n\t\tInvalid!");
                    Console.Write("\n\t\tEnter Existing Vehicle: [    ]\b\b\b\b\b");
                    vehicle = Console.ReadLine();
                }

                Console.Write("\n\t\tEnter Existing Entry Time: [            ]\b\b\b\b\b\b\b\b\b\b\b\b\b");
                string entrytime = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(entrytime))
                {
                    Console.WriteLine("\n\n\t\tInvalid!");
                    Console.Write("\n\t\tEnter Existing Entry Time: [            ]\b\b\b\b\b\b\b\b\b\b\b\b\b");
                    entrytime = Console.ReadLine();
                }

                Console.Write("\n\t\tEnter new Name: [                   ]\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b");
                string name = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("\n\n\t\tInvalid!");
                    Console.Write("\n\t\tEnter new Name: [                   ]\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b");
                    name = Console.ReadLine();
                }

                var updateClient = String.Format("UPDATE clients SET [Name]='{0}' WHERE [ID]='{1}' and [Parking_Period]='{2}' and [Vehicle]='{3}' and [Entry_Time]='{4}'", name, id, parkingperiod, vehicle, entrytime);
                mycmd = myconn.CreateCommand();
                mycmd.CommandText = updateClient;
                mycmd.ExecuteNonQuery();
            }

            else if ((updatetype == "P") || (updatetype == "p"))
            {
                Console.Write("\n\t\tEnter Existing Name: [                   ]\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b");
                string name = Console.ReadLine();
                Console.Write("\n\t\tEnter Existing ID: [   ]\b\b\b\b");
                int id = 0;
                while (!int.TryParse(Console.ReadLine(), out id))
                {
                    Console.WriteLine("\n\n\t\tInvalid! ID Must Be A Number..");
                    Console.Write("\t\tPlease Enter Existing ID: [   ]\b\b\b\b");
                }
                Console.Write("\n\t\tEnter Existing Vehicle: [    ]\b\b\b\b\b");
                string vehicle = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(vehicle))
                {
                    Console.WriteLine("\n\n\t\tInvalid!");
                    Console.Write("\n\t\tEnter Existing Vehicle: [    ]\b\b\b\b\b");
                    vehicle = Console.ReadLine();
                }

                Console.Write("\n\t\tEnter Existing Entry Time: [            ]\b\b\b\b\b\b\b\b\b\b\b\b\b");
                string entryrime = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(entryrime))
                {
                    Console.WriteLine("\n\n\t\tInvalid!");
                    Console.Write("\n\t\tEnter Existing Entry Time: [            ]\b\b\b\b\b\b\b\b\b\b\b\b\b");
                    entryrime = Console.ReadLine();
                }

                Console.Write("\t\tEnter New Parking Period: [         ]\b\b\b\b\b\b\b\b\b\b");
                string parkingperiod = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(parkingperiod))
                {
                    Console.WriteLine("\n\n\t\tInvalid!");
                    Console.Write("\t\tEnter New Parking Period: [         ]\b\b\b\b\b\b\b\b\b\b");
                    parkingperiod = Console.ReadLine();
                }

                var updateClient = String.Format("UPDATE clients SET [Parking_Period]='{0}' WHERE [ID]='{1}' and [Name]='{2}' and [Vehicle]='{3}' and [Entry_Time]='{4}'", parkingperiod, id, name, vehicle, entryrime);
                mycmd = myconn.CreateCommand();
                mycmd.CommandText = updateClient;
                mycmd.ExecuteNonQuery();
            }

            else if ((updatetype == "V") || (updatetype == "v"))
            {
                Console.Write("\n\t\tEnter Existing Name: [                   ]\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b");
                string name = Console.ReadLine();
                Console.Write("\n\t\tEnter Existing ID: [   ]\b\b\b\b");
                int id = 0;
                while (!int.TryParse(Console.ReadLine(), out id))
                {
                    Console.WriteLine("\n\n\t\tInvalid! ID Must Be A Number..");
                    Console.Write("\t\tPlease Enter Existing ID: [   ]\b\b\b\b");
                }
                Console.Write("\n\t\tEnter Existing Parking Period: [         ]\b\b\b\b\b\b\b\b\b\b");
                string parkingperiod = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(parkingperiod))
                {
                    Console.WriteLine("\n\n\t\tInvalid!");
                    Console.Write("\n\t\tEnter Existing Parking Period: [         ]\b\b\b\b\b\b\b\b\b\b");
                    parkingperiod = Console.ReadLine();
                }

                Console.Write("\n\t\tEnter Existing Entry Time: [            ]\b\b\b\b\b\b\b\b\b\b\b\b\b");
                string entrytime = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(entrytime))
                {
                    Console.WriteLine("\n\n\t\tInvalid!");
                    Console.Write("\n\t\tEnter Existing Entry Time: [            ]\b\b\b\b\b\b\b\b\b\b\b\b\b");
                    entrytime = Console.ReadLine();
                }

                Console.Write("\n\t\tEnter New Vehicle: [    ]\b\b\b\b\b");
                string vehicle = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(vehicle))
                {
                    Console.WriteLine("\n\n\t\tInvalid!");
                    Console.Write("\n\t\tEnter New Vehicle: [    ]\b\b\b\b\b");
                    vehicle = Console.ReadLine();
                }

                var updateClient = String.Format("UPDATE clients SET [Vehicle]='{0}' WHERE [ID]='{1}' and [Name]='{2}' and [Parking_Period]='{3}' and [Entry_Time]='{4}'", vehicle, id, name, parkingperiod, entrytime);
                mycmd = myconn.CreateCommand();
                mycmd.CommandText = updateClient;
                mycmd.ExecuteNonQuery();
            }

            else if ((updatetype == "T") || (updatetype == "t"))
            {
                Console.Write("\n\t\tEnter Existing Name: [                   ]\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b");
                string name = Console.ReadLine();
                Console.Write("\n\t\tEnter Existing ID: [   ]\b\b\b\b");
                int id = 0;
                while (!int.TryParse(Console.ReadLine(), out id))
                {
                    Console.WriteLine("\n\n\t\tInvalid! ID Must Be A Number..");
                    Console.Write("\t\tPlease Enter Existing ID: [   ]\b\b\b\b");
                }
                Console.Write("\n\t\tEnter Existing Parking Period: [         ]\b\b\b\b\b\b\b\b\b\b");
                string parkingperiod = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(parkingperiod))
                {
                    Console.WriteLine("\n\n\t\tInvalid!");
                    Console.Write("\n\t\tEnter Existing Parking Period: [         ]\b\b\b\b\b\b\b\b\b\b");
                    parkingperiod = Console.ReadLine();
                }

                Console.Write("\n\t\tEnter Existing Vehicle: [     ]\b\b\b\b\b\b");
                string vehicle = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(vehicle))
                {
                    Console.WriteLine("\n\n\t\tInvalid!");
                    Console.Write("\n\t\tPlease Enter Existing Vehicle: [     ]\b\b\b\b\b\b");
                    vehicle = Console.ReadLine();
                }

                Console.Write("\t\tEnter New Entry Time: [             ]\b\b\b\b\b\b\b\b\b\b\b\b\b\b");
                string entrytime = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(entrytime))
                {
                    Console.WriteLine("\n\n\t\tInvalid!");
                    Console.Write("\t\tPlease Enter New Entry Time: [             ]\b\b\b\b\b\b\b\b\b\b\b\b\b\b");
                    entrytime = Console.ReadLine();
                }
                /*command to perform update on the database*/
                var updateClient = String.Format("UPDATE clients SET [Entry_Time]='{0}' WHERE [ID]='{1}' and [Name]='{2}' and [Parking_Period]='{3}' and [Vehicle]='{4}'", entrytime, id, name, parkingperiod, vehicle);
                mycmd = myconn.CreateCommand();
                mycmd.CommandText = updateClient;
                mycmd.ExecuteNonQuery();
            }
            myconn.Close();/*close the connection*/
        }

        /* definition of Delete client method*/
        public void DeleteClient()
        {
            Console.Write("\n\n\t\tEnter An ID To Delete Client: [   ]\b\b\b\b");
            int id = 0;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("\n\n\t\tInvalid! ID Must Be A Number..");
                Console.Write("\t\tPlease Enter An ID To Delete Client: [   ]\b\b\b\b");
            }
            /*command to perform deletion*/
            var deleteClient = String.Format("DELETE FROM clients WHERE [ID]='{0}'", id);
            myconn = new SQLiteConnection(cnn);
            myconn.Open(); //open the connection
            mycmd = myconn.CreateCommand();
            mycmd.CommandText = deleteClient;
            mycmd.ExecuteNonQuery();
            myconn.Close(); //cloe the connection
        }
    }
}
