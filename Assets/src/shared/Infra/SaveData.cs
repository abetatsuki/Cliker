using Cliker.Domain.Object;
using UnityEngine;
namespace Cliker.Infra.Object 
{ 
    [System.Serializable]
    /// <summary>
    /// ランタイムデータを保持する。
    /// </summary>
    public class SaveData
    {
        public int [] Ranking { get; private set;} = new int [RankCount];
        public const int RankCount = 3;
    }
}