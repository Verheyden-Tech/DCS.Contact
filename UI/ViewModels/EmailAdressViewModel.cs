using DCS.Contact;
using DCS.DefaultTemplates;
using DCSBase.Services.Interfaces;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace DCSBase.Contacts
{
    public class EmailAdressViewModel : IViewModelBase<Email>
    {
        private IEmailAdressService emailAdressService = CommonServiceLocator.ServiceLocator.Current.GetInstance<IEmailAdressService>();
        private DefaultCollection<Email> editEmailAdresses;
        private DefaultCollection<Email> addedEmailAdresses;

        private Email model;
        private DefaultCollection<Email> collection;

        public EmailAdressViewModel() : base()
        {
            Collection = new DefaultCollection<Email>();
            editEmailAdresses = new DefaultCollection<Email>();
            addedEmailAdresses = new DefaultCollection<Email>();
        }

        public EmailAdressViewModel(Email email) : this()
        {
            this.model = email;
        }

        public EmailAdressViewModel(Contact contact) : this()
        {
            this.SelectedContact = contact;

            if(contact != null)
            {
                collection = emailAdressService.GetAll();
            }

            if (Model == null && Collection != null && Collection.Count > 0)
            {
                model = Collection.First();
            }
            else
            {
                model = new Email();
            }
        }

        /// <summary>
        /// Gets a collection of all contact assigned email adresses.
        /// </summary>
        /// <param name="contact">Given contact.</param>
        /// <returns>Contact assigned email adresses.</returns>
        public DefaultCollection<Email> GetContactEmailAdresses(Contact contact)
        {
            if(contact == null)
                throw new ArgumentNullException("contact");

            return emailAdressService.GetAllByContact(contact.Guid);
        }

        /// <summary>
        /// Adds new EmailAdress to the Contacts EmailCollection.
        /// </summary>
        /// <param name="emailAdress">Email to add.</param>
        /// <returns>Wether the add was succesful.</returns>
        public bool AddEmailAdress(Email emailAdress)
        {
            if(emailAdress != null)
            {
                if(!this.Collection.Contains(emailAdress))
                {
                    addedEmailAdresses.Add(emailAdress);
                    this.Collection.Add(emailAdress);
                    return true;
                }
                return false;
            }
            return false;
        }

        /// <summary>
        /// Removes old EmailAdress and adds new EmailAdress (edited old Adress).
        /// </summary>
        /// <param name="emailAdress">Edited EmailAdress to add.</param>
        /// <returns>Wether the editet add was succesfull.</returns>
        public bool EditEmailAdress(Email emailAdress)
        {
            if(emailAdress != null)
            {
                var oldEmail = Collection.Where(e => e.Guid == emailAdress.Guid).FirstOrDefault();
                if(oldEmail != null)
                {
                    Collection.Remove(oldEmail);
                    editEmailAdresses.Add(emailAdress);
                    Collection.Add(emailAdress);

                    return true;
                }
                return false;
            }
            return false;
        }

        /// <summary>
        /// Saves the two Collections by their isCreate state.
        /// </summary>
        /// <param name="addedEmails">IsCreate == true</param>
        /// <param name="editEmails">IsCreate == false</param>
        /// <returns>Wether the save was succesful.</returns>
        public bool SaveEmailAdresses(DefaultCollection<Email> addedEmails, DefaultCollection<Email> editEmails)
        {
            if (addedEmails != null && editEmails != null)
            {
                try
                {
                    foreach (var email in addedEmails)
                    {
                        emailAdressService.New(email);
                    }
                    foreach (var email in editEmails)
                    {
                        emailAdressService.Update(email);
                    }

                    //Clear lists if saved to avoid double savings.
                    addedEmailAdresses.Clear();
                    editEmailAdresses.Clear();

                    return true;
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException($"An Error occuret while trying to save EmailAdresses. {ex}");
                }

            }
            return false;
        }

        public bool Add(Email obj)
        {
            return AddEmailAdress(obj);
        }

        public bool Edit(Email obj)
        {
            return EditEmailAdress(obj);
        }

        public bool Remove(Email obj)
        {
            if(obj != null)
            {
                try
                {
                    if(emailAdressService.Delete(obj.Guid))
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Fehler beim löschen von '{obj.MailAdress}'. {ex}", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }

            return false;
        }

        #region Public Props
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

        public DefaultCollection<Email> Collection
        {
            get
            {
                return collection;
            }
            set
            {
                collection = value;
            }
        }

        public Contact SelectedContact { get; set; }

        public Email Model => model;
    }
}
