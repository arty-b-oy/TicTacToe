using UnityEngine;
using Zenject;
using Code.MonoBehavior.GamePlay;

namespace Code.Installer
{
    public class GamePlayInstaller : MonoInstaller
    {
        [SerializeField] private GameController _gameController;
        public override void InstallBindings()
        {
            var gameController = Container.InstantiatePrefabForComponent<GameController>(
                _gameController);
            Container.Bind<GameController>().FromInstance(gameController).AsSingle().NonLazy();
        }
    }
}