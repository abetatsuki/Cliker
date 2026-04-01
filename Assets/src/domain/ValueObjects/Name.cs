using System;
namespace Src.Domain.ValueObjects
{
    public class Name : IEquatable<Name>
    {
        /// <summary>
        /// 文字数上限以内で名前を生成する。
        /// </summary>
        /// <param name="name">　名前　</param>
        /// <exception cref="ArgumentException">
        /// 名前が文字数上限を超えてる場合はスローする。
        /// </exception>
        public Name(string name)
        {
            if (name == null) return;
            if (name.Length > _nameLength)
            {
                throw new ArgumentException(nameof(name), $"名前は{_nameLength}以内でなければなりません。");
            }
            _name = name;
        }

        /// <summary>
        /// 同じ名前を持つNameを等しいとみなす。
        /// </summary>
        public bool Equals(Name other)
        {
            return _name == other._name;
        }

        /// <summary>
        /// 名前に基づいたハッシュコードを返す。
        /// </summary>
        public override int GetHashCode()
        {
            return _name.GetHashCode();
        }


        private const int _nameLength = 10;
        private readonly string _name;
    }
}