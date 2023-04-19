using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using Zenject;
using Code.Config;

namespace Code.Service
{
    public class SaveService
    {
        [Inject] private TextDataConfig _textDataConfig;
        private BinaryFormatter _binaryFormatter = new BinaryFormatter();
        private FileStream _file;
        private SaveData _saveData;

        public void CreateGame()
        {
            if (!File.Exists(Application.persistentDataPath
            + _textDataConfig.nameSaveFile))
            {
                _file = File.Create(Application.persistentDataPath
                    + _textDataConfig.nameSaveFile);
                _saveData = new SaveData();
                _binaryFormatter.Serialize(_file, _saveData);
                _file.Close();
            }
        }
        public void SaveGame(CellType[,] data)
        {
            _file = File.Open(Application.persistentDataPath
              + _textDataConfig.nameSaveFile, FileMode.Open);
            _saveData = new SaveData();
            _saveData.statusField = data;
            _binaryFormatter.Serialize(_file, _saveData);
            _file.Close();
        }

        public CellType[,] LoadGame()
        {
            _file = File.Open(Application.persistentDataPath
              + _textDataConfig.nameSaveFile, FileMode.Open);
            _saveData = (SaveData)_binaryFormatter.Deserialize(_file);
            _file.Close();
            return _saveData.statusField;
        }

        public void ResetData()
        {
            _file = File.Open(Application.persistentDataPath
              + _textDataConfig.nameSaveFile, FileMode.Open);
            _saveData = new SaveData();
            _binaryFormatter.Serialize(_file, _saveData);
            _file.Close();
        }
    }
}