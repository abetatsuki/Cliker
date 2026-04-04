using Src.Domain.Entities;
using Src.Domain.Repositories;
public static  class RuntimeDataManager 
{
    public static Player  Player { get; private set; }
    public static PlayerAppService PlayerAppService { get; private set; }
    public static void SetPlayer(Player player)
    {
        Player = player;
    }
    public static void SetAppService(PlayerAppService service)
    {
        PlayerAppService = service;
    }
 }
