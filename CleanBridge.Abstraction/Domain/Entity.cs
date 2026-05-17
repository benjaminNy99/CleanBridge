namespace CleanBridge.Abstraction.Domain
{
    public abstract class Entity : IEntity
    {
        protected abstract IEnumerable<object?> GetKeys();

        public override bool Equals(object? obj)
        {
            if (obj is not Entity other) return false;
            if (ReferenceEquals(this, other)) return true;
            if (GetType() != other.GetType()) return false;

            return GetKeys().SequenceEqual(other.GetKeys());
        }

        public override int GetHashCode()
        {
            var hash = new HashCode();
            hash.Add(GetType());

            foreach (var key in GetKeys())
                hash.Add(key);

            return hash.ToHashCode();
        }
    }
}
