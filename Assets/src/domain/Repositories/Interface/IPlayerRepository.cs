using Src.Domain.Entities;

namespace Src.Domain.Repositories
{
    public interface IPlayerRepository
    {
        Player Find(int playerId);
        void Save(Player player);
    }
}
