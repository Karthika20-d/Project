using System;
using System.Collections.Generic;


namespace Online_Real_Estate
{
    /*class LandRepositary
    {
        private static Dictionary<string, LandRepositary> propertyDetails = new Dictionary<string, LandRepositary>();
        private string propertyType;
        private short availability;
        private string area;
        private string location;
        internal void AddLandDetails(string propertyType, LandRepositary landRepositary)
        {
            propertyDetails.Add(propertyType, landRepositary);
        }
        internal void DisplayLandDetails(string role)
        {
            if (role == "Buyer")
            {

                Console.WriteLine("Available Properties and their information\n" + ToString());
                Admin.ViewSeller();
            }
            if (role == "Seller")
            {
                Console.WriteLine("Your Property Details\n" + ToString());
            }
        }
        internal LandRepositary(string propertyType)
        {
             
            if (propertyType == "Flats")
            {
                availability = 997;
                location = "Bangalore";
                area = "803 sqft";
            }
            if (propertyType == "Vila")
            {
                availability = 342;
                location = "Hyderabad";
                area = "2285 sqft";
            }
            if (propertyType == "Office space")
            {
                availability = 997;
                location = "Bangalore";
                area = "803 sqft";
            }
            if (propertyType == "Plots")
            {
                availability = 2760;
                location = "chennai";
                area = "2500 sqft";
            }

        }
        public override string ToString()
        {
            return "Property Type:" + propertyType + "\nNo Of Properties:" + availability + "\nArea space:" + area + "\nLocation:" + location;
        }
    }*/
}
