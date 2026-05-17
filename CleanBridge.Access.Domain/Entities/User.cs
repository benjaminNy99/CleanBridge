using CleanBridge.Abstraction.Domain;
using CleanBridge.Access.Domain.UpdateData;

namespace CleanBridge.Access.Domain.Entities
{
    public class User : Entity
    {
        private readonly List<UserRol> _roles = new();

        public Guid UserId { get; private set; }
        public bool IsAdmin { get; private set; }
        public bool Blocked { get; private set; }
        public string? Email { get; private set; }
        public string Password { get; private set; } = null!;
        public DateTime? LastConnection { get; private set; }
        public DateTime CreationDate { get; private set; }

        public IReadOnlyCollection<UserRol> Roles => _roles.AsReadOnly();

        private User()
        {
        }

        public User(string? email, bool isAdmin, string password)
        {
            ValidateEmail(email);

            UserId = Guid.NewGuid();
            IsAdmin = isAdmin;
            Blocked = false;
            Email = email?.Trim();
            Password = password;
            CreationDate = DateTime.UtcNow;
        }

        public void Update(UserUpdateData data)
        {
            if (data.Email.HasValue)
            {
                ValidateEmail(data.Email.Value);
                Email = data.Email.Value;
            }
            if (data.IsAdmin.HasValue) IsAdmin = data.IsAdmin.Value;
        }

        public void Block()
        {
            Blocked = true;
        }

        public void UnBlock()
        {
            Blocked = false;
        }

        public void RegisterConnection()
        {
            LastConnection = DateTime.UtcNow;
        }

        public void AddRol(Rol rol)
        {
            if (_roles.Any(r => r.RolId == rol.RolId)) return;

            _roles.Add(UserRol.Create(UserId, rol.RolId));
        }

        public void RemoveRol(Rol rol)
        {
            var userRol = _roles.SingleOrDefault(r => r.RolId == rol.RolId);
            if (userRol is null) return;

            _roles.Remove(userRol);
        }

        protected override IEnumerable<object?> GetKeys()
        {
            yield return UserId;
        }

        private static void ValidateEmail(string? email)
        {
            if (string.IsNullOrWhiteSpace(email)) return;

            var trimmedEmail = email.Trim();
            if (trimmedEmail.Length > 254)
                throw new ArgumentException("El email no puede superar los 254 caracteres.", nameof(email));

            try
            {
                var address = new System.Net.Mail.MailAddress(trimmedEmail);
                if (address.Address != trimmedEmail)
                    throw new ArgumentException("El email no tiene un formato válido.", nameof(email));
            }
            catch
            {
                throw new ArgumentException("El email no tiene un formato válido.", nameof(email));
            }
        }
    }
}
