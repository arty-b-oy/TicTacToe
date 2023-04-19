using UnityEngine.SceneManagement;
using UnityEngine;
using Zenject;
using Code.Service;
using Code.Data.Static;

namespace Code.MonoBehavior.GamePlay
{
    public class GameController : MonoBehaviour
    {
        [Inject] private SaveService _saveService;
        [Inject] private FieldCheckService _fieldCheckService;

        public delegate void Load(CellType[,] statusField);
        public event Load LoadData;

        public delegate void Win(CellType winner);
        public event Win WinThisGame;

        public delegate void Draw();
        public event Draw DrawThisGame;

        private CellType[,] _statusField;
        private int _moveNumber = 0;

        void Start()
        {
            _saveService.CreateGame();
            _statusField = _saveService.LoadGame();
            SetMoveNumber();
            LoadData(_statusField);
        }

        public void MoveHandler(int positionCellX, int positionCellY)
        {
            _statusField[positionCellX, positionCellY] = _moveNumber % 2 == 0 ?
                                                         CellType.Cross :  CellType.Zero;
            if (_fieldCheckService.FieldCheck(_statusField))
            {
                WinThisGame(_moveNumber % 2 == 0 ? CellType.Cross : CellType.Zero);
                _saveService.ResetData();
            }
            else if (_moveNumber>= _statusField.Length - 1)
            {
                DrawThisGame();
                _saveService.ResetData();
            }
            else
            {
                _moveNumber++;
                LoadData(_statusField);
                _saveService.SaveGame(_statusField);
            }
        }

        public int GetMoveNumber()
        {
            return _moveNumber;
        }

        private void SetMoveNumber()
        {
            for (int i = 0; i < ConstData.FIELD_SIZE; i++)
                for (int j = 0; j < ConstData.FIELD_SIZE; j++)
                    if (_statusField[i, j] != CellType.Null) _moveNumber++;
        }

        public void StartNewGame()
        {
            _saveService.ResetData();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}