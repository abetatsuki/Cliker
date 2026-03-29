
using System.IO;
using UnityEngine;
namespace Cliker.Infra.Object
{
    /// <summary>
    /// セーブデータをJson形式で保存・読み込みする。
    /// </summary>
    public class DataManager : MonoBehaviour
    {
        [HideInInspector] public SaveData Data;
        private string _filePath;
        private string _fileName = "Data.json";

        private void Awake()
        {
            _filePath = Application.dataPath + "/" + _fileName;

            if(!File.Exists(_filePath))
            {
                Save(Data);
            }

            Data = Load(_filePath);
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
            Save(Data);
        }
    }
}