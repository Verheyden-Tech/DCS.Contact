using DCSBase;
using DCS.DefaultTemplates;
using DCS.Contact;
using System.Windows.Controls;

namespace DCSBase.Contacts
{
    /// <summary>
    /// Interaction logic for ContactInfoStats.xaml
    /// </summary>
    public partial class ContactInfoStats : DefaultAppControl
    {
        private ContactInfoStatsViewModel viewModel;

        public ContactInfoStats(Contact contact)
        {
            InitializeComponent();

            viewModel = new ContactInfoStatsViewModel(contact);
            this.DataContext = viewModel;
        }
    }
}
