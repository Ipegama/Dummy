﻿using DG.Tweening;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

namespace IpegamaGames
{
    public class AnimatedSliderView : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private float _animationDuration = 0.5f;
        [SerializeField] private Ease _animationEase = Ease.OutQuad;

        private Tween _currentAnimationTween;

        public async Awaitable AnimateSliderTo(float targetValueBetween0To1, CancellationTokenSource cancellationTokenSource)
        {
            _currentAnimationTween?.Kill();
            _currentAnimationTween = _slider.DOValue(targetValueBetween0To1, _animationDuration).SetEase(_animationEase);
            await _currentAnimationTween.WithCancellationSafe(cancellationToken: cancellationTokenSource.Token);
        }

        public void ResetSlider()
        {
            _currentAnimationTween?.Kill();
            _slider.value = 0;
        }
    }
}
