using CleanBridge.Abstraction.Domain;

namespace CleanBridge.Access.Domain.UpdateData
{
    public class MenuUpdateData
    {
        public Optional<Guid?> ParentMenuId { get; init; }
        public Optional<string> Name { get; init; }
        public Optional<string?> Url { get; init; }
    }
}
