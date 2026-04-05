
using Src.Domain.Entities;
using Src.Domain.ValueObjects;
namespace Src.Domain.Factories
{
    public interface IPlayerFactory
    {
        Player CreateNormal(PlayerId id,Name name,Money money);
        Player CreateVip(PlayerId id,Name name, Money money);

        Player CreateNewNormal(PlayerId id, Name name);
        Player CreateNewVip(PlayerId id, Name name);
    }
}
