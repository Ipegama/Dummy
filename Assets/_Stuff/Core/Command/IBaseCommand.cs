using Zenject;

namespace IpegamaGames
{
    public interface IBaseCommand
    {
        void SetObjectResolver(DiContainer diContainer);
        void ResolveDependencies();
    }
}