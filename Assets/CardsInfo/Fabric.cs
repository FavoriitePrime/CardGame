using System.Collections.Generic;
using UnityEngine;

public class Fabric
{

    private CardInfo PickRandomFromDraw(ref List<CardInfo> draw)
    {
        if(draw == null)
        {
            Debug.LogAssertion("Draw is not initilized or not assigned");
            return null;
        }
        if(draw.Count == 0)
        {
            Debug.LogWarning("Draw is empty");
            return null;
        }
        return draw[Random.Range(0, draw.Count - 1)];
    }

    public Card GetNewRandomCard(ref List<CardInfo> draw, GameObject cardPrefab)
    {
        GameObject gameObject = Object.Instantiate(cardPrefab);
        Card card = gameObject.GetComponent<Card>();
        card.cardInfo = PickRandomFromDraw(ref draw);
        return card;
    }

    public Slot GetNewSlot(GameObject slotPrefab, Transform hand)
    {
        GameObject gameObject = Object.Instantiate(slotPrefab, hand);
        Slot slot = gameObject.GetComponent<Slot>();
        return slot;
    }
}