using Src.Domain.Entities;

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
    }
}