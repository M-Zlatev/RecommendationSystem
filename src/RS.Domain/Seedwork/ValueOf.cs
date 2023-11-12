namespace RS.Domain.Seedwork
{
    public abstract class ValueOf<T> : ValueObject
    {
        protected delegate bool TryValidateDelegate(T value, out Exception exception);

        protected ValueOf(T value, TryValidateDelegate tryValidate)
        {
            if (!tryValidate(value, out var exception)) throw exception;
            Value = value;
        }

        public T Value { get; protected set; }

        public static implicit operator T(ValueOf<T> value)
        {
            if (value is null) throw new ArgumentNullException(nameof(value));
            return value.Value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
