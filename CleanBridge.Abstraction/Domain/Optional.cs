namespace CleanBridge.Abstraction.Domain
{
    public readonly struct Optional<T>
    {
        public bool HasValue { get; }
        public T? Value { get; }

        private Optional(T? value)
        {
            HasValue = true;
            Value = value;
        }

        public static Optional<T> Some(T? value)
        {
            return new Optional<T>(value);
        }
    }
}
