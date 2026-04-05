using Src.Application;
using Src.Domain.Factories;
using Src.Domain.Repositories;
using Src.Infra.Json;
using UnityEngine;

public class CompositionRoot : MonoBehaviour
{
    private void Awake()
    {
        IPlayerFactory factory = new PlayerFactory();
        IPlayerRepository repository = new PlayerRepository(factory);
        Login = new PlayerLogin(repository,factory);
        PlayerAppService service = new PlayerAppService(repository);
        RuntimeDataManager.SetAppService(service);
    }

    public PlayerLogin Login { get; private set; }
}
