using DCS.CoreLib;
using DCS.CoreLib.BaseClass;

namespace DCS.Contact
{
    /// <summary>
    /// Represents a type of an object with a unique identifier, a name, and an active status.
    /// </summary>
    /// <remarks>This class provides a structure for defining an entity with a globally unique identifier
    /// (GUID), a descriptive name, and a boolean flag indicating whether the entity is active.</remarks>
    public class Type : ModelBase, IEntity<Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Type"/> class.
        /// </summary>
        public Type() { }
    }
}
