using Microsoft.Win32;
using System.Windows;
using System.Windows.Input;

namespace DerekBanas.WpfTutorial.Grid
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private string usersName = "";

		public MainWindow()
		{
			// Initializes and displays the window
			InitializeComponent();

			// You can set window properties in code
			this.Title = "Hello World";
			this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
		}

		// When the button is clicked it closes the window
		private void Button1Clicked(object sender, RoutedEventArgs e)
		{
			// Opens a message box
			MessageBox.Show("The App is Closing");

			// Closes the app
			this.Close();
		}

		// Event handling that posts the mouse x, y position in title
		private void Window_MouseMove(object sender, MouseEventArgs e)
		{
			Title = e.GetPosition(this).ToString();
		}

		private void BtnOpenFile_Click(object sender, RoutedEventArgs e)
		{
			// Opens an open file dialog
			OpenFileDialog openDlg = new OpenFileDialog();
			openDlg.ShowDialog();
		}

		private void BtnSaveFile_Click(object sender, RoutedEventArgs e)
		{
			// Opens a save file dialog
			SaveFileDialog saveDlg = new SaveFileDialog();
			saveDlg.ShowDialog();
		}

		private void Send_Button_Click(object sender, RoutedEventArgs e)
		{
			//usersName = UsersName.Text;

			//MessageBox.Show($"Hello {usersName}");
		}
	}
}