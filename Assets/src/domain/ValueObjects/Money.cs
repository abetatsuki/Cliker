using System;

namespace Src.Domain.ValueObjects
{
    /// <summary>
    /// 金額を表す値オブジェクト。
    /// </summary>
    public readonly struct Money : IEquatable<Money>
    {
        /// <summary>
        /// 0以上の金額でMoneyを生成する。
        /// </summary>
        /// <param name="amount">　金額　</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// 金額が0未満の場合にスローされる。
        /// </exception>
        public Money(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "金額は0以上でなければなりません。");
            }

            _amount = amount;
        }

        public int Amonut {  get { return _amount; } }

        /// <summary>
        /// 指定した金額を加算した結果を返す。
        /// </summary>
        public Money Add(Money other)
        {
            checked
            {
                return new Money(_amount + other._amount);
            }
        }

        /// <summary>
        /// 指定した金額の減算を試みる。
        /// </summary>
        public bool CanSubtract(Money cost)
        {
            if (_amount - cost._amount < 0)
            {
                return false;
            }
            return true;
        }

        public Money Subtract(Money cost)
        {
            return new Money(_amount - cost._amount);
        }
        /// <summary>
        /// 指定した金額以上の残高があるか判定する。
        /// </summary>
        public bool IsEnough(Money other)
        {
            return _amount >= other._amount;
        }

        /// <summary>
        /// オブジェクトが同じ金額のMoneyか判定する。
        /// </summary>
        public override bool Equals(object obj)
        {
            return obj is Money money && Equals(money);
        }
        /// <summary>
        /// 同じ金額をもつMoneyを等しいとみなす。
        /// </summary>
        public bool Equals(Money other)
        {
            return _amount == other._amount;
        }
        /// <summary>
        /// 金額に基づいたハッシュコードを返す。
        /// </summary>
        public override int GetHashCode()
        {
            return _amount.GetHashCode();
        }

        /// <summary>
        /// 金額の等価性を比較する。
        /// </summary>
        public static bool operator ==(Money left, Money right)
        {
            return left.Equals(right);
        }
        public static bool operator !=(Money left, Money right)
        {
            return !left.Equals(right);
        }
        public static bool operator >(Money left, Money right)
        {
            return left._amount > right._amount;
        }
        public static bool operator <(Money left, Money right)
        {
            return left._amount < right._amount;
        }
        public static bool operator >=(Money left, Money right)
        {
            return left._amount >= right._amount;
        }

        public static bool operator <=(Money left, Money right)
        {
            return left._amount <= right._amount;
        }

        private readonly int _amount;
    }
}