using DCS.DefaultViewControls;
using System.Windows;
using DCS.User;

namespace DCS.Contact.UI
{
    /// <summary>
    /// Interaction logic for PhysicalAdressEditor.xaml
    /// </summary>
    public partial class PhysicalAdressEditor : DefaultMainWindow
    {
        private PhysicalAddressViewModel viewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="PhysicalAdressEditor"/> class.
        /// </summary>
        public PhysicalAdressEditor()
        {
            InitializeComponent();

            viewModel = new PhysicalAddressViewModel();

            this.DataContext = viewModel;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PhysicalAdressEditor"/> class.
        /// </summary>
        /// <param name="contact"></param>
        public PhysicalAdressEditor(Contact contact) : this()
        {
            viewModel = new PhysicalAddressViewModel(contact);
            this.DataContext = viewModel;
        }

        /// <summary>
        /// Adds a new adress to the contact.
        /// </summary>
        /// <returns></returns>
        public bool AddNewAdress()
        {
            Adress newAdress = new Adress()
            {
                Guid = Guid.NewGuid(),
                StreetName = StreetNameTextBox.Text,
                HouseNumber = HouseNumberTextBox.Text,
                PostalCode = PostalCodeTextBox.Text,
                City = CityTextBox.Text,
                Country = CountryTextBox.Text,
                ContactGuid = SelectedContact.Guid,
                UserGuid = CurrentUserService.Instance.CurrentUser.Guid
            };

            viewModel.AddNewAdress(newAdress);
            return true;
        }

        private void AddPhysicalAdressButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if(!AddNewAdress())
            {
                MessageBox.Show("Fehler beim hinzufügen der Kontaktadresse.", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        /// <summary>
        /// Gets or sets the selected contact.
        /// </summary>
        public Contact? SelectedContact { get; set; }
    }
}
