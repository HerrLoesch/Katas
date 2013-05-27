using System;
using System.Linq;
using System.Text;

namespace LottoKata
{
    public class WinningClassCalculator
    {
        public WinningClasses CalculateWinningClass(Ticket drawn, Ticket played)
        {
            var count = played.Numbers.Where(x => drawn.Numbers.Contains(x)).Count();
            var hitAdditional = played.Numbers.Contains(drawn.Additional);

            if (count == 3)
            {
                if (hitAdditional)
                    return WinningClasses.VII;
                else
                    return WinningClasses.VIII;
            }

            if (count == 4)
            {
                if (hitAdditional)
                    return WinningClasses.V;
                else
                    return WinningClasses.VI;
            }

            if (count == 5)
            {
                if (hitAdditional)
                    return WinningClasses.III;
                else
                    return WinningClasses.IV;
            }

            if (count == 6)
            {
                if (drawn.Super != played.Super)
                    return WinningClasses.II;
                else
                    return WinningClasses.I;
            }

            return WinningClasses.None;
        }
    }
}
