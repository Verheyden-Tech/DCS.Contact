using DCS.Resource;
using DCS.DefaultViewControls;
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
        private IIconService iconService = CommonServiceLocator.ServiceLocator.Current.GetInstance<IIconService>();
        private IContactService contactService = CommonServiceLocator.ServiceLocator.Current.GetInstance<IContactService>();
        private IPhysicalAdressService physicalAdressService = CommonServiceLocator.ServiceLocator.Current.GetInstance<IPhysicalAdressService>();
        private IPhoneService phoneService = CommonServiceLocator.ServiceLocator.Current.GetInstance<IPhoneService>();
        private IEmailAdressService emailAdressService = CommonServiceLocator.ServiceLocator.Current.GetInstance<IEmailAdressService>();
        private ContactViewModel viewModel;
        private EmailAdressViewModel emailAdressViewModel;
        private PhoneNumberViewModel phoneViewModel;
        private PhysicalAdressViewModel physicalAdressViewModel;
        private CompanyViewModel companyViewModel;

        private bool? isSaved;
        private bool? isCreate;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactEditor"/> class.
        /// </summary>
        public ContactEditor()
        {
            InitializeComponent();

            this.IsCreate = true;

            var obj = new Contact();
            AddPagingObjects(obj);
            this.DataContext = new ContactViewModel(obj);

            if(!string.IsNullOrEmpty(Current.LastName))
            {
                this.SelectedContact = Current.Model;
                this.IsCreate = false;

                this.Title = Current.FirstName + " " + Current.LastName;

                var vm = new ContactViewModel(Current.Model);
                if (vm.ContactEmails.Count != 0)
                {
                    EmailAdressListBox.Visibility = Visibility.Visible;
                }

                if (vm.ContactPhoneNumbers.Count != 0)
                {
                    PhoneNumberListBox.Visibility = Visibility.Visible;
                }
            }
        }

        /// <summary>
        /// Returns the current contact editor view model data context.
        /// </summary>
        public ContactViewModel Current
        {
            get
            {
                return DataContext as ContactViewModel;
            }
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
            if (models.Count > 0)
                this.DataContext = new ContactViewModel(models.FirstOrDefault());
        }

        /// <summary>
        /// Creates a new contact with pre given names.
        /// </summary>
        /// <returns></returns>
        public Contact NewContactFromCurrentInput()
        {
            var firstName = string.Empty;
            var lastName = string.Empty;

            if(SelectedContact == null && !string.IsNullOrEmpty(FirstNameTextBox.Text) || !string.IsNullOrEmpty(LastNameTextBox.Text))
            {
                if (!string.IsNullOrEmpty(FirstNameTextBox.Text))
                {
                    firstName = FirstNameTextBox.Text;
                }
                if (!string.IsNullOrEmpty(LastNameTextBox.Text))
                {
                    lastName = LastNameTextBox.Text;
                }

                var curCon = new Contact();
                curCon = contactService.CreateNewContact(firstName, lastName);

                return curCon;
            }

            return contactService.CreateNewContact(firstName, lastName);
        }

        /// <summary>
        /// Gets or sets the current contact.
        /// </summary>
        public Contact? SelectedContact { get; set; }

        #region ButtonClicks
        private void AddPhysicalAdressButton_Click(object sender, RoutedEventArgs e)
        {
            if(Current.Model == null)
               Current.Model = NewContactFromCurrentInput();

            if(Current.Model != null)
            {
                var newAdress = physicalAdressService.CreateNewAdress(Current.Model, StreetNameTextBox.Text, HouseNumberTextBox.Text, "", PostalCodeTextBox.Text, CityTextBox.Text, CountryTextBox.Text);

                physicalAdressViewModel = new PhysicalAdressViewModel(newAdress);
                if (physicalAdressViewModel.Add(newAdress))
                {
                    StreetNameTextBox.Text = string.Empty;
                    HouseNumberTextBox.Text = string.Empty;
                    PostalCodeTextBox.Text = string.Empty;
                    CityTextBox.Text = string.Empty;
                    CountryTextBox.Text = string.Empty;
                    PhysicalAdressListBox.Items.Refresh();
                }
                else
                {
                    MessageBox.Show("Fehler beim speichern.", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void AddPhoneNumber_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedContact == null)
                NewContactFromCurrentInput();

            if (SelectedContact != null)
            {
                var newPhone = phoneService.CreateNewPhone(PhoneNumberTextBox.Text, "", true, SelectedContact.Guid);

                phoneViewModel = new PhoneNumberViewModel(newPhone);
                if (phoneViewModel.Add(newPhone))
                {
                    PhoneNumberListBox.Items.Refresh();
                    PhoneNumberTextBox.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show($"Fehler beim speichern von {newPhone.PhoneNumber}.", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void AddEmailAdress_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedContact == null)
                NewContactFromCurrentInput();

            if (SelectedContact != null)
            {
                var newEmail = emailAdressService.CreateEmailAdress(EmailAdressTextBox.SearchText, SelectedContact.Guid);

                emailAdressViewModel = new EmailAdressViewModel(newEmail);
                if (emailAdressViewModel.Add(newEmail))
                {
                    EmailAdressTextBox.SearchText = string.Empty;
                    EmailAdressListBox.Items.Refresh();
                }
                else
                {
                    MessageBox.Show($"Fehler beim speichern von '{newEmail.MailAdress}'.", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        #endregion

        private void RemoveFromList_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = (sender as Button).CommandParameter;

            switch (selectedItem)
            {
                case Adress adress:
                    if(viewModel.ContactAdresses.Contains(adress))
                        viewModel.ContactAdresses.Remove(adress);
                    break;

                case Email email:
                    if(viewModel.ContactEmails.Contains(email))
                        viewModel.ContactEmails.Remove(email);
                    break;

                case Phone phone:
                    if(viewModel.ContactPhoneNumbers.Contains(phone))
                        viewModel.ContactPhoneNumbers.Remove(phone);
                    break;

                default:
                    break;
            }
        }

        private void PhysicalAdressListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if(sender is ListBox listBox)
            {
                var selectedAdress = listBox.SelectedItem as Adress;

                if(selectedAdress != null)
                {
                    StreetNameTextBox.Text = string.Empty;
                    HouseNumberTextBox.Text = string.Empty;
                    PostalCodeTextBox.Text = string.Empty;
                    CityTextBox.Text = string.Empty;

                    StreetNameTextBox.Text = selectedAdress.StreetName;
                    HouseNumberTextBox.Text = selectedAdress.HouseNumber;
                    PostalCodeTextBox.Text = selectedAdress.PostalCode;
                    CityTextBox.Text = selectedAdress.City;
                }
            }
        }

        private void EmailAdressListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(sender is ListBox listBox)
            {
                var selectedEmail = listBox.SelectedItem as Email;

                if(selectedEmail != null)
                {
                    EmailAdressTextBox.SearchText = string.Empty;

                    EmailAdressTextBox.SearchText = selectedEmail.MailAdress;
                }
            }
        }

        private void PhoneNumberListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(sender is ListBox listBox)
            {
                var selectedPhoneNumber = listBox.SelectedItem as Phone;

                if(selectedPhoneNumber != null)
                {
                    PhoneNumberTextBox.Text = string.Empty;

                    PhoneNumberTextBox.Text = selectedPhoneNumber.PhoneNumber;
                }
            }
        }

        private void EmailAdressTextBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var searchBox = (sender as RadAutoCompleteBox);

            if(searchBox != null)
            {
                try
                {
                    var selectedMail = searchBox.SelectedItem as Email;

                    if (selectedMail != null)
                    {
                        emailAdressViewModel = new EmailAdressViewModel(selectedMail);
                        if (emailAdressViewModel.Add(selectedMail))
                        {
                            searchBox.SearchText = string.Empty;
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogManager.LogManager.Singleton.Error($"Error while adding email adress. {ex.Message}", $"{ex.Source}");
                }
            }
            
        }

        private void EmailAdressTextBox_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(e.Key == System.Windows.Input.Key.Enter)
            {
                var searchBox = (sender as RadAutoCompleteBox);

                if (searchBox != null)
                {
                    try
                    {
                        var selectedMail = searchBox.SelectedItem as Email;

                        if (selectedMail != null)
                        {
                            emailAdressViewModel = new EmailAdressViewModel(selectedMail);
                            if (emailAdressViewModel.Add(selectedMail))
                            {
                                searchBox.SearchText = string.Empty;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LogManager.LogManager.Singleton.Error($"Error while adding email adress. {ex.Message}", $"{ex.Source}");
                    }
                }
            }
        }
    }
}
