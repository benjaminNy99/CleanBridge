using CleanBridge.Abstraction.Domain;

namespace CleanBridge.Access.Domain.Entities
{
    public class ApiAction : Entity
    {
        public Guid ApiId { get; private set; }
        public int ActionCode { get; private set; }

        private ApiAction()
        {
        }

        public ApiAction(Guid apiId, int actionCode)
        {
            Action.ValidationActionCode(actionCode);

            ApiId = apiId;
            ActionCode = actionCode;
        }

        protected override IEnumerable<object?> GetKeys()
        {
            yield return ApiId;
            yield return ActionCode;
        }

        public static ApiAction Create(Guid apiId, int actionCode)
            => new ApiAction(apiId, actionCode);
    }
}
