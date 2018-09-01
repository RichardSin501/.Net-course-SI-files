using Microsoft.Win32;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace DerekBanas.WpfTutorial
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			Title = "Hello Worldz";
			WindowStartupLocation = WindowStartupLocation.CenterScreen;
		}

		private void MainWindow_OnMouseMove(object sender, MouseEventArgs e)
		{
			Title = e.GetPosition(this).ToString();
		}

		private void Button1_OnClick(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("The app is closing.");
			Close();
		}

		private void ButtonOpenFile_OnClick(object sender, RoutedEventArgs e)
		{
			OpenFileDialog openDlg = new OpenFileDialog();
			openDlg.ShowDialog();
		}

		private void ButtonSaveFile_OnClick(object sender, RoutedEventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.ShowDialog();
		}

		private void Helloka_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			((Label)sender).Background = Brushes.Aqua;
		}
	}
}