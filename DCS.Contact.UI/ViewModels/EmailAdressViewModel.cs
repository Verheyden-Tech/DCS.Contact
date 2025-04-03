using DCS.DefaultTemplates;
using System.Collections.ObjectModel;

namespace DCS.Contact.UI
{
    /// <summary>
    /// ViewModel for EmailAdress.
    /// </summary>
    public class EmailAdressViewModel : ViewModelBase<Guid, Email>
    {
        private IEmailAdressService emailAdressService = CommonServiceLocator.ServiceLocator.Current.GetInstance<IEmailAdressService>();

        /// <summary>
        /// Constructor for EmailAdressViewModel.
        /// </summary>
        public EmailAdressViewModel(Email email) : base()
        {
            this.Model = email;
            this.Collection = new ObservableCollection<Email>();
        }

        #region Public Props
        /// <summary>
        /// Gets or sets the guid of a email adress.
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
        /// Gets or sets the type of a email adress.
        /// </summary>
        public string Type
        {
            get
            {
                return Model.Type;
            }
            set
            {
                Model.Type = value;
            }
        }

        /// <summary>
        /// Gets or sets the mail adress.
        /// </summary>
        public string MailAdress
        {
            get
            {
                return Model.MailAdress;
            }
            set
            {
                Model.MailAdress = value;
            }
        }
        #endregion
    }
}
