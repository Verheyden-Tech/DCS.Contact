using DCS.CoreLib.BaseClass;
using System.Collections.ObjectModel;

namespace DCS.Contact.UI
{
    /// <summary>
    /// ViewModel for contact management.
    /// </summary>
    public class ContactManagementViewModel : ViewModelBase<Guid, Contact>
    {
        private IContactService contactService = CommonServiceLocator.ServiceLocator.Current.GetInstance<IContactService>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactManagementViewModel"/> class.
        /// </summary>
        public ContactManagementViewModel(Contact contact) : base()
        {
            this.Collection = new ObservableCollection<Contact>();
            this.Collection = contactService.GetAll().Result;
        }

        #region Public Props
        /// <summary>
        /// Gets or sets the contact's guid.
        /// </summary>
        public Guid Guid
        {
            get
            {
                return Model.Guid;
            }
            set
            {
                Model.Guid = value;
            }
        }

        /// <summary>
        /// Gets or sets the contact's first name.
        /// </summary>
        public string FirstName
        {
            get
            {
                return Model.FirstName;
            }
            set
            {
                Model.FirstName = value;
            }
        }

        /// <summary>
        /// Gets or sets the contact's last name.
        /// </summary>
        public string LastName
        {
            get
            {
                return Model.LastName;
            }
            set
            {
                Model.LastName = value;
            }
        }

        /// <summary>
        /// Indicates if the contact is active.
        /// </summary>
        public bool IsActive
        {
            get
            {
                return Model.IsActive;
            }
            set
            {
                Model.IsActive = value;
            }
        }
        #endregion
    }
}
