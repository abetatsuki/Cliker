
using Src.Domain.Entities;

namespace Src.Domain.Repositories
{ 
    public class PlayerRepository : IPlayerRepository
    {
        public PlayerRepository()
        {

        }

        public Player Find(int playerId)
        {
            return new Player();
        }
        public void Save(Player player)
        {

        }
    }
}