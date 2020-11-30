using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAMLCore.Model
{
    //use constant Size small medium
    public class Parcel
    {
        //get Guid Auto Gen
        public int OrderNumber { get; set; }
        public int ParcelNumber { get; set; }
        public double MaxDimension { get; set; }
        public double Weight { get; set; }
        public double DeliveryCost { get; set; }
        //should set as a string (small, medium, etc if occurs -original price)
        public bool IsUsedInDiscount { get; set; }
        public string Size { get; set; }

        public Parcel(int parcelNumber,double maxDimension, double weight) {
            ParcelNumber = parcelNumber;
            MaxDimension = maxDimension;
            Weight = weight;

            GetParcelSize();
            GetParcelDeliveryCost();
        }
        
        public void GetParcelSize()
        {
            // should use switch 
            if (MaxDimension < 10)
            {
                //use constant of enum
                Size = "S";
                DeliveryCost = 3;
            }
            else if (MaxDimension < 50)
            {
                Size = "M";
                DeliveryCost = 8;
            }
            else if (MaxDimension < 100)
            {
                Size = "L";
                DeliveryCost = 15;
            }
            else if (MaxDimension >= 100)
            {
                Size = "XL";
                DeliveryCost = 25;
            }
        }
        public void GetParcelDeliveryCost()
        {
            var weight = new Dictionary<string, double>();
            //use constant of enum
            weight.Add("S", 1);
            weight.Add("M", 3);
            weight.Add("L", 6);
            weight.Add("XL", 10);
            
            //over weight
            if (Weight > 50)
            {
                DeliveryCost = 50 + Weight - 50;
            }
            else if (Weight >  weight[Size])
            {
                var cost = DeliveryCost;
                //need to round to closest
                DeliveryCost = DeliveryCost + 2 * (int)(Weight - weight[Size]);
            }
        }
    }
}
