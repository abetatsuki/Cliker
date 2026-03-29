
using Cliker.Infra.Object;
using TMPro;
using UnityEngine;

/// <summary>
/// ランキングの表示と更新と登録処理を行う。  
/// </summary>
public class Ranking : MonoBehaviour
{
    private string[] _rankNames = {"1st", "2nd", "3rd"};
    private const int  _rankCount = SaveData.RankCount;
    private TextMeshProUGUI[] _rankTexts = new TextMeshProUGUI[_rankCount];
    private SaveData _data;

    private void Start()
    {
        _data = GetComponent<DataManager>().Data;
        for (int i = 0; i < _rankCount; i++)
        {
            Transform rankChilds = GameObject.Find("RankTexts").transform.GetChild(i); 
            _rankTexts[i] = rankChilds.GetComponent<TextMeshProUGUI>();
        }
    }

    private void Update()
    {
        DispRank();
    }

    private void DispRank()
    {
       for(int i = 0; i < _rankCount; i++)
        {
            _rankTexts[i].text = $"{_rankNames[i]} : {_data.Ranking[i]}";
        }
    }
    public  void SetRank()
    {
        TMP_InputField inputField = GameObject.Find("InputField").GetComponent<TMP_InputField>();

        if (int.TryParse(inputField.text,out int score ))
        {
            for (int i = 0; i < _rankCount; i++)
            {
                if (score > _data.Ranking[i])
                {
                    var rep = _data.Ranking[i];
                    _data.Ranking[i] = score;
                    score = rep;
                }
            }
        }
        else
        {
            Debug.Log("数値を入力してください");
        }
    }

    public void DelRank()
    {
        for(int i = 0; i < _rankCount; i++)
        {
            _data.Ranking[i] = 0;
        }
    }

}
