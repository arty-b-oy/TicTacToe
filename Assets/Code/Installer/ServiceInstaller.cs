using Zenject;
using Code.Service;

namespace Code.Installer
{
    public class ServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<SaveService>().FromNew().AsSingle().NonLazy();
            Container.Bind<FieldCheckService>().FromNew().AsSingle().NonLazy();
        }
    }
}