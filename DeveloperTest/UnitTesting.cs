using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperTest
{
    public class UnitTesting
    {
        public static bool ValidatePostcode(string postcodeName)
        {
            bool output = true;
            char[] invalidCharacters = "~!@#$%^&*()_+=<>,?/|{}[]'".ToCharArray();

            if (postcodeName.Length < 7 || postcodeName.Length > 8)
            {
                output = false;
            }

            if(postcodeName.IndexOfAny(invalidCharacters) >= 0)
            {
                output = false;
            }

            return output;
        }

        public static bool ValidateLatitude(decimal latitudeValue)
        {
            bool output = true;

            if (latitudeValue < 50 || latitudeValue > 65)
            {
                output = false;
            }

            if (Decimal.Round(latitudeValue, 6) != latitudeValue)
            {
                output = false;
            }

            return output;
        }

        public static bool ValidateLongitude(decimal longitudeValue)
        {
            bool output = true;

            if (longitudeValue < -3 || longitudeValue > 0)
            {
                output = false;
            }

            if(Decimal.Round(longitudeValue, 6) != longitudeValue)
            {
                output = false;
            }

            return output;
        }
    }
}
