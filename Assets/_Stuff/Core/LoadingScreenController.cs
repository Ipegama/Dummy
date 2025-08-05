using System.Threading;
using UnityEngine;
using Zenject;

namespace IpegamaGames
{
    public class LoadingScreenController : ILoadingScreenController
    {
        private readonly LoadingScreenView _loadingScreenView;

        [Inject]
        public LoadingScreenController(LoadingScreenView loadingScreenView)
        {
            _loadingScreenView = loadingScreenView;
        }

        public void Show()
        {
            Debug.Log("Show loading screen");
            _loadingScreenView.ResetSlider();
            _loadingScreenView.Show();
        }

        public void Hide()
        {
            Debug.Log("Hide loading screen");
            _loadingScreenView.Hide();
        }

        public void ResetSlider()
        {
            _loadingScreenView.ResetSlider();
        }

        public async Awaitable SetLoadingSlider(float valueBetween0To1, CancellationTokenSource cancellationTokenSource)
        {
            await _loadingScreenView.SetLoadingSlider(valueBetween0To1, cancellationTokenSource);
        }
    }
}
