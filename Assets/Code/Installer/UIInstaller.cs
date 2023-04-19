using UnityEngine;
using Zenject;
using Code.MonoBehavior.UI;

namespace Code.Installer
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField] private NewGame _newGame;
        [SerializeField] private WhoseMove _whoseMove;
        [SerializeField] private WinPopUp _winPopUp;
        public override void InstallBindings()
        {
            var newGame = Container.InstantiatePrefabForComponent<NewGame>(
                _newGame, gameObject.transform);
            var whoseMove = Container.InstantiatePrefabForComponent<WhoseMove>(
                _whoseMove, gameObject.transform);
            var winPopUp = Container.InstantiatePrefabForComponent<WinPopUp>(
                _winPopUp, gameObject.transform);
            Container.Bind<NewGame>().FromInstance(newGame).AsSingle().NonLazy();
            Container.Bind<WhoseMove>().FromInstance(whoseMove).AsSingle().NonLazy();
            Container.Bind<WinPopUp>().FromInstance(winPopUp).AsSingle().NonLazy();
        }
    }
}