using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace ParkingLotSystem{
    /* the write record class*/
    public class WriteRecord{
        /*Print record method definition*/
        public void PrintRecord(double _usedTime, double _amountDue ) 
        {
            Transaction tr = new Transaction(); //creating a new transaction object tr
            /*using is used to aid in releaseing I/O resources automatically after we have finished using it*/
            using(StreamWriter writer = new StreamWriter("C:/Users/iczcool/Desktop/Seng prj/writeRecord.txt", true))
            {
                writer.Write(DateTime.Now + "\n");
                writer.Write("Used Time: \t" + _usedTime + "\n");
                writer.Write("Amount due: \t" + _amountDue + "\n\n");
            }
        }
    }
}
