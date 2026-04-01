
using Src.Domain.Entities;
using System.IO;
using UnityEditor.Playables;
using UnityEngine;

namespace Src.Domain.Repositories
{ 
    public class JsonPlayerRepository : IPlayerRepository
    {
        public JsonPlayerRepository(string path)
        {
            _path = path;
        }

        public Player Find(int playerId)
        {
            var json = File.ReadAllText(_path);
            var player = JsonUtility.FromJson<Player>(json);

            return player;
        }
        public void Save(Player player)
        {

        }

        private readonly string _path;
    }
}