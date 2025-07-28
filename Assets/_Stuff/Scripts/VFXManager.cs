using DG.Tweening;
using System.Collections;
using UnityEngine;

public class VFXManager : Singleton<VFXManager>
{
    [SerializeField] private Transform effectsHolder;
    [SerializeField] private RectTransform enemyTransform;
    [SerializeField] private RectTransform playerTransform;

    [SerializeField] private GameObject explosionPrefab;
    public Tween MoveToTarget(Combatant attacker, Combatant target, float duration)
    {
        RectTransform attackerTransform = GetTransform(attacker);
        RectTransform targetTransform = GetTransform(target);

        float attackDistance = 50f;
        float attackDuration = duration;

        // Zapisz oryginaln¹ pozycjê zanim siê ruszy
        attacker.OriginalPosition = attackerTransform.position;

        Vector3 direction = (targetTransform.position - attackerTransform.position).normalized;
        Vector3 attackPosition = attackerTransform.position + direction * attackDistance;

        return attackerTransform.DOMove(attackPosition, attackDuration)
                                .SetEase(Ease.OutQuad);
    }

    public Tween ReturnToOrigin(Combatant attacker, float duration)
    {
        RectTransform attackerTransform = GetTransform(attacker);
        float attackDuration =  duration;

        return attackerTransform.DOMove(attacker.OriginalPosition, attackDuration)
                                .SetEase(Ease.InQuad);
    }


    public void StartExplosion(RectTransform targetTransform)
    {
        StartCoroutine(ExplosionCR(targetTransform));
    }
    public IEnumerator ExplosionCR(RectTransform targetTransform)
    {
        GameObject explosion = Instantiate(explosionPrefab,effectsHolder);
        explosion.GetComponent<RectTransform>().anchoredPosition = targetTransform.anchoredPosition;
        CanvasGroup canvasGroup = explosion.GetComponent<CanvasGroup>();

        yield return canvasGroup.DOFade(0f, 2f).WaitForCompletion();
        Destroy(explosion);
    }

    private RectTransform GetTransform(Combatant combatant)
    {
        return combatant is Player ? playerTransform : enemyTransform;
    }
}
