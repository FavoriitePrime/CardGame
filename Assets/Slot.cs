using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private RectTransform _rectTransform;
    private float originalWidth;
    public float onHoverWidth;
    public float lerp;
    private bool IsHovered;
    public Card currentCard;
    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        originalWidth = _rectTransform.rect.width;  
    }
    private void Update()
    {
        if (IsHovered)
        {
            _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Mathf.Lerp(_rectTransform.rect.width, onHoverWidth, lerp));
        }
        else 
        {
            _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Mathf.Lerp(_rectTransform.rect.width, originalWidth, lerp));
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        IsHovered = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
       IsHovered = false;
    }
}
