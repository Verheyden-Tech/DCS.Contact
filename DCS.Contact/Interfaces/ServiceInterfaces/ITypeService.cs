using DCS.CoreLib;

namespace DCS.Contact
{
    /// <summary>
    /// Defines a contract for services that manage and provide access to type-related data.
    /// </summary>
    /// <remarks>This interface extends <see cref="ITypeRepository"/>, inheriting its functionality for
    /// accessing type data. Implementations of this interface may include additional business logic or service-specific
    /// operations related to type management.</remarks>
    public interface ITypeService : IServiceBase<Guid, Type, ITypeRepository>
    {
    }
}
