using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    public delegate void OnDragHandler(Card card);
    public delegate void OnPointerEnterHandler(Card card);
    public event OnPointerEnterHandler onEnterHandler;
    public event OnDragHandler onDragHandler;
    public RectTransform rectTransform;
    private Image image;
    public bool IsDraging;
    public bool IsHovered;
    public CardInfo cardInfo;

    private void Start()
    {
        image = GetComponentInChildren<Image>();
        rectTransform = GetComponent<RectTransform>();
        image.sprite = cardInfo.sprite;
    }
    public void OnDrag(PointerEventData eventData)
    {
        
        onDragHandler.Invoke(this);
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        IsDraging = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        IsDraging = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        IsHovered = true;
        onEnterHandler.Invoke(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        IsHovered = false;
    }
}
