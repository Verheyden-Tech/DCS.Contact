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
        /// Creates a new type based on the current model and adds it to the collection if successful.
        /// </summary>
        /// <remarks>This method generates a new type using the properties of the <see cref="ViewModelBase{TKey, TModel}.Model"/>
        /// object, assigns it a unique identifier, and attempts to save it using the type service. If the operation
        /// succeeds, the new type is added to the <see cref="ViewModelBase{TKey, TModel}.Collection"/>. If the <see cref="ViewModelBase{TKey, TModel}.Model"/> is null or an
        /// exception occurs during the operation, the method logs an error and returns <see
        /// langword="false"/>.</remarks>
        /// <returns><see langword="true"/> if the new type is successfully created and added to the collection; otherwise, <see
        /// langword="false"/>.</returns>
        public bool CreateNewType()
        {
            if(Model != null)
            {
                try
                {
                    var newType = new Type
                    {
                        Guid = Guid.NewGuid(),
                        Name = Model.Name,
                        IsActive = Model.IsActive
                    };

                    if(typeService.New(newType))
                    {
                        Collection.Add(newType);
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Log.LogManager.Singleton.Error($"Exception occurred while creating new Type: {ex.Message}", "TypeViewModel.CreateNewType");
                    return false;
                }
            }

            Log.LogManager.Singleton.Error("Model is null. Cannot create new Type.", "TypeViewModel.CreateNewType");
            return false;
        }

        /// <summary>
        /// Updates the type information in the service based on the current model.
        /// </summary>
        /// <remarks>This method attempts to update an existing type in the service using the data from
        /// the current model. If the type does not exist, it attempts to create a new type. Logs are generated for any
        /// errors or exceptional conditions encountered during the operation.</remarks>
        /// <returns><see langword="true"/> if the type was successfully updated or created; otherwise, <see langword="false"/>.</returns>
        public bool UpdateType()
        {
            if(Model != null)
            {
                var type = typeService.Get(Model.Guid);
                if(type != null)
                {
                    try
                    {
                        var updatedType = new Type
                        {
                            Guid = Model.Guid,
                            Name = Model.Name,
                            IsActive = Model.IsActive
                        };

                        if (typeService.Update(updatedType))
                            return true;
                    }
                    catch (Exception ex)
                    {
                        Log.LogManager.Singleton.Error($"Exception occurred while updating Type: {ex.Message}", "TypeViewModel.UpdateType");
                        return false;
                    }
                }
                else
                    if(CreateNewType())
                        return true;

                Log.LogManager.Singleton.Error("Type not found in service. Cannot update Type.", "TypeViewModel.UpdateType");
                return false;
            }

            Log.LogManager.Singleton.Error("Model is null. Cannot update Type.", "TypeViewModel.UpdateType");
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
