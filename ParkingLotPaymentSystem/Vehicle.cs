using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace ParkingLotSystem{
    /*the vehicle structure*/
    public struct Vehicle{
        private string name;      //name given to the vehicle type
        private double amountPerHour; //amount for first hour used for parking
        private double additionalAmountPerHour; //additional amount charged for each hour after the first
        /*definition of public methods as used to access properties*/
        public string Name
        {
            get{ return name; }
            set{ name = value; }
        }       
        public double AmountPerHour
        {
            get{ return amountPerHour; }
            set{ amountPerHour = value; }
        }        
        public double AdditionalAmountPerHour
        {
            get { return additionalAmountPerHour; }
            set { additionalAmountPerHour = value; }
        }
        /* Constructor for vehicle structure*/
        public Vehicle(string _name, double _amountPerHour, double _additionalAmountPerHour)
        {
            name = _name;
            amountPerHour = _amountPerHour;
            additionalAmountPerHour = _additionalAmountPerHour;
        }
    }
}