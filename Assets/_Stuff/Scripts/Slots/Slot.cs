using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour
{
    public Card Card { get; private set; }
    public Color BaseColor { get; set; }

    private Image image;
    private Board board;

    private void Start()
    {
        image = GetComponent<Image>();
        image.color = BaseColor;
    }

    public void Setup(Board board)
    {
        this.board = board;
    }

    public void AddCard(Card newCard)
    {
        if (Card != null) return;

        Card = newCard;
        newCard.transform.SetParent(transform);
        newCard.transform.localPosition = Vector3.zero;
    }

    public IEnumerator UseSlot(Combatant owner, Combatant rival)
    {
        Highlight(true);

        if (Card == null)
        {
            yield return new WaitForSeconds(0.5f);
        }
        else
        {
            Debug.Log($"{owner} uses card: {Card.name}");
            yield return Card.UseCard(owner, rival);
        }

        Highlight(false);
    }
    private void Highlight(bool active)
    {
        if (image == null) return;
        image.color = active ? Color.yellow : BaseColor;
    }
    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
