using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace ParkingLotSystem{
 public class Transaction{
     /*variable declarations*/
     private int fine;         //integer variable for fine to be added to fee
     private DateTime exitTime;//current system time used for the exit time 
     private TimeSpan entryTime;//time span variable used for exit time
     
     /*definition of public methods as used to access properties*/
     public TimeSpan EntryTime
     {
         get { return entryTime; }
         set { entryTime = value; }
     }
     public DateTime ExitTime
     {
         get { return exitTime; }
         set { exitTime = value; }
     }
    
     /*definition of the used time method*/
    public double UsedTime()
     {
        exitTime = DateTime.Now; //current system time        
        Console.Write("\n\tGet Entry Time In Format: '00:00:00' \t\t[        ]\b\b\b\b\b\b\b\b\b");
        entryTime = TimeSpan.Parse(Console.ReadLine());
        double totalTime = (double)(exitTime - entryTime).Hour;
        Console.WriteLine("\n\tEntry Time:  " + (entryTime) + "\n\tExit Time:  " + (exitTime) + "\n\tTotal Time:  " + totalTime);
        if(totalTime > 12.0)
        {
            Console.WriteLine("\tWARNING!! Time Is More Than A Day.. You Will Pay A Fine");
        }
        return totalTime; //return value for total time used
     }


     /*definition of discount method*/
     public double Isdiscount()
     {
         double discount = 0.0;
         string isDiscount;
         Console.Write("\n\tSpecial discount available?\n\t" + "Y: Yes, N: No \t\t\t\t\t[ ] \b\b\b");
         isDiscount = Convert.ToString(Console.ReadLine()); //discount in percentage
         switch (isDiscount)
         {
             case "y":
                 Console.Write("\tEnter Discount In %  \t\t\t   [   ]\b\b\b\b");
                 /* numerical validation */
                 while (!double.TryParse(Console.ReadLine(), out discount))
                 {
                     Console.WriteLine("Invalid! Discount Must Be A Number");
                     Console.Write("\tPlease Enter Discount In %  \t\t\t   [   ]\b\b\b\b");
                 }
                 Console.WriteLine("\tYou have given out a " + discount + "%  discount");
                 discount = discount / 100; //real value of discount
                 break;
             case "n":
                 Console.WriteLine("\tOk.. no special discount");
                 break;
         }
         return discount;
     }

     /*definition for the type of car*/
     public double TypeOfPayment()
     {
         double rate = 0.0; //fixed amout of rate for each hour of time
         double sRate = 5.0; //standard rate per hour
         double eRate = 6.4; //event rate per hour
         string paymentType; //character string to select the type of payment

         Console.Write("\n\tSelect type of payment:\n\t S: Standard Rate\n\t E: Event Rate\n\t\t\t\t\t    [ ]\b\b");
         paymentType = Convert.ToString(Console.ReadLine());
         switch (paymentType)
         {
             case "s":
                 Console.WriteLine("\tYou have selected a standard type of payment..");
                 rate = sRate;
                 break;
             case "e":
                 Console.WriteLine("\tYou have selected an event type of payment..");
                 rate = eRate;
                 break;
         }
         return rate; //returned anoumt of rate
     }

     /*definition for the fee calculation method*/
     public double CalculateFee(double totalTime, double discount, double rate) 
     {                       
         this.fine = 25;
         double totalAmount;
         totalAmount = totalTime * rate;
         discount = totalAmount * discount;
         totalAmount = totalAmount - discount;
         if (totalTime > 12) 
         {
             totalAmount = totalAmount + fine;
         }
         return totalAmount; //return of total amount calculated
     }
 }
}  	 

