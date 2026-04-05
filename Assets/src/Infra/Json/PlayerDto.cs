using Src.Domain.Entities;
using Src.Domain.ValueObjects;
using System;
namespace Src.Infra.Json
{
    public class PlayerDto
    {
        public int Id;
        public string Name;
        public int Money;

        public static PlayerDto ToDto(Player player) => new PlayerDto
        {
            Id = player.Id.Value,
            Name = player.Name.Value,
            Money = player.Money.Amonut
        };
        public static bool FromDto(PlayerDto dto, out PlayerId id, out Name name, out Money money)
        {
            id = null;
            name = null;
            money = default;

            if (dto == null) return false;

            try
            {
                id = new PlayerId(dto.Id);
                name = new Name(dto.Name);
                money = new Money(dto.Money);
                return true;
            }
            catch (ArgumentException)
            {
                return false;
            }
        }

    }
}