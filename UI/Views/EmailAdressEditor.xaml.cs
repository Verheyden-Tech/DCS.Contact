using System.Windows;
using DCS.DefaultTemplates;
using DCS.Contact;
using DCSBase;
using System.Windows.Controls;
using DCS.User;

namespace DCSBase.Contacts
{
    /// <summary>
    /// Interaction logic for EmailAdressEditor.xaml
    /// </summary>
    public partial class EmailAdressEditor : DefaultAppControl
    {
        private EmailAdressViewModel viewModel;

        public EmailAdressEditor()
        {
            InitializeComponent();

            viewModel = new EmailAdressViewModel();

            this.DataContext = (EmailAdressViewModel)viewModel;
        }

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
