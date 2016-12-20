
using System.Collections.Generic;


namespace DataContainer
{
    //datacontainer is called Class1
    public class Class1
    {
        private static Class1 instance = null;

        private Class1() { }

        private List<RentalDetails> RDetails = new List<RentalDetails>();

        private List<Booking> BDetails = new List<Booking>();

        public List<RentalDetails> GetList()
        {

            return RDetails;
        }

        public void SetList(RentalDetails L)
        {

            RDetails.Add(L);

        }

        public List<Booking> GetBList()
        {

            return BDetails;
        }

        public void SetBList(Booking D)
        {

            BDetails.Add(D);

        }
        public static Class1 Instance()
        {

            if (instance == null)
            {
                instance = new Class1();
            }
            return instance;
        }


    }

    //different class

    public class RentalDetails
    {
        public int key { get; set; }
        public string CustomerName { get; set; }
        
        public string CarType { get; set; }
                
        public int Distance { get; set; }

        public int Duration { get; set; }

        public double GrossFare { get; set; }

        public double NetFare { get; set; }

    }

    public class Booking
    {
        public int key { get; set; }
        public string CustomerName { get; set; }

        public string CarType { get; set; }

        public string CarMake { get; set; }

        public string CarModel { get; set; }

        
    }

}
