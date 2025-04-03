using DCS.CoreLib.View;
using DCS.Resource;
using DCS.User.Service;
using System.Windows.Controls;
using Telerik.Windows.Controls;

namespace DCS.Contact.UI
{
    /// <summary>
    /// Interaction logic for CustomerManagement.xaml
    /// </summary>
    public partial class ContactManagement : DefaultAppControl
    {
        private IIconService iconService = CommonServiceLocator.ServiceLocator.Current.GetInstance<IIconService>();
        private ContactManagementViewModel viewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactManagement"/> class.
        /// </summary>
        public ContactManagement()
        {
            InitializeComponent();

            this.ContextMenu = SetContextMenu();

            var obj = new Contact();
            viewModel = new ContactManagementViewModel(obj);
            this.DataContext = viewModel;
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
            win.Edit((sender as RadGridView).SelectedItems as IList<Contact>);
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
