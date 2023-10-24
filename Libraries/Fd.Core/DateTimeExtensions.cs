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

		public static DateTime UnixToDtDateTime(this string unixDate) {
			DateTime dateTime = DateTime.ParseExact(unixDate, "yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture);
			return dateTime;
		}

		public static string ToDotValue(this double value) {
			return value.ToString(CultureInfo.InvariantCulture).Replace(",", ".");
		}
		public static string ToDotValue(this double? value) {
			if (value == null)
				return "";
			return value.ToString()?.Replace(",", ".");

		}

		//https://stackoverflow.com/questions/56034919/algorithm-to-find-the-closest-time
		public static T ArgMin<T, R>(T t1, T t2, Func<T, R> f)
				where R : IComparable<R>
		{
			return f(t1).CompareTo(f(t2)) > 0 ? t2 : t1;
		}

		public static T ArgMin<T, R>(this IEnumerable<T> Sequence, Func<T, R> f)
						where R : IComparable<R>
		{
			return Sequence.Aggregate((t1, t2) => ArgMin<T, R>(t1, t2, f));
		}
	}
}