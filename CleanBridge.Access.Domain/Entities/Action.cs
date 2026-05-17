using CleanBridge.Abstraction.Domain;

namespace CleanBridge.Access.Domain.Entities
{
    public class Action : Entity
    {
        public int Code { get; private set; }
        public string Name { get; private set; } = null!;

        private Action()
        {
        }

        protected override IEnumerable<object?> GetKeys()
        {
            yield return Code;
        }

        internal static void ValidationActionCode(int actionCode)
        {
            if (actionCode <= 0 || actionCode > 5)
                throw new ArgumentException("Se debe asignar una acción permitida al menú.", nameof(actionCode));
        }
    }
}
