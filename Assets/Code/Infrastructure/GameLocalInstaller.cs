using Code.Infrastructure.Services;
using UnityEngine;
using Zenject;
using Application = UnityEngine.Device.Application;

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
           // if (Application.isEditor)
            {
                Container
               .Bind<IInputService>()
               .To<HybridInputService>()
               .AsSingle();
            }
          //  else
         //   {             
         //       Container
        //       .Bind<IInputService>()
         //      .To<MobileInputService>()
         //      .AsSingle();
          //  }
        }
    }
}
