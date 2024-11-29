using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class CardController
{
    private float _lerp;
    private List<CardInfo> _draw;
    private List<Card> cards = new List<Card>();
    private List<Slot> slots = new List<Slot>();
    private Transform _hand;
    private GameObject _cardPrefab;
    private GameObject _slotPrefab;
    private Fabric _fabric;
    private InputManager _input;
    private RectTransform _canvas;
    private Card _currentHoveredCard;

    public CardController(RectTransform canvas, GameObject cardPrefab, GameObject slotPrefab, List<CardInfo> draw, Transform hand, float lerp)
    {
        _fabric = new Fabric();
        _input = new InputManager();
        _canvas = canvas;
        _cardPrefab = cardPrefab;
        _slotPrefab = slotPrefab;
        _draw = draw;
        _hand = hand;
        _lerp = lerp;
    }

    public void Update()
    {
        foreach (Card card in cards)
        {
            if (!card.IsDraging)
            {

                if (card.IsHovered)
                {
                    //OnCardHover(card);
                }
                else
                {
                   ResetCardPosition(card);
                }
            }
        }
    }


    private void RemoveSlot()
    {
        slots[slots.Count - 1].gameObject.SetActive(false);
        ResortCards();
    }

    public void TakeCard(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Card card = _fabric.GetNewRandomCard(ref _draw, _cardPrefab);
            card.onDragHandler += MoveCard;
            card.onEnterHandler += SetCurrentHoveredCard;
            cards.Add(card);
        }
        ResortCards();
    }

    private void SetCurrentHoveredCard(Card card)
    {
        _currentHoveredCard = card;
    }

    private void ResortCards()
    {
        int i = 0;    
        foreach (Card card in cards)
        {
            if (cards.Count > slots.Count)
            {
                slots.Add(_fabric.GetNewSlot(_slotPrefab, _hand));
            }
            else if (cards.Count < slots.Count)
            {
                slots.Remove(slots[slots.Count-1]);
            }
            card.transform.SetParent(slots[i].transform);
            i++;
        }
    }

    private void ResetCardPosition(Card card)
    {
        card.transform.localPosition = Vector3.Lerp(card.transform.localPosition, Vector3.zero, _lerp);
    }

    private void MoveCard(Card card)
    {
        card.transform.localPosition = Vector2.Lerp(card.transform.localPosition, _input.GetMousePositionOnCanvas(_canvas), _lerp);
    }
}