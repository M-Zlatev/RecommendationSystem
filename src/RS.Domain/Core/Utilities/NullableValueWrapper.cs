namespace RS.Domain.Core.Utilities;

    /// <summary>
    /// Represents a wrapper around a value that may or may not be null.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    public sealed class NullableValueWrapper<T> : IEquatable<NullableValueWrapper<T>>
    {
        private readonly T _value;

    /// <summary>
    /// Initializes a new instance of the <see cref="NullableValueWrapper{T}"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    private NullableValueWrapper(T value) => _value = value;

        /// <summary>
        /// Gets a value indicating whether or not the value exists.
        /// </summary>
        public bool HasValue => !HasNoValue;

        /// <summary>
        /// Gets a value indicating whether or not the value does not exist.
        /// </summary>
        public bool HasNoValue => _value is null;

        /// <summary>
        /// Gets the value.
        /// </summary>
        public T Value => HasValue
            ? _value
            : throw new InvalidOperationException("The value can not be accessed because it does not exist.");

        /// <summary>
        /// Gets the default empty instance.
        /// </summary>
        public static NullableValueWrapper<T> None => new NullableValueWrapper<T>(default);

    /// <summary>
    /// Creates a new <see cref="NullableValueWrapper{T}"/> instance based on the specified value.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The new <see cref="NullableValueWrapper{T}"/> instance.</returns>
    public static NullableValueWrapper<T> From(T value) => new NullableValueWrapper<T>(value);

        public static implicit operator NullableValueWrapper<T>(T value) => From(value);

        public static implicit operator T(NullableValueWrapper<T> maybe) => maybe.Value;

        /// <inheritdoc />
        public bool Equals(NullableValueWrapper<T> other)
        {
            if (other is null)
            {
                return false;
            }

            if (HasNoValue && other.HasNoValue)
            {
                return true;
            }

            if (HasNoValue || other.HasNoValue)
            {
                return false;
            }

            return Value.Equals(other.Value);
        }

        /// <inheritdoc />
        public override bool Equals(object obj) =>
            obj switch
            {
                null => false,
                T value => Equals(new NullableValueWrapper<T>(value)),
                NullableValueWrapper<T> maybe => Equals(maybe),
                _ => false
            };

        /// <inheritdoc />
        public override int GetHashCode() => HasValue ? Value.GetHashCode() : 0;
    }

