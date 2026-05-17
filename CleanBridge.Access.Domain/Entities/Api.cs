using CleanBridge.Abstraction.Domain;
using CleanBridge.Access.Domain.UpdateData;

namespace CleanBridge.Access.Domain.Entities
{
    public class Api : Entity
    {
        private readonly List<ApiAction> _apiActions;

        public Guid ApiId { get; private set; }
        public string Url { get; private set; } = null!;
        public bool Active { get; private set; }

        public IReadOnlyCollection<ApiAction> ApiActions => _apiActions.AsReadOnly();

        private Api()
        {
        }

        public Api(string url)
        {
            ValidateUrl(url);

            ApiId = Guid.NewGuid();
            Url = url;
            Active = true;
        }

        public void Update(ApiUpdateData data)
        {
            if (data.Url.HasValue)
            {
                ValidateUrl(data.Url.Value);
                Url = data.Url.Value!;
            }
        }

        public void AddAction(int actionCode)
        {
            if (_apiActions.Any(m => m.ActionCode == actionCode)) return;

            _apiActions.Add(ApiAction.Create(ApiId, actionCode));
        }

        public void RemoveAction(int actionCode)
        {
            var manuAction = _apiActions.SingleOrDefault(m => m.ActionCode == actionCode);
            if (manuAction is null) return;

            _apiActions.Remove(manuAction);
        }

        public void Enable()
        {
            Active = true;
        }

        public void Disable()
        {
            Active = false;
        }

        protected override IEnumerable<object?> GetKeys()
        {
            yield return ApiId;
        }

        private static void ValidateUrl(string? url)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentNullException("La URL no puede estar vacia.", nameof(url));
        }
    }
}
