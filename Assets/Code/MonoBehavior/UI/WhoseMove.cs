using UnityEngine;
using Zenject;
using TMPro;
using Code.MonoBehavior.GamePlay;
using Code.Config;

namespace Code.MonoBehavior.UI
{
    public class WhoseMove : MonoBehaviour
    {
        [Inject] private GameController _gameController;
        [Inject] private TextDataConfig _textDataConfig;
        private TextMeshProUGUI _text;

        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
            _gameController.LoadData += UpdateMove;
        }

        private void UpdateMove(CellType[,] statusField)=>
            _text.text = _gameController.GetMoveNumber() % 2 == 0 ?
            _textDataConfig.textMoveX : _textDataConfig.textMoveO;
    }
}
