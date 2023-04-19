using UnityEngine;
using UnityEngine.UI;
using Zenject;
using TMPro;
using Code.MonoBehavior.GamePlay;
using Code.Config;

namespace Code.MonoBehavior.UI
{
    public class WinPopUp : MonoBehaviour
    {
        [Inject] private GameController _gameController;
        [Inject] private TextDataConfig _textDataConfig;
        [SerializeField] private TextMeshProUGUI _text;
        private RectTransform _rectTransform;
        void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _rectTransform.offsetMax = new Vector2 (0, 0);
            _rectTransform.offsetMin = new Vector2(0, 0);
            _gameController.WinThisGame += Win;
            _gameController.DrawThisGame += Draw;

            gameObject.SetActive(false);
        }

        private void Win(CellType winner)
        {
            gameObject.SetActive(true);
            _text.text = winner == CellType.Cross ? _textDataConfig.textWinX :
                                                    _textDataConfig.textWinO;
        }
        private void Draw()
        {
            gameObject.SetActive(true);
            _text.text = _textDataConfig.textDraw;
        }
        public void ClosePopUp()=>_gameController.StartNewGame();
    }
}
