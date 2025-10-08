using DCS.CoreLib.View;

namespace DCS.Contact.UI
{
    /// <summary>
    /// Interaction logic for EmailAdressEditor.xaml
    /// </summary>
    public partial class EmailAdressEditor : DefaultEditorWindow
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailAdressEditor"/> class.
        /// </summary>
        /// <remarks>This constructor sets up the necessary components for the <see
        /// cref="EmailAdressEditor"/>. Ensure that the required dependencies are properly configured before using this
        /// editor.</remarks>
        public EmailAdressEditor()
        {
            InitializeComponent();
        }

        private void CreateNewEmailTypeButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var win = new TypeEditor();
            if(win.ShowDialog() == true)
            {
                this.EmailAdressTypeBox.Text = win.TypeNameTextBox.Text;
            }
        }
    }
}
