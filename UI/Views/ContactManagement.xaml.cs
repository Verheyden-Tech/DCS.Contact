using DCS.Contact;
using DCS.DefaultTemplates;
using DCS.User;
using DCSBase.Contacts.ContactWindows;
using DCS.Resource;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;
using Telerik.Windows.Controls;

namespace DCSBase.Contacts
{
    /// <summary>
    /// Interaction logic for CustomerManagement.xaml
    /// </summary>
    public partial class ContactManagement : UserControl
    {
        private IIconService iconService = CommonServiceLocator.ServiceLocator.Current.GetInstance<IIconService>();
        private Contact contact;
        private ContactManagementViewModel viewModel;
        private DefaultCollection<Contact> selectedContacts;

        public ContactManagement()
        {
            InitializeComponent();

            viewModel = new ContactManagementViewModel();
            this.DataContext = viewModel;

            this.ContextMenu = SetContextMenu();

            selectedContacts = new DefaultCollection<Contact>();
        }

        private ContextMenu SetContextMenu()
        {
            ContextMenu contextMenu = new ContextMenu();

            MenuItem newContact = new MenuItem()
            {
                Header = "Kontakt hinzufügen",
                Icon = iconService.GetAsImage(iconService.GetImage("usermanagement_add_user_16x.png"))
            };
            newContact.Click += NewContact_Click;
            contextMenu.Items.Add(newContact);

            MenuItem editContact = new MenuItem()
            {
                Header = "Kontakt bearbeiten",
                Icon = iconService.GetAsImage(iconService.GetImage("usermanagement_edit_user_16x.png"))
            };
            editContact.Click += EditContact_Click;
            contextMenu.Items.Add(editContact);

            MenuItem deleteContact = new MenuItem()
            {
                Header = "Kontakt löschen",
                Icon = iconService.GetAsImage(iconService.GetImage("usermanagement_remove_user_16x.png"))
            };
            deleteContact.Click += DeleteContact_Click;
            contextMenu.Items.Add(deleteContact);

            return contextMenu;
        }

        private void DeleteContact_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            
        }

        private void EditContact_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var win = new ContactEditor();
            win.Edit(selectedContacts);
            if (win.ShowDialog() == true)
                MainGridView.Items.Refresh();
        }

        private void NewContact_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var contact = new Contact() { Guid = Guid.NewGuid(), IsActive = true, UserGuid = CurrentUserService.Instance.CurrentUser.Guid }; 
            var win = new ContactEditor();
            if(win.ShowDialog() == true)
            {
                MainGridView.Items.Refresh();
            }
        }

        public Contact SelectedContact { get => contact; set => contact = value; }

        private void SearchContactBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var searchBox = (sender as RadAutoCompleteBox);

            var win = new ContactEditor();
            win.AddPagingObjects(e.AddedItems as Contact);
            if(win.ShowDialog() == true)
            {
                searchBox.SearchText = string.Empty;
                MainGridView.Items.Refresh();
            }
        }
    }
}
