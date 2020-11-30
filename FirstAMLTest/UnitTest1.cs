using FirstAMLCore.Model;
using System;
using Xunit;

namespace FirstAMLTest
{
    public class UnitTest1
    {
        [Fact]
        public void TestItems()
        {
            var order = new Order() { Shipping = "Speedy" };
            var parcel = new Parcel(1232131, 12, 5);
            var parcel2 = new Parcel(12321232, 7, 3);

            order.AddParcel(parcel);
            order.AddParcel(parcel2);

            var orderTotal = order.CalculateParcel();
            Assert.Equal(38, orderTotal);
        }

        [Fact]
        public void TestOverWeightItem()
        {
            var order = new Order() { Shipping = "Speedy" };
            var parcel = new Parcel(1232131, 12, 55);

            order.AddParcel(parcel);

            var orderTotal = order.CalculateParcel();
            Assert.Equal(110, orderTotal);
        }
    }
}
