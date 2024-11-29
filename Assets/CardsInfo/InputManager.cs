using UnityEngine;
public class InputManager
{ 
    public Vector2 GetMousePositionOnCanvas(RectTransform canvas)
    {
        Vector2 vector = Vector2.zero;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, Input.mousePosition, Camera.main, out vector);
        return vector;
    }

}