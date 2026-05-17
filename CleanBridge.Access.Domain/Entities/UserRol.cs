using CleanBridge.Abstraction.Domain;

namespace CleanBridge.Access.Domain.Entities
{
    public class UserRol : Entity
    {
        public Guid UserId { get; private set; }
        public Guid RolId { get; private set; }

        private UserRol()
        {
        }

        public UserRol(Guid userId, Guid rolId)
        {
            UserId = userId;
            RolId = rolId;
        }

        public static UserRol Create(Guid userId, Guid rolId)
            => new UserRol(userId, rolId);

        protected override IEnumerable<object?> GetKeys()
        {
            yield return UserId;
            yield return RolId;
        }
    }
}
