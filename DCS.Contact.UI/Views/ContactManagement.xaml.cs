using DCS.CoreLib.Collection;
using DCS.CoreLib.View;
using System.Windows;
using Telerik.Windows.Controls;

namespace DCS.Contact.UI
{
    /// <summary>
    /// Interaction logic for ContactManagement.xaml
    /// </summary>
    public partial class ContactManagement : DcsInternPage
    {
        private readonly IContactService contactService = CommonServiceLocator.ServiceLocator.Current.GetInstance<IContactService>();

        private ContactViewModel viewModel;


        /// <summary>
        /// Initializes a new instance of the <see cref="ContactManagement"/> class.
        /// </summary>
        /// <remarks>This constructor initializes the data context for the view model and populates
        /// collections of contact addresses and phone numbers associated with the contact. It also sets the first
        /// available address and phone number as the default display values.  The constructor retrieves contact
        /// assignments from the <c>contactAssignementService</c> and uses the <c>contactAdressService</c> and
        /// <c>phoneService</c> to fetch detailed address and phone information.</remarks>
        public ContactManagement() : base()
        {
            InitializeComponent();

            Title = "Kontaktverwaltung";
            DisplayName = "Kontaktverwaltung";
            Name = "ContactManagement";
            GroupName = "Contact";

            var obj = new Contact();
            viewModel = new ContactViewModel(obj);
            this.DataContext = viewModel;
        }

        private void DeleteContact_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (MainGridView.SelectedItem is Contact contact)
            {
                if (MessageBox.Show($"Möchten Sie den Kontakt {contact.FirstName} {contact.LastName} wirklich löschen?", "Kontakt löschen?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (contactService.Delete(contact.Guid))
                        MainGridView.Items.Refresh();
                }
                else
                {
                    return;
                }
            }
        }

        private void EditContact_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var win = new ContactEditor();
            if (MainGridView.SelectedItem is Contact contact)
            {
                win.AddPagingObjects(contact);
                if (win.ShowDialog() == true)
                {
                    foreach (Contact newContact in win.PagingObjects.NewItems)
                        contactService.New(newContact);
                    foreach (Contact modifiedContact in win.PagingObjects.EditedItems)
                        contactService.Update(modifiedContact);
                    foreach (Contact deletedContact in win.PagingObjects.RemovedItems)
                        contactService.Delete(deletedContact.Guid);
                    MainGridView.Items.Refresh();
                }
            }
        }

        private void NewContact_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var win = new ContactEditor();
            if (win.ShowDialog() == true)
            {
                foreach (Contact newContact in win.PagingObjects.NewItems)
                    contactService.New(newContact);
                MainGridView.Items.Refresh();
            }
        }

        private void SearchContactBox_QuerySubmitted(object sender, Telerik.Windows.Controls.AutoSuggestBox.QuerySubmittedEventArgs e)
        {
            if (sender is RadAutoSuggestBox box && e.Suggestion is Contact contact)
            {
                var editor = new ContactEditor();
                editor.AddPagingObjects(contact);
                if (editor.ShowDialog() == true)
                {
                    MainGridView.Items.Refresh();
                }
            }
        }
    }
}
