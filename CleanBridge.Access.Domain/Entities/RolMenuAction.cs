using CleanBridge.Abstraction.Domain;

namespace CleanBridge.Access.Domain.Entities
{
    public class RolMenuAction : Entity
    {
        public Guid RolId { get; private set; }
        public Guid MenuId { get; private set; }
        public int ActionCode { get; private set; }

        private RolMenuAction()
        {
        }

        public RolMenuAction(Guid rolId, Guid menuId, int actionCode)
        {
            Action.ValidationActionCode(actionCode);

            RolId = rolId;
            MenuId = menuId;
            ActionCode = actionCode;
        }

        protected override IEnumerable<object?> GetKeys()
        {
            yield return RolId;
            yield return MenuId;
            yield return ActionCode;
        }

        public static RolMenuAction Create(Guid rolId, Guid menuId, int actionCode)
            => new RolMenuAction(rolId, menuId, actionCode);
    }
}
