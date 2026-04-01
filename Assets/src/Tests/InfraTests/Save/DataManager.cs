
using System.IO;
using UnityEngine;
namespace Src.Tests.Save
{
    /// <summary>
    /// セーブデータをJson形式で保存・読み込みする。
    /// </summary>
    public class DataManager : MonoBehaviour
    {
        public RankingData RankingData;
        private SaveData _data;
        private string _filePath;
        private string _fileName = "Data.json";

        private void Awake()
        {
            _filePath = Path.Combine(Application.persistentDataPath,_fileName);

            if(!File.Exists(_filePath))
            {
                _data = new SaveData();
                Save(_data);
            }

            _data = Load(_filePath);
            RankingData = new RankingData(_data.Ranking);
        }


        private void Save(SaveData data)
        {
            string json = JsonUtility.ToJson(data);
            StreamWriter writer = new StreamWriter(_filePath,false);
            writer.WriteLine(json);
            writer.Close();
        }
        private SaveData Load(string Path)
        {
            StreamReader reader = new StreamReader(Path);
            string json = reader.ReadToEnd();
            reader.Close();
            return JsonUtility.FromJson<SaveData>(json);
        }
        private void OnDestroy()
        {
            _data.Ranking = RankingData.ToArray();
            Save(_data);
        }
    }
}