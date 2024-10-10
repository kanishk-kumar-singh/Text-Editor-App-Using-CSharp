using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Console.WriteLine("hello world");
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of SaveFileDialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"; // Restrict to text files

            // Show the dialog and if the user picks a location, save the file
            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    // Write the contents of InputTextBox to the selected file
                    File.WriteAllText(saveFileDialog.FileName, InputTextBox.Text);

                    // Optional: Display success message
                    MessageBox.Show("File saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    // Display error message if something goes wrong
                    MessageBox.Show($"Error saving file: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    // Read the file content and display it in the InputTextBox
                    string fileContent = File.ReadAllText(openFileDialog.FileName);
                    InputTextBox.Text = fileContent;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error opening file: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        //private void tester()
        //{
        //    string userInput = InputTextBox.Text;
        //    DisplayTextBlock.Text = "You entered: " + userInput;
        //    //TextEditor kuchbhi = new TextEditor();
        //    //kuchbhi.Print();
        //    ////TextEditor.Print();
        //    //TimeTextBlock.Text = "Hello World";

        //}
    }
}