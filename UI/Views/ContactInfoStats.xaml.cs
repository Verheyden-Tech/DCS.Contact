using DCS.DefaultViewControls;

namespace DCS.Contact.UI
{
    /// <summary>
    /// Interaction logic for ContactInfoStats.xaml
    /// </summary>
    public partial class ContactInfoStats : DefaultAppControl
    {
        private ContactInfoStatsViewModel viewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactInfoStats"/> class.
        /// </summary>
        /// <param name="contact"></param>
        public ContactInfoStats(Contact contact)
        {
            InitializeComponent();

            viewModel = new ContactInfoStatsViewModel(contact);
            this.DataContext = viewModel;
        }
    }
}
