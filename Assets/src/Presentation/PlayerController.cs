using Src.Domain.Entities;
using UnityEngine;
using Src.Domain.ValueObjects;
namespace Src.Application
{
    public class PlayerController : MonoBehaviour
    {
        
        public void LoginTest(Player player)
        {
            Debug.Log($"Name {player.Name.Value} Id {player.Id.Value} Money {player.Money.Amonut}");
        }
        private void Start()
        {
            LoginTest(RuntimeDataManager.Player);
            RuntimeDataManager.Player.AddMoney(new Money(100));
        }

        private void OnDestroy()
        {
            RuntimeDataManager.PlayerAppService.Save(RuntimeDataManager.Player);
        }
    }
}

