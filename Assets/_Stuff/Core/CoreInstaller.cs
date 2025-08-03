using UnityEngine;
using Zenject;

namespace IpegamaGames
{
    public class CoreInstaller : MonoInstaller
    {

        [SerializeField] private UpdateSubscriptionService _updateSubscriptionService;
        [SerializeField] private AudioService _audioService;
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<SceneLoaderService>().AsSingle().NonLazy();            
            Container.BindInterfacesTo<UpdateSubscriptionService>().FromInstance(_updateSubscriptionService).AsSingle().NonLazy();
            Container.BindInterfacesTo<AudioService>().FromInstance(_audioService).AsSingle().NonLazy();
            Container.BindInterfacesTo<SceneInitiatorsService>().AsSingle().NonLazy();
            Container.BindInterfacesTo<CommandFactory>().AsSingle().CopyIntoAllSubContainers().NonLazy();
            //Container.Bind<GameInputActions>().AsSingle().NonLazy();
        }
    }
}
