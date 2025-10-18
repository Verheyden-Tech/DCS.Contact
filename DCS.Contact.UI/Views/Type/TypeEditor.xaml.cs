using System.Windows;

namespace DCS.Contact.UI
{
    /// <summary>
    /// Interaction logic for TypeEditor.xaml
    /// </summary>
    public partial class TypeEditor : Window
    {
        private TypeViewModel viewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="TypeEditor"/> class.
        /// </summary>
        /// <remarks>This constructor sets up the <see cref="TypeEditor"/> by initializing its components,
        /// creating a new instance of the <see cref="Type"/> class, and associating a  <see cref="TypeViewModel"/> with
        /// the editor's data context.</remarks>
        public TypeEditor()
        {
            InitializeComponent();

            var obj = new Type();
            this.viewModel = new TypeViewModel(obj);
            this.DataContext = this.viewModel;
        }

        /// <summary>
        /// Gets the current <see cref="TypeViewModel"/> instance as data context.
        /// </summary>
        public TypeViewModel Current
        {
            get
            {
                return DataContext as TypeViewModel;
            }
        }

        private void SaveTypeButton_Click(object sender, RoutedEventArgs e)
        {
            if(Current.Model != null)
            {
                if (Current.UpdateType())
                    this.Close();
            }
        }
    }
}
