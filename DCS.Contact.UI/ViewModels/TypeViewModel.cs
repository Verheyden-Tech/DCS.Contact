using DCS.CoreLib.BaseClass;

namespace DCS.Contact.UI
{
    /// <summary>
    /// Represents a view model for a <see cref="Type"/> object, providing data binding and notification support for its
    /// properties.
    /// </summary>
    /// <remarks>This class extends <see cref="ViewModelBase{TKey, TModel}"/> to provide a strongly-typed view
    /// model for <see cref="Type"/> objects. It exposes key properties of the underlying <see cref="Type"/> model, such
    /// as <see cref="Guid"/>, <see cref="Name"/>, and <see cref="IsActive"/>, and raises property change notifications
    /// when these properties are updated.</remarks>
    public class TypeViewModel : ViewModelBase<Guid, Type>
    {
        private readonly ITypeService typeService = CommonServiceLocator.ServiceLocator.Current.GetInstance<ITypeService>();

        /// <summary>
        /// Initializes a new instance of the <see cref="TypeViewModel"/> class using the specified <see cref="Type"/>.
        /// </summary>
        /// <param name="type">The <see cref="Type"/> that this view model represents. Cannot be <see langword="null"/>.</param>
        public TypeViewModel(Type type) : base(type)
        {
            this.Model = type;
        }

        /// <summary>
        /// Saves the current model.
        /// </summary>
        /// <remarks>The method attempts to save the model using the associated type service.  If the
        /// model is null, the save operation will not be performed, and the method will return <see
        /// langword="false"/>.</remarks>
        /// <returns><see langword="true"/> if the model is successfully saved; otherwise, <see langword="false"/>.</returns>
        public bool Save()
        {
            if(Model != null)
            {
                if (typeService.New(this.Model))
                    return true;

                return false;
            }

            return false;
        }

        #region Properties
        /// <summary>
        /// Gets or sets the unique identifier associated with the type.
        /// </summary>
        public Guid Guid
        {
            get { return this.Model.Guid; }
            set
            {
                if (this.Model.Guid != value)
                {
                    this.Model.Guid = value;
                    OnPropertyChanged(nameof(Guid));
                }
            }
        }

        /// <summary>
        /// Gets or sets the name associated with the type.
        /// </summary>
        public string Name
        {
            get { return this.Model.Name; }
            set
            {
                if (this.Model.Name != value)
                {
                    this.Model.Name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the current type is active.
        /// </summary>
        public bool IsActive
        {
            get { return this.Model.IsActive; }
            set
            {
                if (this.Model.IsActive != value)
                {
                    this.Model.IsActive = value;
                    OnPropertyChanged(nameof(IsActive));
                }
            }
        }
        #endregion
    }
}
