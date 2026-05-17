using CleanBridge.Abstraction.Domain;
using CleanBridge.Access.Domain.UpdateData;

namespace CleanBridge.Access.Domain.Entities
{
    public class Rol : Entity
    {
        private readonly List<RolApiAction> _rolApiActions = new();
        private readonly List<RolMenuAction> _rolMenuActions = new();

        public Guid RolId { get; private set; }
        public string RolName { get; private set; } = null!;

        public IReadOnlyCollection<RolApiAction> RolApiActions => _rolApiActions.AsReadOnly();
        public IReadOnlyCollection<RolMenuAction> RolMenuActions => _rolMenuActions.AsReadOnly();

        private Rol()
        {
        }

        public Rol(string rolName)
        {
            ValidateRolName(rolName);

            RolId = Guid.NewGuid();
            RolName = rolName.Trim();
        }

        public void Update(RolUpdateData data)
        {
            if (data.RolName.HasValue)
            {
                ValidateRolName(data.RolName.Value);
                RolName = data.RolName.Value!.Trim();
            }
        }

        public void AddRolApiAction(ApiAction apiAction)
        {
            if (_rolApiActions.Any(r => r.ApiId == apiAction.ApiId && r.ActionCode == apiAction.ActionCode)) return;

            _rolApiActions.Add(RolApiAction.Create(RolId, apiAction.ApiId, apiAction.ActionCode));
        }

        public void RemoveRolApiAction(ApiAction apiAction)
        {
            var rolApiAction = _rolApiActions.SingleOrDefault(r => r.ApiId == apiAction.ApiId && r.ActionCode == apiAction.ActionCode);
            if (rolApiAction is null) return;

            _rolApiActions.Remove(rolApiAction);
        }

        public void AddRolMenuAction(MenuAction menuAction)
        {
            if (_rolMenuActions.Any(r => r.MenuId == menuAction.MenuId && r.ActionCode == menuAction.ActionCode)) return;

            _rolMenuActions.Add(RolMenuAction.Create(RolId, menuAction.MenuId, menuAction.ActionCode));
        }

        public void RemoveRolMenuAction(MenuAction menuAction)
        {
            var rolMenuAction = _rolMenuActions.SingleOrDefault(r => r.MenuId == menuAction.MenuId && r.ActionCode == menuAction.ActionCode);
            if (rolMenuAction is null) return;

            _rolMenuActions.Remove(rolMenuAction);
        }

        protected override IEnumerable<object?> GetKeys()
        {
            yield return RolId;
        }

        private static void ValidateRolName(string? rolName)
        {
            if (string.IsNullOrWhiteSpace(rolName))
                throw new ArgumentNullException("El nombre del rol no puede estar vacio.", nameof(rolName));

            var trimedRolName = rolName.Trim();
            if (trimedRolName.Length > 100)
                throw new ArgumentException("El nombre del rol no puede superar los 100 caracteres.", nameof(rolName));
        }
    }
}
