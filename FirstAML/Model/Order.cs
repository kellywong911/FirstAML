using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstAMLCore.Model
{
    public class Order
    {
        //set auto gen ID in database
       public int orderNumber { get; set; }
       public string Shipping { get; set; }

        public List<Parcel> ParcelItem = new List<Parcel>();

        //use async task 
       public void AddParcel(Parcel parcel)
        {
            var item = ParcelItem.Any(x => x.ParcelNumber == parcel.ParcelNumber);
            if (item)
            {
                throw new Exception($"ParcelNumber {parcel.ParcelNumber} is already exist.");
            }
            ParcelItem.Add(parcel);
        }

       
       public void RemoveParcel(Parcel parcel)
        {
            var item = ParcelItem.Find(x => x.ParcelNumber == parcel.ParcelNumber);
            if (item != null)
            {
                ParcelItem.Remove(parcel);
            }
            else 
                throw new Exception($"{parcel.ParcelNumber} does not exists");
        }

        public double CalculateParcel()
        {
            var sum = 0.00;
            foreach (var item in ParcelItem)
            {
                sum += item.DeliveryCost;
            }
            //use Constant or enum
            if (Shipping == "Speedy")
            {
                sum = sum * 2;
            }
            return sum;
        }

        //sorry it's so messy, not working T^T
        public double ApplyDiscount()
        {
            //order
            var smallParcel = (int)ParcelItem.Select(x => x.Size == "S").Count()/4;
            var mediumParcel = (int)ParcelItem.Select(x => x.Size == "M").Count()/3;
            var mixParcel = (int)ParcelItem.Count/5;

            foreach (var item in ParcelItem)
            {
                var sItem = 1;
                var mItem = 1;
                var lItem = 1;
                var xlItem = 1;

                //do similar for the rest
                if (smallParcel > 0)
                {
                    if (item.Size == "S")
                    {
                        if (sItem == 4)
                        {
                            if (item.IsUsedInDiscount == false)
                            {
                                item.IsUsedInDiscount = true;
                                //should make a field for extra saying its discounted Item?
                                //and minus
                                item.DeliveryCost = 0;
                            }
                            sItem = 1;
                        }
                        else 
                            sItem++;
                    }
                }
            }

            return 0;
        }
    }
}
