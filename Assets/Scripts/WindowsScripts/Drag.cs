using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private GameObject mainObject;
    private Vector2 offset;

    public void DragHandler(BaseEventData data) {
        PointerEventData pointerData = (PointerEventData)data; // Converts the EventData data from EventData to PointerEventData which allows us to use our mouse as data
        // We could also use Input.mousePosition but we don't know if it is a mouse or a touchscreen
        Vector2 position; // reference to the position
        RectTransformUtility.ScreenPointToLocalPointInRectangle(// calculate the position of the pointer's position from the canvas
            (RectTransform)canvas.transform, // Give the method the canva's transform info
            pointerData.position, // Give the poition of the pointer
            canvas.worldCamera, // Get the correct position depending on the camera position
            out position); // Output Vector2 position

        mainObject.transform.position = canvas.transform.TransformPoint(position + offset); // Changes the position to follow the mouse depending on the Vector2 position + offset
        
    }

    public void OnPointerDown(BaseEventData data) {
        PointerEventData pointerData = (PointerEventData)data;
        offset = (Vector2)mainObject.transform.GetComponent<RectTransform>().position - pointerData.position; // Move the window around depending on where the mouse is (offset)
    }
}
