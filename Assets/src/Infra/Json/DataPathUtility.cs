using System.IO;
using UnityEngine;

namespace Src.Infra.Json
{
    public static class DataPathUtility
    {
        public static string PlayersPath =>
             Path.Combine(Application.persistentDataPath, "players");

        public static string GetPath(PlayerId id)
        {
            return Path.Combine( PlayersPath,$"{id.Value}.json");
        }
    }
}