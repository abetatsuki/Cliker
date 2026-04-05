using Src.Domain.Entities;
using Src.Domain.Factories;
using Src.Domain.ValueObjects;
public class PlayerFactory : IPlayerFactory
{
    public PlayerFactory() { }
    public Player CreateNewNormal(PlayerId id, Name name)
    {
        return new Player(
           id,
           name,
           new Money(default)
           );
    }

    public Player CreateNewVip(PlayerId id, Name name)
    {
        return new Player(
           id,
           name,
           new Money(1000)
           );
    }

    public Player CreateNormal(PlayerId id,Name name,Money money)
    {
        return new Player(
            id,
            name,
            money
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
