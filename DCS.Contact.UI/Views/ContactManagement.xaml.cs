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
        private readonly IContactAssignementService contactAssignementService = CommonServiceLocator.ServiceLocator.Current.GetInstance<IContactAssignementService>();
        private readonly IContactService contactService = CommonServiceLocator.ServiceLocator.Current.GetInstance<IContactService>();
        private readonly IPhysicalAdressService contactAdressService = CommonServiceLocator.ServiceLocator.Current.GetInstance<IPhysicalAdressService>();
        private readonly IEmailAdressService emailAdressService = CommonServiceLocator.ServiceLocator.Current.GetInstance<IEmailAdressService>();
        private readonly IPhoneService phoneService = CommonServiceLocator.ServiceLocator.Current.GetInstance<IPhoneService>();

        private ContactManagementViewModel viewModel;

        private string ContactAdress { get; set; }
        private string ContactPhoneNumber { get; set; }


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

            var contactAdress = contactAssignementService.GetAll().Where(ca => ca.ContactGuid == obj.Guid && ca.AdressGuid != null);
            if(contactAdress != null && contactAdress.Count() >= 0)
            {
                Adress adress = contactAdressService.Get(contactAdress.FirstOrDefault().AdressGuid.Value);

                if(adress != null)
                {
                    ContactAdress = adress.StreetName + " " + adress.HouseNumber + ", " + adress.PostalCode + " " + adress.City + ", " + adress.Country;
                }
            }

            var contactPhone = contactAssignementService.GetAll().Where(ca => ca.ContactGuid == obj.Guid && ca.PhoneGuid != null);
            if(contactPhone != null && contactPhone.Count() >= 0)
            {
                Phone phone = phoneService.Get(contactPhone.FirstOrDefault().PhoneGuid.Value);
                if(phone != null)
                {
                    ContactPhoneNumber = phone.PhoneNumber;
                }
            }
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

        private void SearchContactBox_QuerySubmitted(object sender, Telerik.Windows.Controls.AutoSuggestBox.QuerySubmittedEventArgs e)
        {
            if (sender is RadAutoSuggestBox box && e.Suggestion is Contact contact)
            {
                var editor = new ContactEditor();
                editor.CurrentObject = contact;
                if (editor.ShowDialog() == true)
                    MainGridView.Items.Refresh();
            }
        }
    }
}
