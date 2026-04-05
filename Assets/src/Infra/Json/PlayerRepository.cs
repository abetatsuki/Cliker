
using Src.Domain.Entities;
using System.IO; 
using UnityEngine;
using Src.Domain.Repositories;
using Src.Domain.Factories;
using Src.Domain.ValueObjects;

namespace Src.Infra.Json
{
    public class PlayerRepository : IPlayerRepository
    {
        public PlayerRepository(IPlayerFactory factory)
        {
            _saveDir = DataPathUtility.PlayersPath;
            _factory = factory;
            Directory.CreateDirectory(_saveDir);
        }

        public Player Find(PlayerId id)
        {
            string path = DataPathUtility.GetPath(id);
            if(!File.Exists(path)) return null;

            var dto = JsonUtility.FromJson<PlayerDto>(File.ReadAllText(path));
            var success = PlayerDto.FromDto(dto,out PlayerId dtoId , out Name dtoName,out Money dtoMoney); //ファクトリー変換用プレイヤーデータの導入を検討
            if (success)
            {
                Player player = _factory.CreateNormal(dtoId, dtoName, dtoMoney);
                return player;
            }
            else
            {
                return null;
            }
        }
        public void Save(Player player)
        {
            var dto = PlayerDto.ToDto(player);
            string json = JsonUtility.ToJson(dto, prettyPrint: true);
            string path = DataPathUtility.GetPath(player.Id);
            File.WriteAllText(path, json);
        }
        private readonly string _saveDir;
        private readonly IPlayerFactory _factory;
    }
}