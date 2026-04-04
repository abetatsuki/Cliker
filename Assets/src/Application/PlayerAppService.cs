using Src.Domain.Entities;
using Src.Domain.Repositories;
using UnityEngine;

public class PlayerAppService
{
    public PlayerAppService(IPlayerRepository repository)
    {
        _repository = repository;
    }
    public void Save(Player player)
    {
        _repository.Save(player);
    }

    private readonly IPlayerRepository _repository;
}
