using Src.Domain.Entities;
using UnityEngine;
using Src.Domain.ValueObjects;
using System.IO;
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
            if (RuntimeDataManager.Player == null)
            {
                return;
            }
            LoginTest(RuntimeDataManager.Player);
            RuntimeDataManager.Player.AddMoney(new Money(100));
        }

        private void OnDestroy()
        {
            if (RuntimeDataManager.PlayerAppService == null) return;
            if (RuntimeDataManager.Player == null) return;

            RuntimeDataManager.PlayerAppService.Save(RuntimeDataManager.Player);
        }

    }
}

