using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace ParkingLotSystem
{

    /*implimentation of program, the main class*/
    public class Program
    {
        public static void Main(string[] args)
        {
            /*variable declarations*/
            double rate;              
            double discount;          // discount variable 
            double totalTime;         //total time used
            double amount = 0.0;      
            double amountDue = 0.0;   //represents fee calculated
            double amph = 0.0;        //constant amount/hour for each type of car
            double addamph = 0.0;     //constant additional amount/hour after the first hour
            string vehicle;           //string character to select the type of vehicle 
            string answer;            //control variable

            Transaction transact = new Transaction();        //instantiated transaction object
            WriteRecord wr = new WriteRecord();              //instantiated writerecord object
            ParkingLotSystemDB db = new ParkingLotSystemDB();//instantiated parkinglotsystemdb
            Console.WriteLine("\t\t========== PARKING LOT CASHIER ==========");
            Console.WriteLine("\n\t\tSelect An Operation\n");
            Console.Write("\t\tM: Manage Payment C: Client Operation\t\t[ ]\b\b");
            string operation = Console.ReadLine();   //control variable to seclet an operation at main prompt
            /*manage payment operation selection*/
            if (operation == "m")
            {
                /*do loop to control the fee operation*/
                do
                {
                    totalTime = transact.UsedTime();  //calling UsedTime function an assigning its value to totalTime
                    discount = transact.Isdiscount(); //calling Isdiscount function, assinging its value to discount
                    rate = transact.TypeOfPayment();  //calling  TypeOfPayment, assinging it to rate
                    amount = transact.CalculateFee(totalTime, discount, rate); //calling CalculateFee, assigning its value to amount
                    Console.WriteLine("\n\tSelect type of vehicle..  C: Car  V: Van  B: Bus  T: Truck");
                    vehicle = Convert.ToString(Console.ReadLine());
                    /*switch control to switch between the type of car object*/
                    switch (vehicle)
                    {
                        case "c":
                            Vehicle c = new Vehicle("Car", 6.0, 3.0); //instantiating new vehicle object c
                            Console.WriteLine("\tYou selected a " + c.Name);
                            amph = c.AmountPerHour;
                            addamph = c.AdditionalAmountPerHour;
                            if (totalTime == 1)
                            {
                                amountDue = amount + amph;
                            }
                            else if (totalTime > 1)
                            {
                                addamph = (totalTime * addamph) - addamph;
                                amountDue = amount + amph + addamph;
                            }
                            Console.WriteLine("\t\t=========================================");
                            Console.WriteLine("\n\t\t\tTotal Fee: " + amountDue + "euros");
                            Console.WriteLine("\n\t\t==========================================");
                            break;
                        case "v":
                            Vehicle v = new Vehicle("Van", 6.5, 3.2);  //instantiating new vehicle object v
                            Console.WriteLine("\tYou selected a " + v.Name);
                            amph = v.AmountPerHour;
                            addamph = v.AdditionalAmountPerHour;
                            if (totalTime == 1)
                            {
                                amountDue = amount + amph;
                            }
                            else if (totalTime > 1)
                            {
                                addamph = (totalTime * addamph) - addamph;
                                amountDue = amount + amph + addamph;
                            }
                            Console.WriteLine("\t\t=========================================");
                            Console.WriteLine("\n\t\t\tTotal Fee: " + amountDue + "euros");
                            Console.WriteLine("\n\t\t==========================================");
                            break;
                        case "b":
                            Vehicle b = new Vehicle("Bus", 7.0, 3.8);   //instantiating new vehicle object b
                            Console.WriteLine("\tYou selected a " + b.Name);
                            amph = b.AmountPerHour;
                            addamph = b.AdditionalAmountPerHour;
                            if (totalTime == 1)
                            {
                                amountDue = amount + amph;
                            }
                            else if (totalTime > 1)
                            {
                                addamph = (totalTime * addamph) - addamph;
                                amountDue = amount + amph + addamph;
                            }
                            Console.WriteLine("\t\t=========================================");
                            Console.WriteLine("\n\t\t\tTotal Fee: " + amountDue + "euros");
                            Console.WriteLine("\n\t\t==========================================");
                            break;
                        case "t":
                            Vehicle t = new Vehicle("Truck", 10.0, 4.0);   //instantiating new vehicle object t
                            Console.WriteLine("\tYou selected a " + t.Name);
                            amph = t.AmountPerHour;
                            addamph = t.AdditionalAmountPerHour;
                            if (totalTime == 1)
                            {
                                amountDue = amount + amph;
                            }
                            else if (totalTime > 1)
                            {
                                addamph = (totalTime * addamph) - addamph;
                                amountDue = amount + amph + addamph;
                            }
                            Console.WriteLine("\t\t=========================================");
                            Console.WriteLine("\n\t\t\tTotal Fee: " + amountDue + "euros");
                            Console.WriteLine("\n\t\t==========================================");
                            break;
                    }
                    wr.PrintRecord(totalTime, amountDue);  //calling PrintRecord method to write the record to a file
                    Console.Write("\n\t\tDo You Want To Manage Another Payment?");
                    Console.Write("\n\t\tY: Yes N: No \t\t[ ]\b\b");
                    answer = Console.ReadLine();
                } while (answer == "y");
                if (answer == "n")
                    Console.WriteLine("\n\n\t\tOk Then, Bye!");
                else{
                     Console.WriteLine("\n\t\tYou Hit The Wrong Key.. Program Will End!");   
                    }
            }


               /*Client operations selection*/
            else if (operation == "c")
            {
                Console.Write("\n\t\tWhat Do You Want To Do?");
                Console.Write("\n\t\tV: View Client\n\t\tA: Add Client\n\t\tD: Delete Client\n\t\tU: Update Client\n\t\tP: Preview All Clients\t\t[ ]\b\b");
                string clientOperation = Console.ReadLine();
                /*switching between the type of operation*/
                switch (clientOperation)
                {
                    case "v":
                        db.SelectClient();   //view client information
                        break;
                    case "a":
                        db.AddClient();      //add a new client to the system
                        break;
                    case "d":
                        db.DeleteClient();   //delete existing client from the system
                        break;
                    case "u":
                        db.UpdateClient();   //update an existing client in the system
                        break;
                    case "p":
                        db.ViewAllClients(); //preview all the clients on the system
                        break;
                }
            }            
                Console.ReadKey();//read any key to end the program
            }
        }
    }


