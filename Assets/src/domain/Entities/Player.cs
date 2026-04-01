
using Src.Domain.ValueObjects;
namespace Src.Domain.Entities
{
    /// <summary>
    /// プレイヤールート
    /// </summary>
    public class Player : IEntity
    {
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
        public void SetId(int id)
        {
            _id = id;
        }
        public override int Id => _id;

        private  int _id;
        private Money _money;
        private Name _name;
    }
}