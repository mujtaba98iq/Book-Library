using DL.SimpleLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.SimpleLibrary
{
    public class clsRatings
    {
        public static short GetBookRate(int BookID)
        {
            return clsRatingsData.GetBookRate(BookID);
        }
        public static short GetBookRate(int BookID, int UserID)
        {
            return clsRatingsData.GetBookRate(BookID, UserID);
        }

        public static bool RateABook(int BookID, int UserID, int Rate)
        {
            return clsRatingsData.RateABook(BookID, UserID, Rate);
        }

        public static bool CanRate(int BookID, int UserID)
        {
            return clsRatingsData.CanRate(BookID, UserID);
        }

    }
}
