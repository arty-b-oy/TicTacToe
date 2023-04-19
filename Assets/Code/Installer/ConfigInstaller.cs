using UnityEngine;
using Zenject;
using Code.Config;

namespace Code.Installer
{
    public class ConfigInstaller : MonoInstaller
    {
        [SerializeField] private SpriteConfig _spriteConfig;
        [SerializeField] private TextDataConfig _textDataConfig;

        public override void InstallBindings()
        {
            Container.Bind<SpriteConfig>().FromInstance(_spriteConfig).AsSingle().NonLazy();
            Container.Bind<TextDataConfig>().FromInstance(_textDataConfig).AsSingle().NonLazy();
        }
    }
}