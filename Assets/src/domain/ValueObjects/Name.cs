using System;

namespace Src.Domain.ValueObjects
{
    public sealed record Name
    {
        public string Value { get; }

        public Name(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("名前は必須です。", nameof(value));
            }

            if (value.Length > MaxLength)
            {
                throw new ArgumentException($"名前は{MaxLength}文字以内でなければなりません。", nameof(value));
            }

            Value = value;
        }

        public const int MaxLength = 10;
    }
}