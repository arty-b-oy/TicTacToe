using UnityEngine;
using Zenject;
using Code.MonoBehavior.GamePlay;

namespace Code.MonoBehavior.UI
{
    public class NewGame : MonoBehaviour
    {
        [Inject] private GameController _gameController;

        public void StartNewGame()=>_gameController.StartNewGame();

    }
}
