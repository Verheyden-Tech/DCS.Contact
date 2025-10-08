using DCS.CoreLib.BaseClass;

namespace DCS.Contact.Service
{
    /// <summary>
    /// Provides functionality for managing and accessing type-related data.
    /// </summary>
    /// <remarks>The <see cref="TypeService"/> class extends the <see cref="ServiceBase{TKey, TEntity,
    /// TRepository}"/> class, specializing it for operations involving <see cref="Type"/> entities and their associated
    /// repository interface, <see cref="ITypeRepository"/>.</remarks>
    public class TypeService : ServiceBase<Guid, Type, ITypeRepository>, ITypeService
    {
        private readonly ITypeRepository repository = CommonServiceLocator.ServiceLocator.Current.GetInstance<ITypeRepository>();

        /// <summary>
        /// Initializes a new instance of the <see cref="TypeService"/> class with the specified repository.
        /// </summary>
        /// <param name="repository">The repository used to manage and access type-related data. This parameter cannot be <see langword="null"/>.</param>
        public TypeService(ITypeRepository repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
