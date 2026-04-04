
using Src.Domain.Entities;
using Src.Domain.ValueObjects;
namespace Src.Domain.Factories
{
    public interface IPlayerFactroy
    {
        Player CreateNormal(PlayerId id,Name name,Money money);
        Player CreateVip(PlayerId id,Name name, Money money);
    }
}
