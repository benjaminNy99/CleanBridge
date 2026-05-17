using CleanBridge.Abstraction.Domain;

namespace CleanBridge.Access.Domain.UpdateData
{
    public class UserUpdateData
    {
        public Optional<string?> Email { get; init; }
        public Optional<bool> IsAdmin { get; init; }
    }
}
