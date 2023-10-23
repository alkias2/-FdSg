using System.Globalization;

namespace Fd.Core
{
	public static class DateTimeExtensions
	{
		public static DateTime Floor(this DateTime theDate) {
			return theDate.Date;
		}

		public static DateTime Ceil(this DateTime theDate) {
			return theDate.Date.AddDays(1).AddTicks(-1);
		}

		public static string ToUnix(this DateTime theDate)
		{
			return theDate.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
		}

		public static string ToDotValue(this double value) {
			return value.ToString(CultureInfo.InvariantCulture).Replace(",", ".");
		}
		public static string ToDotValue(this double? value) {
			if (value == null)
				return "";
			return value.ToString()?.Replace(",", ".");

		}
	}
}