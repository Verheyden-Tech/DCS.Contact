using DCS.DefaultTemplates;
using System.Collections.ObjectModel;

namespace DCS.Contact.UI
{
    /// <summary>
    /// ViewModel for company instances.
    /// </summary>
    public class CompanyViewModel : ViewModelBase<Guid, Company>
    {
        private ICompanyService service = CommonServiceLocator.ServiceLocator.Current.GetInstance<ICompanyService>();

        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyViewModel"/> class.
        /// </summary>
        /// <param name="company"></param>
        public CompanyViewModel(Company company) : base(company)
        {
            this.Model = company;
            this.Collection = new ObservableCollection<Company>();
        }

        #region Public Props
        /// <summary>
        /// Gets or sets the unique identifier of the company.
        /// </summary>
        public Guid Guid
        {
            get => Model.Guid;
            set
            {
                if (!Equals(value, Model.Guid))
                {
                    Model.Guid = value;
                    OnPropertyChanged(nameof(Guid));
                }
            }
        }

        /// <summary>
        /// Gets or sets the name of the company.
        /// </summary>
        public string Name
        {
            get => Model.Name;
            set
            {
                if (!Equals(value, Model.Name))
                {
                    Model.Name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        /// <summary>
        /// Gets or sets the type of the company.
        /// </summary>
        public string Type
        {
            get => Model.Type;
            set
            {
                if (!Equals(value, Model.Type))
                {
                    Model.Type = value;
                    OnPropertyChanged(nameof(Type));
                }
            }
        }

        /// <summary>
        /// Indicates whether the company is active.
        /// </summary>
        public bool IsActive
        {
            get => Model.IsActive;
            set
            {
                if (!Equals(value, Model.IsActive))
                {
                    Model.IsActive = value;
                    OnPropertyChanged(nameof(IsActive));
                }
            }
        }

        /// <summary>
        /// Gets or sets the unique identifier of the primary contact person of a company.
        /// </summary>
        public Guid? CompanyContact
        {
            get => Model.CompanyContact;
            set
            {
                if (!Equals(value, Model.CompanyContact))
                {
                    Model.CompanyContact = value;
                    OnPropertyChanged(nameof(CompanyContact));
                }
            }
        }

        /// <summary>
        /// Gets or sets the unique identifier of the contact who created the company.
        /// </summary>
        public Guid? ContactGuid
        {
            get => Model.ContactGuid;
            set
            {
                if (!Equals(value, Model.ContactGuid))
                {
                    Model.ContactGuid = value;
                    OnPropertyChanged(nameof(ContactGuid));
                }
            }
        }

        /// <summary>
        /// Gets or sets the unique identifier of the user who created the company.
        /// </summary>
        public Guid UserGuid
        {
            get => Model.UserGuid;
            set
            {
                if (!Equals(value, Model.UserGuid))
                {
                    Model.UserGuid = value;
                    OnPropertyChanged(nameof(UserGuid));
                }
            }
        }
        #endregion
    }
}
