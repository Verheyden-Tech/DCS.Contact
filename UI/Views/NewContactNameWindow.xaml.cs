using DCS.DefaultViewControls;
using System.Windows;

namespace DCS.Contact.UI
{
    /// <summary>
    /// Interaction logic for NewContactNameWindow.xaml
    /// </summary>
    public partial class NewContactNameWindow : DefaultEditorWindow
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NewContactNameWindow"/> class.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string LastName { get; set; }
    }
}
