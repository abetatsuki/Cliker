using Src.Domain.Entities;

namespace Src.Domain.Repositories
{
    public interface IPlayerRepository
    {
        Player Find(PlayerId id);
        void Save(Player player);
    }
}
