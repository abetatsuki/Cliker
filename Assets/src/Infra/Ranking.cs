
using Cliker.Infra.Object;
using TMPro;
using UnityEngine;

/// <summary>
/// ランキングの表示およびスコアの登録・更新を行う。
/// </summary>
public class Ranking : MonoBehaviour
{
    /// <summary>
    /// 入力されたスコアをランキングに登録し、降順に更新する。
    /// </summary>
    public void SetRank()
    {
        TMP_InputField inputField = GameObject.Find("InputField").GetComponent<TMP_InputField>();

        if (int.TryParse(inputField.text, out int score))
        {
            _data.TryInsert(score);
        }
        else
        {
            Debug.Log("数値を入力してください");
        }
    }

    /// <summary>
    /// ランキングスコアを初期状態にリセットする。
    /// </summary>
    public void DelRank()
    {
       _data.Clear();
    }

    private string[] _rankNames = { "1st", "2nd", "3rd" };
    private const int _rankCount = SaveData.RankCount;
    private TextMeshProUGUI[] _rankTexts = new TextMeshProUGUI[_rankCount];
    private RankingData _data;

    private void Start()
    {
        _data = GetComponent<DataManager>().RankingData;
        Transform ranktext = GameObject.Find("RankTexts").transform;
        for (int i = 0; i < _rankCount; i++)
        { 
            _rankTexts[i] = ranktext.GetChild(i).GetComponent<TextMeshProUGUI>();
        }
    }

    private void Update()
    {
        DispRank();
    }
    /// <summary>
    /// ランキングデータをUIに表示する。
    /// </summary>
    private void DispRank()
    {
        for (int i = 0; i < _rankCount; i++)
        {
            _rankTexts[i].text = $"{_rankNames[i]} : {_data.ReadRanking(i)}";
        }
    }


}
