using System.Collections.Generic;


namespace GeekBrains
{
    public sealed class SpeedBonusComparer : IComparer<SpeedBonus>
    {
        public int Compare(SpeedBonus x, SpeedBonus y)
        {
            if(x.Point < y.Point)
            {
                return 1;
            }

            if(x.Point > y.Point)
            {
                return -1;
            }

            return 0;
        }
    }
}
