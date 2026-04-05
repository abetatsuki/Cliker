using Src.Domain.Entities;
using Src.Domain.Factories;
using Src.Domain.Repositories;
using Src.Domain.ValueObjects;
using UnityEngine;
namespace Src.Application
{
    public class PlayerLogin 
    {
        public PlayerLogin(IPlayerRepository repository,IPlayerFactory factory)
        {
            _repository = repository;
            _factory = factory;
        }
        public void Login(PlayerId id , Name name)
        {
            Player player = _repository.Find(id);
            if(player == null)
            {
               player =  _factory.CreateNewNormal(id, name);
            }
            RuntimeDataManager.SetPlayer(player);
        }
        private readonly IPlayerRepository _repository;
        private readonly IPlayerFactory _factory;
    }
}

