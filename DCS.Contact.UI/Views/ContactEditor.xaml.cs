using DCS.CoreLib.Collection;
using DCS.CoreLib.View;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;

namespace DCS.Contact.UI
{
    /// <summary>
    /// Interaction logic for ContactEditor.xaml
    /// </summary>
    public partial class ContactEditor : DefaultEditorWindow
    {
        private readonly IPhoneService phoneService = CommonServiceLocator.ServiceLocator.Current.GetInstance<IPhoneService>();
        private readonly IPhysicalAdressService physicalAdressService = CommonServiceLocator.ServiceLocator.Current.GetInstance<IPhysicalAdressService>();
        private readonly IEmailAdressService emailAdressService = CommonServiceLocator.ServiceLocator.Current.GetInstance<IEmailAdressService>();
        private readonly IContactAssignementService contactAssignementService = CommonServiceLocator.ServiceLocator.Current.GetInstance<IContactAssignementService>();

        private ContactViewModel viewModel;

        private StatefulCollection<Email> ContactEmailAdresses = new StatefulCollection<Email>();
        private StatefulCollection<Phone> ContactPhoneNumbers = new StatefulCollection<Phone>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactEditor"/> class.
        /// </summary>
        /// <remarks>This constructor sets up the data context for the contact editor and initializes the
        /// contact's email addresses and phone numbers based on existing assignments. It also configures the UI
        /// visibility for email and phone number fields based on the contact's data.</remarks>
        public ContactEditor()
        {
            InitializeComponent();

            var obj = new Contact();
            AddPagingObjects(obj);
            this.DataContext = new ContactViewModel(obj);

            //Get contact adress
            var contactAdress = contactAssignementService.GetAll().Where(ca => ca.ContactGuid == obj.Guid && ca.AdressGuid != null).FirstOrDefault();
            if (contactAdress != null && contactAdress.AdressGuid != null)
            {
                var adress = physicalAdressService.Get(contactAdress.AdressGuid.Value);
                if (adress != null)
                {
                    StreetNameTextBox.Text = adress.StreetName;
                    HouseNumberTextBox.Text = adress.HouseNumber;
                    CityTextBox.Text = adress.City;
                    PostalCodeTextBox.Text = adress.PostalCode;
                    CountryTextBox.Text = adress.Country;
                }
            }

            //Get contact email adresses
            var contactEmailAdresses = contactAssignementService.GetAll().Where(ca => ca.ContactGuid == obj.Guid && ca.EmailGuid != null);
            if (contactEmailAdresses != null && contactEmailAdresses.Count() >= 0)
            {
                foreach (var email in contactEmailAdresses)
                {
                    if (email.EmailGuid.HasValue != false)
                    {
                        ContactEmailAdresses.Add(emailAdressService.Get(email.EmailGuid.Value));
                    }
                }
            }

            //Get contact phone numbers
            var contactPhoneNumbers = contactAssignementService.GetAll().Where(ca => ca.ContactGuid == obj.Guid && ca.PhoneGuid != null);
            if (contactPhoneNumbers != null && contactPhoneNumbers.Count() >= 0)
            {
                foreach (var phone in contactPhoneNumbers)
                {
                    if (phone.PhoneGuid.HasValue != false)
                    {
                        ContactPhoneNumbers.Add(phoneService.Get(phone.PhoneGuid.Value));
                    }
                }
            }

            CountryTextBox.ItemsSource = PopulateCountryList();

            if(!string.IsNullOrWhiteSpace(obj.ProfilePicturePath))
            {
                ContactProfilePicture.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(obj.ProfilePicturePath));
            }
        }

        /// <summary>
        /// Gets the current contact view model as data context.
        /// </summary>
        public ContactViewModel Current
        {
            get
            {
                return DataContext as ContactViewModel;
            }
        }

        /// <summary>
        /// Retrieves a collection of distinct country names in English, sorted in descending order.
        /// </summary>
        /// <remarks>The method gathers country names based on specific cultures available in the system.
        /// The returned collection is distinct and sorted in descending alphabetical order.</remarks>
        /// <returns>An <see cref="ObservableCollection{T}"/> of strings containing the English names of countries. If no
        /// countries are found, an empty collection is returned.</returns>
        public ObservableCollection<string> PopulateCountryList()
        {
            var countries = CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                                       .Select(culture => new RegionInfo(culture.LCID))
                                       .Select(region => region.EnglishName)
                                       .Distinct()
                                       .OrderByDescending(country => country) as ObservableCollection<string>;

            if (countries != null)
                return countries;

            return new ObservableCollection<string>();
        }

        #region ButtonClicks
        private void RemoveFromList_Click(object sender, RoutedEventArgs e)
        {
            if (sender is RadButton button && button.DataContext != null)
            {
                var selectedItem = button.DataContext;

                switch (selectedItem)
                {
                    case Email email:
                        viewModel.RemoveEmailFromContact(email);
                        break;

                    case Phone phone:
                        viewModel.RemovePhoneFromContact(phone);
                        break;

                    default:
                        break;
                }
            }
        }

        private void EmailAdressListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ListBox listBox && listBox.DataContext is Email email)
            {
                if (email != null && !string.IsNullOrWhiteSpace(email.MailAdress))
                {
                    EmailAdressTextBox.Text = email.MailAdress;
                }
            }
        }

        private void PhoneNumberListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ListBox listBox && listBox.DataContext is Phone phone)
            {
                if (phone != null && !string.IsNullOrWhiteSpace(phone.PhoneNumber))
                {
                    PhoneNumberListBox.SelectedItem = phone.PhoneNumber;
                }
            }
        }

        private void AddContactProfilePicture_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog
            {
                Title = "Kontakt-Profilbild setzen",
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif"
            };

            if(openFileDialog.ShowDialog() == true)
            {
                var selectedFilePath = openFileDialog.FileName;

                ContactProfilePicture.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(selectedFilePath));

                if (this.DataContext is ContactViewModel contactViewModel)
                {
                    contactViewModel.ProfilePicturePath = selectedFilePath;
                }
            }
        }
        #endregion
    }
}
