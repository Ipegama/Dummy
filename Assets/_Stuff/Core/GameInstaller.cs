using UnityEngine;
using Zenject;

namespace IpegamaGames
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] AudioClipsScriptableObject _audioClips;

        public override void InstallBindings()
        {
            Container.Bind<IGameInitiator>().To<GameInitiator.GameInitiator>().AsSingle().NonLazy();
            //Container.BindFactory<GamePlayInitatorEnterData, GamePlayState, GamePlayState.Factory>();
            //Container.BindInterfacesTo<LevelsDataService>().AsSingle().NonLazy();
            //Container.BindFactory<LobbyInitiatorEnterData, LobbyState, LobbyState.Factory>().AsSingle().NonLazy();
        }
    }
}
