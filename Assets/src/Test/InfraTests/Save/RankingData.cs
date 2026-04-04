
namespace Src.Test.Save
{ 
    public class RankingData
    {
        public RankingData(int[] ranking)
        {
            _ranking = (int[])ranking.Clone();  // コピーして持つ
        }

        // ランキングのルールをここに集める
        public void TryInsert(int score)
        {
            for (int i = 0; i < _ranking.Length; i++)
            {
                if (score > _ranking[i])
                {
                    var rep = _ranking[i];
                    _ranking[i] = score;
                    score = rep;
                }
            }
        }

        public void Clear()
        {
            for (int i = 0; i < _ranking.Length; i++)
            {
                _ranking[i] = 0;
            }
        }

        public int ReadRanking(int rank) => _ranking[rank];


        public int[] ToArray() => (int[])_ranking.Clone();
        private int[] _ranking;
    }
}