using Src.Domain.Entities;
using Src.Domain.Factories;
using Src.Domain.ValueObjects;
public class PlayerFactory : IPlayerFactroy
{
    public Player CreateNormal(PlayerId id,Name name,Money money)
    {
        return new Player(
            id,
            name,
            money = default
            );
    }

    public Player CreateVip(PlayerId id , Name name, Money money)
    {
        return new Player(
            id,
            name,
            money.Add(new Money(1000))
            );
    }
}
