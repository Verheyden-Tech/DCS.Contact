using DCS.DefaultViewControls;
using System.Windows;

namespace DCS.Contact.UI
{
    /// <summary>
    /// Interaction logic for PhoneNumberEditor.xaml
    /// </summary>
    public partial class PhoneNumberEditor : DefaultAppControl
    {
        private PhoneNumberViewModel viewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="PhoneNumberEditor"/> class.
        /// </summary>
        public PhoneNumberEditor()
        {
            InitializeComponent();

            viewModel = new PhoneNumberViewModel();

            this.DataContext = viewModel;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PhoneNumberEditor"/> class.
        /// </summary>
        /// <param name="contact"></param>
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

        /// <summary>
        /// Gets or sets the selected contact.
        /// </summary>
        public Contact? SelectedContact { get; set; }
    }
}
