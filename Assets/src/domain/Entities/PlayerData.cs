
using Cliker.Domain.ValueObjects;
using UnityEngine;
namespace Src.Domain.Entities
{
    public class PlayerData : MonoBehaviour
    {
        private Money _money;

        /// <summary>
        /// 所持金を増加させる。
        /// </summary>
        public void AddMoney(Money amount)
        {
            _money.Add(amount);
        }

    }
}