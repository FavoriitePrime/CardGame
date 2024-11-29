using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Transform spawnPosition;
    public float lerp;
    public int cardToSpawn;
    public Vector3 onHoverOffset;
    public CardController _cardController;
    public RectTransform _canvas;
    public GameObject cardPrefab;
    public GameObject slotPrefab;
    public List<CardInfo> draw;

    private void Awake()
    {
        _cardController = new CardController(_canvas, cardPrefab, slotPrefab, draw, transform, lerp);
    }

    private void Start()
    {
        _cardController.TakeCard(cardToSpawn);
    }
    private void Update()
    {
        _cardController.Update();
    }
}
