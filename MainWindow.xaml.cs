using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows;
using UtilityLibrary;


// this program is intentionally non-dpi aware.  
// to make this program dpi aware, un-comment
// the following in the app.manifest file
//
//	<!--<application xmlns = "urn:schemas-microsoft-com:asm.v3">
//	<windowsSettings>
//	<dpiAwareness xmlns = "http://schemas.microsoft.com/SMI/2016/WindowsSettings">PerMonitorV2</dpiAwareness>
//	<dpiAware xmlns = "http://schemas.microsoft.com/SMI/2005/WindowsSettings">true</dpiAware>
//	</windowsSettings>
//	</application>-->

namespace ScreenParameterInfo
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
		private string message1;


		public MainWindow()
        {
            InitializeComponent();
        }

		public string message
		{
			get => message1;
			set
			{
				message1 = value;
				OnPropertyChange();
			}
		}

		private void Btn_exit_Click(object sender, RoutedEventArgs e)
        {
			this.Close();
        }

		private void Btn_showLocation_Click(object sender, RoutedEventArgs e)
		{
			Window win = this;

			bool isDpiAware = ScreenParameters.IsProcessDPIAware(out ScreenParameters.PROCESS_DPI_AWARENESS awareness);

			StringBuilder sb = new StringBuilder();

			sb.Append("monitor name                 | ").AppendLine(ScreenParameters.GetMonitorName(win));
			sb.Append("am I dpi aware?              | ").AppendLine(isDpiAware.ToString());
			sb.Append("how am I dpi aware?          | ").AppendLine(awareness.ToString());

			sb.AppendLine("\n*** dpi aware info ***");
			sb.Append("native dpi (const)           | ").AppendLine(ScreenParameters.GetNativeScreenDpi.ToString());
			sb.Append("system dpi                   | ").AppendLine(ScreenParameters.GetDpiForSystem().ToString());
			sb.Append("scaled screen dpi            | ").AppendLine(ScreenParameters.GetScreenDpi(win).ToString());
			sb.Append("scale factor                 | ").AppendLine(ScreenParameters.GetScreenScaleFactor(win).ToString("F2"));
			sb.Append("scaling factor               | ").AppendLine(ScreenParameters.GetScreenScalingFactor(win).ToString("F2"));
			sb.Append("native screen size           | ").AppendLine(ScreenParameters.GetNativeScreenSize(win).ToString());
			sb.Append("scaled screen size           | ").AppendLine(ScreenParameters.GetScaledScreenSize(win).ToString());
			sb.Append("native work area size        | ").AppendLine(ScreenParameters.GetNativeWorkArea(win).ToString());
			sb.Append("scaled work area size        | ").AppendLine(ScreenParameters.GetScaledWorkArea(win).ToString());
			sb.Append("dpi for Monitor (effective)  | ").AppendLine(ScreenParameters.GetDpiForMonitor(win, ScreenParameters.MONITOR_DPI_TYPE.MDT_EFFECTIVE_DPI).ToString());
			sb.Append("dpi for Monitor (default)    | ").AppendLine(ScreenParameters.GetDpiForMonitor(win, ScreenParameters.MONITOR_DPI_TYPE.MDT_DEFAULT).ToString());
			sb.Append("dpi for Monitor (raw)        | ").AppendLine(ScreenParameters.GetDpiForMonitor(win, ScreenParameters.MONITOR_DPI_TYPE.MDT_RAW_DPI).ToString());

			sb.AppendLine("\n*** non-dpi aware info ***");
			sb.Append("native screen size (non-dpi) | ").AppendLine(ScreenParameters.GetNativeScreenSizeNonDpiAware(win).ToString());
			sb.Append("scale factor (non-dpi)       | ").AppendLine(ScreenParameters.GetScreenScaleFactorNonDpiAware(win).ToString("F2"));
			sb.Append("scaling factor (non-dpi)     | ").AppendLine(ScreenParameters.GetScreenScalingFactorNonDpiAware(win).ToString("F2"));

			message = sb.ToString();
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChange([CallerMemberName] string memberName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
		}
	}
}


