using Code.Config;
using UnityEngine;
using Zenject;

namespace Code.MonoBehavior.GamePlay
{
    public class Cell : MonoBehaviour
    {
        [Inject] private SpriteConfig _spriteConfig;
        [SerializeField] private int _positionCellX;
        [SerializeField] private int _positionCellY;
        private SpriteRenderer _spriteRenderer;
        private GameController _gameController;
        private CellType _cellType;
        private CellType _winner;

        void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _gameController = GetComponentInParent<GameController>();
            _gameController.LoadData += UpdateSprite;
            _gameController.WinThisGame += InActivCell;
        }

        private void OnMouseDown()
        {
            if (_cellType != CellType.Null || _winner != CellType.Null)
                return;
            _gameController.MoveHandler(_positionCellX, _positionCellY);
        }

        private void UpdateSprite(CellType[,] statusField)
        {
            _cellType = statusField[_positionCellX, _positionCellY];
            switch (_cellType)
            {
                case CellType.Null:
                    _spriteRenderer.sprite = null;
                    break;
                case CellType.Zero:
                    _spriteRenderer.sprite = _spriteConfig.zeroSprite;
                    break;
                case CellType.Cross:
                    _spriteRenderer.sprite = _spriteConfig.crossSprite;
                    break;
            }
        }

        private void InActivCell(CellType winner) => _winner=winner;
    }
}