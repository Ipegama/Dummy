using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "New/Effects/Deal Damage")]
public class DealDamageEffect : Effect
{
    public int amount;
    public RectTransform explosionVFX;
    public AudioClip audioClip;

    public override IEnumerator Use(Combatant owner, Combatant rival)
    {
        yield return new WaitForSeconds(0.25f);
        owner.AttackAnimation(owner, rival);

        SoundManager.Instance.PlaySound(audioClip);

        Canvas canvas = GameObject.FindObjectOfType<Canvas>();
        RectTransform explosion = Instantiate(explosionVFX,canvas.transform);
        explosion.position = rival.transform.position;
        explosion.transform.localScale = Vector3.zero;
        explosion.transform.DOScale(Vector3.one,0.3f).SetEase(Ease.OutBack);
        explosion.GetComponent<CanvasGroup>().DOFade(0,0.4f).OnComplete(()=>Destroy(explosion.gameObject));

        yield return new WaitForSeconds(0.25f);
        rival.TakeDamage(amount);
    }
}
