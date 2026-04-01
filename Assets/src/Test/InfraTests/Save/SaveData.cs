
namespace Src.Test.Save
{
    [System.Serializable]
    /// <summary>
    /// ランタイムデータを保持する。
    /// </summary>
    public class SaveData
    {
        public const int RankCount = 3;
        public int[] Ranking = new int[RankCount];
    }
}