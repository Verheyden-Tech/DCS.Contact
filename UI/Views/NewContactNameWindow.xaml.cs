using DCS.DefaultViewControls;
using System.Windows;

namespace DCSBase.Contacts.ContactWindows
{
    /// <summary>
    /// Interaction logic for NewContactNameWindow.xaml
    /// </summary>
    public partial class NewContactNameWindow : DefaultEditorWindow
    {
        public NewContactNameWindow()
        {
            InitializeComponent();
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            FirstName = FirstNameTextBox.Text;
            LastName = LastNameTextBox.Text;

            if(!string.IsNullOrWhiteSpace(FirstName) && !string.IsNullOrWhiteSpace(LastName))
            {
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Felder dürfen nicht leer sein.", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
