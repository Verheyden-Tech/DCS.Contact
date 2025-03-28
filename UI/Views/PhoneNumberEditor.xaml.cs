using DCS.Contact;
using DCS.User;
using System.Windows;
using System.Windows.Controls;

namespace DCSBase.Contacts
{
    /// <summary>
    /// Interaction logic for PhoneNumberEditor.xaml
    /// </summary>
    public partial class PhoneNumberEditor : DefaultAppControl
    {
        private PhoneNumberViewModel viewModel;

        public PhoneNumberEditor()
        {
            InitializeComponent();

            viewModel = new PhoneNumberViewModel();

            this.DataContext = viewModel;
        }

        public PhoneNumberEditor(Contact contact)
        {
            InitializeComponent();

            this.SelectedContact = contact;

            viewModel = new PhoneNumberViewModel(contact);

            this.DataContext = viewModel;
        }

        private void AddPhoneNumber_Click(object sender, RoutedEventArgs e)
        {
            string phoneNumber = PhoneNumberTextBox.Text;
            if(phoneNumber is string)
            {
            }
        }

        public Contact? SelectedContact { get; set; }
    }
}
