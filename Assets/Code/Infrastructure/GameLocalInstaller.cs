using Code.Infrastructure.Services;
using UnityEngine.Device;
using Zenject;

namespace Code.Infrastructure
{
    public class GameLocalInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindInputService();
        }

        private void BindInputService()
        {
            if (Application.isEditor)
            {
                Container
               .Bind<IInputSetvice>()
               .To<MobileInputService>()
               .AsSingle();
            }
            else
            {             
                Container
               .Bind<IInputSetvice>()
               .To<MobileInputService>()
               .AsSingle();
            }
        }
    }
}
