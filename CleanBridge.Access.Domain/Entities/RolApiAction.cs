using CleanBridge.Abstraction.Domain;

namespace CleanBridge.Access.Domain.Entities
{
    public class RolApiAction : Entity
    {
        public Guid RolId { get; private set; }
        public Guid ApiId { get; private set; }
        public int ActionCode { get; private set; }

        private RolApiAction()
        {
        }

        public RolApiAction(Guid rolId, Guid apiId, int actionCode)
        {
            Action.ValidationActionCode(actionCode);

            RolId = rolId;
            ApiId = apiId;
            ActionCode = actionCode;
        }

        protected override IEnumerable<object?> GetKeys()
        {
            yield return RolId;
            yield return ApiId;
            yield return ActionCode;
        }

        internal static RolApiAction Create(Guid rolId, Guid apiId, int actionCode)
            => new RolApiAction(rolId, apiId, actionCode);
    }
}
