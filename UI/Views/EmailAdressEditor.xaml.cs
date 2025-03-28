using System.Windows;
using DCS.DefaultViewControls;

namespace DCS.Contact.UI
{
    /// <summary>
    /// Interaction logic for EmailAdressEditor.xaml
    /// </summary>
    public partial class EmailAdressEditor : DefaultAppControl
    {
        private EmailAdressViewModel viewModel;

        /// <summary>
        /// Constructor for EmailAdressEditor.
        /// </summary>
        public EmailAdressEditor()
        {
            InitializeComponent();

            viewModel = new EmailAdressViewModel();

            this.DataContext = (EmailAdressViewModel)viewModel;
        }

        /// <summary>
        /// Constructor for EmailAdressEditor.
        /// </summary>
        /// <param name="contact"></param>
        public EmailAdressEditor(Contact contact)
        {
            InitializeComponent();

            viewModel = new EmailAdressViewModel(contact);

            this.DataContext = (EmailAdressViewModel)viewModel;
        }

        private void AddEmailAdress_Click(object sender, RoutedEventArgs e)
        {
            string emailAdress = EmailAdressTextBox.Text;
        }
    }
}
