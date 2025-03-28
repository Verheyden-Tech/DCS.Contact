using DCS.Resource;
using DCS.DefaultViewControls;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;

namespace DCS.Contact
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
        private ContactEditorViewModel viewModel;

        private bool? isSaved;
        private bool? isCreate;

        public ContactEditor()
        {
            InitializeComponent();

            this.IsCreate = true;

            var obj = new Contact();
            AddPagingObjects(obj);
            this.DataContext = new ContactEditorViewModel(obj);

            if(!string.IsNullOrEmpty(Current.LastName))
            {
                this.SelectedContact = Current.Model;
                this.IsCreate = false;

                this.Title = Current.FirstName + " " + Current.LastName;

                var vm = new ContactEditorViewModel(Current.Model);
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

        public ContactEditor(Contact contact) : this()
        {
            this.SelectedContact = contact;
        }

        public ContactEditorViewModel Current
        {
            get
            {
                return DataContext as ContactEditorViewModel;
            }
        }

        public void Edit(IList<Contact> models)
        {
            PagingObjects.Clear();

            foreach (var model in models)
            {
                AddPagingObjects(model);
            }

            // Show first object from the list
            if (models.Count > 0)
                this.DataContext = new ContactEditorViewModel(models.FirstOrDefault());
        }

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

        public Contact? SelectedContact { get; set; }

        #region ButtonClicks
        private void AddPhysicalAdressButton_Click(object sender, RoutedEventArgs e)
        {
            if(SelectedContact == null)
               SelectedContact = NewContactFromCurrentInput();

            if(SelectedContact != null)
            {
                var newAdress = physicalAdressService.CreateNewAdress(SelectedContact, StreetNameTextBox.Text, HouseNumberTextBox.Text, "", PostalCodeTextBox.Text, CityTextBox.Text, CountryTextBox.Text);

                if(viewModel.AddNewAdress(newAdress))
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

                if(viewModel.AddNewPhoneNumber(newPhone))
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

                if(viewModel.AddNewEmailAdress(newEmail))
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

            var selectedMail = searchBox.SelectedItem as Email;

            if (selectedMail != null)
            {
                if (Current.AddNewEmailAdress(selectedMail))
                {
                    searchBox.SearchText = string.Empty;
                }
            }
        }

        private void EmailAdressTextBox_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(e.Key == System.Windows.Input.Key.Enter)
            {
                var searchBox = (sender as RadAutoCompleteBox);

                var selectedMail = searchBox.SelectedItem as Email;

                if(selectedMail != null)
                {
                    if(Current.AddNewEmailAdress(selectedMail))
                    {
                        searchBox.SearchText = string.Empty;
                    }
                }
            }
        }
    }
}
