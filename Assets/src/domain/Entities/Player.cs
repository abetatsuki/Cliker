
using Src.Domain.ValueObjects;
namespace Src.Domain.Entities
{
    /// <summary>
    /// プレイヤールート
    /// </summary>
    public class Player 
    {
        public Player(PlayerId id,Name name,Money money)
        {
            _id = id;
            _name = name;
            _money = money;
        }
        public PlayerId Id { get { return _id; } }
        public Name Name { get { return _name; } }
        public Money Money { get { return _money; } }
        /// <summary>
        /// 所持金を増加させる。
        /// </summary>
        public void AddMoney(Money amount)
        {
            _money.Add(amount);
        }
        public bool TrySubtract(Money cost)
        {
            if (!_money.CanSubtract(cost))return false;
            _money.Subtract(cost);
            return true;
        }
        public void Click()
        {
            _money.Add(new Money(1));
        }
        public bool TryBuy(Money cost)
        {
            if (!_money.CanSubtract(cost)) return false;
            _money.Subtract(cost);
            return true;
        }
        public void ChangeName(Name name)
        {
            if (name == _name) return;
            _name = name;
        }
        public void SetId(PlayerId id)
        {
            _id = id;
        }

        private PlayerId _id;
        private Money _money;
        private Name _name;
    }
}