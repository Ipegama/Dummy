using DG.Tweening;
using TMPro;
using UnityEngine;

public class DamagePopup : MonoBehaviour
{
    [SerializeField] TMP_Text damageText;
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] float duration = 0.6f;

    public void Show(int damageAmount)
    {
        gameObject.SetActive(true);

        canvasGroup.alpha = 1f;
        damageText.text = $"-{damageAmount}";

        var rect = (RectTransform)transform;
        rect.anchoredPosition = Vector2.zero;
        transform.localScale = Vector3.one;

        Sequence seq = DOTween.Sequence();

        seq.Append(rect.DOAnchorPos(new Vector2(0f, 80f), duration * 0.6f).SetEase(Ease.OutCubic));
        seq.Join(transform.DOScale(1.1f, duration * 0.6f).SetEase(Ease.OutBack));

        seq.Append(canvasGroup.DOFade(0f, duration * 0.4f));

        seq.OnComplete(Hide);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
        transform.localScale = Vector3.one;
        ((RectTransform)transform).anchoredPosition = Vector2.zero;
    }
}
