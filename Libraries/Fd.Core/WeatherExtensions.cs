using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fd.Core {
    public static class WeatherExtensions {
        public static double? MsToBeaufort(this double? ms) {
            if (ms == null) {
                return 0;
            }
            return Math.Ceiling(Math.Cbrt(Math.Pow(ms.Value / 0.836, 2)));
        }

        public static double? BeaufortToMs(this double? bf)
        {
            if (bf == null) {
                return 0;
            }
            return Math.Round(0.836 * Math.Sqrt(Math.Pow(bf.Value, 3)) * 100) / 100;
        }
    }
}
