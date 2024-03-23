using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MoveFolders : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IPointerDownHandler 
{
    [HideInInspector]
    public Transform parentAfterDrag;
    
    [SerializeField]
    private GameObject window;
    private bool windowActive;
    
    [SerializeField]
    private Image image; // Image of the item

    public List<MoveFolders> containedFolders = new List<MoveFolders>(); // All folders that it contains
    public MoveFolders parentFolder; // Reference to it's parent folder

    float clicked = 0;
    float clicktime = 0;
    float clickdelay = 1.5f;

    private void Start() {
        
    }

    #region -Mouse Events-

    public void OnBeginDrag(PointerEventData eventData) {
        windowActive = window.activeInHierarchy; // Check if the window is active or not
        window.SetActive(false); // Disables the window it is linked to

        image.raycastTarget = false; // disables raycast image

        parentAfterDrag = transform.parent; // keep in mind the original parent
        transform.SetParent(transform.root); // chhange the parent to the canvas
        transform.SetAsLastSibling(); // Make it where it is above everything else
    }

    public void OnEndDrag(PointerEventData eventData) {
        transform.SetParent(parentAfterDrag); // Set it back to the original parent
        if (windowActive) {
            window.SetActive(true); // Enables the window it is linked to when it was enabled before
        }

        image.raycastTarget = true; // enables the raycast image
    }

    public void OnPointerDown(PointerEventData data) {
        clicked++;
        if (clicked == 1) clicktime = Time.time; // Start the times

        if (clicked > 1 && Time.time - clicktime < clickdelay) { // Checks if the delay between the double click is smaller than the set delay
            clicked = 0; // reset clicks
            clicktime = 0; // reset time
            window.SetActive(true); // set active the window

        } else if (clicked > 2 || Time.time - clicktime > 1) clicked = 0; // If it is more than twice ior when it is bigger than the set delay, reset the clicks
        Debug.Log(parentFolder.gameObject.name);
    }

    #endregion

}
