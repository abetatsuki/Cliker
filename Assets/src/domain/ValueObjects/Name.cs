using System;
namespace Src.Domain.ValueObjects
{
    public record struct Name
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
            if (name.Length > _nameLength)
            {
                throw new ArgumentException(nameof(name), $"名前は{_nameLength}以内でなければなりません。");
            }
            _name = name;
        }
        public string Value { get { return _name; } }
        private const int _nameLength = 10;
        private readonly string _name;
    }
}