using DCS.Contact;
using DCS.DefaultViewControls;
using System.Windows;
using System.Windows.Controls;

namespace DCSBase.Contacts
{
    /// <summary>
    /// Interaction logic for PhysicalAdressEditor.xaml
    /// </summary>
    public partial class PhysicalAdressEditor : DefaultMainWindow
    {
        private PhysicalAddressViewModel viewModel;

        public PhysicalAdressEditor()
        {
            InitializeComponent();

            viewModel = new PhysicalAddressViewModel();

            this.DataContext = viewModel;
        }

        public PhysicalAdressEditor(Contact contact) : this()
        {
            viewModel = new PhysicalAddressViewModel(contact);
            this.DataContext = viewModel;
        }

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

        public Contact? SelectedContact { get; set; }
    }
}
