
using Src.Domain.Entities;
using System.IO; 
using UnityEngine;
using Src.Domain.Repositories;
using Src.Domain.Factories;

namespace Src.Infra.Json
{
    public class PlayerRepository : IPlayerRepository
    {
        public PlayerRepository(IPlayerFactroy factory)
        {
            _saveDir = DataPathUtility.PlayersPath;
            Directory.CreateDirectory(_saveDir);
        }

        public Player Find(PlayerId id)
        {
            string path = DataPathUtility.GetPath(id);
            if(!File.Exists(path)) return null;

            var dto = JsonUtility.FromJson<PlayerDto>(File.ReadAllText(path));

            return JsonUtility.FromJson<Player>(json);
        }
        public void Save(Player player)
        {
            var dto = PlayerDto.ToDto(player);
            string json = JsonUtility.ToJson(dto, prettyPrint: true);
            string path = DataPathUtility.GetPath(player.Id);
            File.WriteAllText(path, json);
        }

        private readonly string _saveDir;
    }
}