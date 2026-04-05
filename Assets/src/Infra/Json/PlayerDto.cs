using Src.Domain.Entities;
using Src.Domain.ValueObjects;
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
        public static bool FromDto(PlayerDto dto, out PlayerId id , out Name name , out Money moeny)
        {
            if (dto == null)
            {
                id = null;
                name = new Name();
                moeny = new Money(0);
                return false;
            }

            id = new PlayerId(dto.Id);
            name = new Name(dto.Name);
            moeny = new Money(dto.Money);
            return true;
        } 
    }
}