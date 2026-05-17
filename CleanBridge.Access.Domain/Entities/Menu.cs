using CleanBridge.Abstraction.Domain;
using CleanBridge.Access.Domain.UpdateData;

namespace CleanBridge.Access.Domain.Entities
{
    public class Menu : Entity
    {
        private readonly List<Menu> _children = new();
        private readonly List<MenuAction> _menuActions = new();

        public Guid MenuId { get; private set; }
        public Guid? ParentMenuId { get; private set; }
        public string Name { get; private set; } = null!;
        public string? Url { get; private set; }
        public int Order { get; private set; }
        public bool Active { get; private set; }

        public IReadOnlyCollection<Menu> Children => _children.AsReadOnly();
        public IReadOnlyCollection<MenuAction> MenuActions => _menuActions.AsReadOnly();

        private Menu()
        {
        }

        public Menu(string name, string url, Guid? parentMenuId, int orden)
        {
            ValidateName(name);

            MenuId = Guid.NewGuid();
            ParentMenuId = parentMenuId;
            Name = name.Trim();
            Url = url.Trim();
            Order = orden;
            Active = true;
        }

        public Menu(string name, Guid? parentMenuId, int orden)
        {
            ValidateName(name);

            MenuId = Guid.NewGuid();
            ParentMenuId = parentMenuId;
            Name = name.Trim();
            Url = null;
            Order = orden;
            Active = true;
        }

        public void Update(MenuUpdateData data)
        {
            if (data.ParentMenuId.HasValue)
            {
                if (data.ParentMenuId.Value == MenuId)
                    throw new ArgumentException("Un menú no puede ser padre de sí mismo.", nameof(data.ParentMenuId));

                ParentMenuId = data.ParentMenuId.Value;
            }

            if (data.Name.HasValue)
            {
                ValidateName(data.Name.Value);
                Name = data.Name.Value!;
            }

            if (data.Url.HasValue)
            {
                ValidateUrl(data.Url.Value);
                Url = data.Url.Value!;
            }
        }

        public void AddChild(Menu child)
        {
            if (child.MenuId == MenuId)
                throw new InvalidOperationException("Un menú no puede ser hijo de sí mismo.");

            if (child.ParentMenuId == MenuId)
                throw new InvalidOperationException("El menú hijo no pertenece a este menú padre.");

            if (_children.Any(c => c.MenuId == child.MenuId)) return;

            _children.Add(child);
        }

        public void RemoveChild(Menu child)
        {
            var menu = _children.SingleOrDefault(c => c.MenuId == child.MenuId);
            if (menu is null) return;

            _children.Remove(menu);
        }

        public void AddAction(int actionCode)
        {
            if (_menuActions.Any(m => m.ActionCode == actionCode)) return;

            _menuActions.Add(MenuAction.Create(MenuId, actionCode));
        }

        public void RemoveAction(int actionCode)
        {
            var manuAction = _menuActions.SingleOrDefault(m => m.ActionCode == actionCode);
            if (manuAction is null) return;

            _menuActions.Remove(manuAction);
        }

        public void Enable()
        {
            Active = true;
        }

        public void Disable()
        {
            Active = false;
        }

        private static void ValidateName(string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("El nombre no puede estar vacio.", nameof(name));

            var trimedName = name.Trim();
            if (trimedName.Length > 100)
                throw new ArgumentException("El nombre no puese superar los 100 caracteres.", nameof(name));
        }

        private static void ValidateUrl(string? url)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentNullException("La URL no puede estar vacia.", nameof(url));
        }

        protected override IEnumerable<object?> GetKeys()
        {
            yield return MenuId;
        }
    }
}
