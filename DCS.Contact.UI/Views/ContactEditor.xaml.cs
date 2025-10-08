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

        private ObservableCollection<Email> ContactEmailAdresses = new ObservableCollection<Email>();
        private ObservableCollection<Phone> ContactPhoneNumbers = new ObservableCollection<Phone>();

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
                    if (email.EmailGuid != null)
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
                    if (phone.PhoneGuid != null)
                    {
                        ContactPhoneNumbers.Add(phoneService.Get(phone.PhoneGuid.Value));
                    }
                }
            }

            if (ContactEmailAdresses.Count <= 0)
                EmailAdressGroupBox.Visibility = Visibility.Collapsed;

            if (ContactPhoneNumbers.Count <= 0)
                PhoneNumberGroupBox.Visibility = Visibility.Collapsed;

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

        /// <summary>
        /// Adds paging objects to the window.
        /// </summary>
        /// <param name="models"></param>
        public void Edit(IList<Contact> models)
        {
            PagingObjects.Clear();

            foreach (var model in models)
            {
                AddPagingObjects(model);
            }

            // Show first object from the list
            if (models.Count >= 0)
                this.DataContext = new ContactViewModel(models.FirstOrDefault());
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
                        if (viewModel.ContactEmails.Contains(email))
                            viewModel.ContactEmails.Remove(email);
                        break;

                    case Phone phone:
                        if (viewModel.ContactPhoneNumbers.Contains(phone))
                            viewModel.ContactPhoneNumbers.Remove(phone);
                        break;

                    default:
                        break;
                }
            }
        }

        private void EmailAdressListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ListBox listBox)
            {
                var selectedEmail = listBox.SelectedItem as Email;

                if (selectedEmail != null)
                {
                    EmailAdressTextBox.Text = selectedEmail.MailAdress;
                }
            }
        }

        private void PhoneNumberListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ListBox listBox)
            {
                var selectedPhoneNumber = listBox.SelectedItem as Phone;

                if (selectedPhoneNumber != null)
                {
                    PhoneNumberListBox.SelectedItem = selectedPhoneNumber.PhoneNumber;
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
