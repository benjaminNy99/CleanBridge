using CleanBridge.Abstraction.Domain;

namespace CleanBridge.Access.Domain.Entities
{
    public class MenuAction : Entity
    {
        public Guid MenuId { get; private set; }
        public int ActionCode { get; private set; }

        private MenuAction()
        {
        }

        public MenuAction(Guid menuId, int actionCode)
        {
            Action.ValidationActionCode(actionCode);

            MenuId = menuId;
            ActionCode = actionCode;
        }

        protected override IEnumerable<object?> GetKeys()
        {
            yield return MenuId;
            yield return ActionCode;
        }

        public static MenuAction Create(Guid menuId, int actionCode)
            => new MenuAction(menuId, actionCode);
    }
}
