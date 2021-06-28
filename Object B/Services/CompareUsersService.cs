using System.Collections.Generic;
using Object_B.Models;

namespace Object_B
{
    
    class CompareUsersService : IComparer<RatingTable>
    {
        public int Compare(RatingTable x, RatingTable y)
        {
            if (x.Position > y.Position)
            {
                return -1;
            }
            else if (x.Position < y.Position)
            {
                return 1;
            }
            return 0;
        }
    }
}
