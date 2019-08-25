#region + Using Directives

using System.Drawing;

#endregion


// projname: ScreenParameters
// itemname: Extensions
// username: jeffs
// created:  8/24/2019 4:14:02 PM


namespace UtilityLibrary
{
	public static class Extensions
	{
		public static Rectangle Scale(this Rectangle rc, double scaleFactor)
		{
			return new Rectangle(
				(int) (rc.Left   * scaleFactor),
				(int) (rc.Top    * scaleFactor),
				(int) (rc.Width  * scaleFactor),
				(int) (rc.Height * scaleFactor));
		}

		public static string ToString(this Rectangle rc)
		{
			return string.Format("top|{0,5:D} left|{1,5:D} height|{2,5:D} width|{3,5:D}",
				rc.Top, rc.Left, rc.Height, rc.Width);
		}

	}
}
