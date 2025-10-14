using DCS.CoreLib.Collection;
using DCS.CoreLib.View;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
            viewModel = new ContactViewModel(obj);
            this.DataContext = viewModel;

            //Get contact adress
            var contactAdress = contactAssignementService.GetAll().Where(ca => ca.ContactGuid == obj.Guid && ca.AdressGuid != null).FirstOrDefault();
            if (contactAdress != null && contactAdress.AdressGuid != null && contactAdress.AdressGuid.HasValue == true)
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
            CountryTextBox.DisplayMemberPath = "EnglishName";

            if (!string.IsNullOrWhiteSpace(obj.ProfilePicturePath))
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
        /// Handles the <see cref="System.Windows.Window.Closing"/> event to perform validation and update or create
        /// address data before the window closes.
        /// </summary>
        /// <remarks>This method ensures that address fields are validated and any changes to the address
        /// are saved before the window closes.  If the address fields are filled, it attempts to update an existing
        /// address or create a new one as needed.  If an error occurs during the update or creation process, the window
        /// closing is canceled, and an error message is displayed to the user.</remarks>
        /// <param name="e">A <see cref="System.ComponentModel.CancelEventArgs"/> that contains the event data. Set <see
        /// cref="System.ComponentModel.CancelEventArgs.Cancel"/> to <see langword="true"/> to prevent the window from
        /// closing.</param>
        protected override void OnClosing(CancelEventArgs e)
        {
            if (Current.Model != null)
            {
                //Check if adress fields are filled
                if (!string.IsNullOrWhiteSpace(StreetNameTextBox.Text) && !string.IsNullOrWhiteSpace(HouseNumberTextBox.Text))
                {
                    var assignements = contactAssignementService.GetAll().Where(ca => ca.ContactGuid == Current.Model.Guid && ca.AdressGuid != null);
                    if (assignements != null && assignements.Count() >= 0)
                    {
                        //Update existing adress
                        var adressAssignement = assignements.FirstOrDefault();
                        if (adressAssignement != null && adressAssignement.AdressGuid.HasValue == true)
                        {
                            var adress = physicalAdressService.Get(adressAssignement.AdressGuid.Value);
                            if (adress != null)
                            {
                                if (adress.StreetName != StreetNameTextBox.Text || adress.HouseNumber != HouseNumberTextBox.Text || adress.City != CityTextBox.Text || adress.PostalCode != PostalCodeTextBox.Text || adress.Country != CountryTextBox.Text)
                                {
                                    adress.StreetName = StreetNameTextBox.Text;
                                    adress.HouseNumber = HouseNumberTextBox.Text;
                                    adress.City = CityTextBox.Text;
                                    adress.PostalCode = PostalCodeTextBox.Text;
                                    adress.Country = CountryTextBox.Text;
                                    if (!physicalAdressService.Update(adress))
                                    {
                                        Log.LogManager.Singleton.Error("Fehler beim Aktualisieren der Adresse.", "ContactEditor.OnClosing");
                                        MessageBox.Show("Fehler beim Aktualisieren der Adresse.", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                                        e.Cancel = true;
                                        return;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        //Create new adress
                        var adress = physicalAdressService.CreateNewAdress(StreetNameTextBox.Text, HouseNumberTextBox.Text, string.Empty, CityTextBox.Text, PostalCodeTextBox.Text, CountryTextBox.Text);
                        if (adress != null)
                        {
                            var newAssignement = new ContactAssignement
                            {
                                Guid = Guid.NewGuid(),
                                ContactGuid = Current.Model.Guid,
                                AdressGuid = adress.Guid
                            };
                            if (!contactAssignementService.New(newAssignement))
                            {
                                Log.LogManager.Singleton.Error("Fehler beim Hinzufügen der Adress-Zuordnung.", "ContactEditor.OnClosing");
                                MessageBox.Show("Fehler beim Hinzufügen der Adressess-Zuordnung.", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                    }
                }
            }

            this.DialogResult = true;
            base.OnClosing(e);
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
                        var mailAdressAssignement = contactAssignementService.GetAll().Where(ca => ca.ContactGuid == Current.Model.Guid && ca.EmailGuid == email.Guid).FirstOrDefault();
                        if (mailAdressAssignement != null)
                        {
                            if (contactAssignementService.Delete(mailAdressAssignement.Guid))
                            {
                                viewModel.RemoveEmailFromContact(email);
                            }
                            else
                            {
                                Log.LogManager.Singleton.Error("Fehler beim Löschen der Email-Zuordnung.", "ContactEditor.RemoveFromList");
                                MessageBox.Show("Fehler beim Löschen der Email-Adresse.", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                                return;
                            }
                        }
                        break;

                    case Phone phone:
                        var phoneNumberAssignement = contactAssignementService.GetAll().Where(ca => ca.ContactGuid == Current.Model.Guid && ca.PhoneGuid == phone.Guid).FirstOrDefault();
                        if (phoneNumberAssignement != null)
                        {
                            if (contactAssignementService.Delete(phoneNumberAssignement.Guid))
                            {
                                viewModel.RemovePhoneFromContact(phone);
                            }
                            else
                            {
                                Log.LogManager.Singleton.Error("Fehler beim Löschen der Telefonnummer-Zuordnung.", "ContactEditor.RemoveFromList");
                                MessageBox.Show("Fehler beim Löschen der Telefonnummer.", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                                return;
                            }
                        }
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

            if (openFileDialog.ShowDialog() == true)
            {
                var selectedFilePath = openFileDialog.FileName;

                ContactProfilePicture.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(selectedFilePath));

                if (this.DataContext is ContactViewModel contactViewModel)
                {
                    contactViewModel.ProfilePicturePath = selectedFilePath;
                }
            }
        }

        private void AddEmailAdressButton_Click(object sender, RoutedEventArgs e)
        {
            if (Current.Model != null && !string.IsNullOrWhiteSpace(EmailAdressTextBox.Text))
            {
                var email = new Email
                {
                    Guid = Guid.NewGuid(),
                    MailAdress = EmailAdressTextBox.Text,
                    IsActive = true
                };

                var assignement = new ContactAssignement
                {
                    Guid = Guid.NewGuid(),
                    ContactGuid = Current.Model.Guid,
                    EmailGuid = email.Guid
                };

                if (contactAssignementService.New(assignement))
                {
                    if (viewModel.AddEmailToContact(email))
                        EmailAdressTextBox.Text = string.Empty;
                    else
                    {
                        Log.LogManager.Singleton.Error("Fehler beim Hinzufügen der Email-Adresse zum Kontakt.", "ContactEditor.AddEmailAdress");
                        MessageBox.Show("Fehler beim Hinzufügen der Email-Adresse zum Kontakt.", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
            }
        }

        private void AddPhoneNumberButton_Click(object sender, RoutedEventArgs e)
        {
            if (Current.Model != null && !string.IsNullOrWhiteSpace(PhoneNumberTextBox.Text))
            {
                var phone = new Phone
                {
                    Guid = Guid.NewGuid(),
                    PhoneNumber = PhoneNumberTextBox.Text,
                    IsActive = true
                };

                var assignement = new ContactAssignement
                {
                    Guid = Guid.NewGuid(),
                    ContactGuid = Current.Model.Guid,
                    PhoneGuid = phone.Guid
                };

                if (contactAssignementService.New(assignement))
                {
                    if (viewModel.AddPhoneToContact(phone))
                        PhoneNumberTextBox.Text = string.Empty;
                    else
                    {
                        Log.LogManager.Singleton.Error("Fehler beim Hinzufügen der Telefonnummer zum Kontakt.", "ContactEditor.AddPhoneNumber");
                        MessageBox.Show("Fehler beim Hinzufügen der Telefonnummer zum Kontakt.", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
            }
        }

        private void UpdateAdressButton_Click(object sender, RoutedEventArgs e)
        {
            if (Current.Model != null && !string.IsNullOrWhiteSpace(StreetNameTextBox.Text) && !string.IsNullOrWhiteSpace(HouseNumberTextBox.Text))
            {
                var assignements = contactAssignementService.GetAll().Where(ca => ca.ContactGuid == Current.Model.Guid && ca.AdressGuid != null);

                if (assignements != null && assignements.Count() >= 0)
                {
                    //Update existing adress
                    var adressAssignement = assignements.FirstOrDefault();
                    if (adressAssignement != null && adressAssignement.AdressGuid.HasValue == true)
                    {
                        var adress = physicalAdressService.Get(adressAssignement.AdressGuid.Value);
                        if (adress != null)
                        {
                            if (adress.StreetName != StreetNameTextBox.Text || adress.HouseNumber != HouseNumberTextBox.Text || adress.City != CityTextBox.Text || adress.PostalCode != PostalCodeTextBox.Text || adress.Country != CountryTextBox.Text)
                            {
                                adress.StreetName = StreetNameTextBox.Text;
                                adress.HouseNumber = HouseNumberTextBox.Text;
                                adress.City = CityTextBox.Text;
                                adress.PostalCode = PostalCodeTextBox.Text;
                                adress.Country = CountryTextBox.Text;

                                if (physicalAdressService.Update(adress))
                                {
                                    MessageBox.Show("Adresse erfolgreich aktualisiert.", "Erfolg", MessageBoxButton.OK, MessageBoxImage.Information);
                                }
                                else
                                {
                                    Log.LogManager.Singleton.Error("Fehler beim Aktualisieren der Adresse.", "ContactEditor.UpdateAdress");
                                    MessageBox.Show("Fehler beim Aktualisieren der Adresse.", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                                    return;
                                }
                            }
                            else
                            {
                                Log.LogManager.Singleton.Error("Fehler beim Aktualisieren der Adresse.", "ContactEditor.UpdateAdress");
                                MessageBox.Show("Fehler beim Aktualisieren der Adresse.", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                                return;
                            }
                        }
                    }
                }
                else
                {
                    //Create new adress
                    var adress = physicalAdressService.CreateNewAdress(StreetNameTextBox.Text, HouseNumberTextBox.Text, string.Empty, CityTextBox.Text, PostalCodeTextBox.Text, CountryTextBox.Text);
                    if (adress != null)
                    {
                        var newAssignement = new ContactAssignement
                        {
                            Guid = Guid.NewGuid(),
                            ContactGuid = Current.Model.Guid,
                            AdressGuid = adress.Guid
                        };

                        if (contactAssignementService.New(newAssignement))
                        {
                            MessageBox.Show("Adresse erfolgreich hinzugefügt.", "Erfolg", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            Log.LogManager.Singleton.Error("Fehler beim Hinzufügen der Adress-Zuordnung.", "ContactEditor.UpdateAdress");
                            MessageBox.Show("Fehler beim Hinzufügen der Adress-Zuordnung.", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                    }
                    else
                    {
                        Log.LogManager.Singleton.Error("Fehler beim Erstellen der neuen Adresse.", "ContactEditor.UpdateAdress");
                    }
                }
            }
        }
        #endregion
    }
}
