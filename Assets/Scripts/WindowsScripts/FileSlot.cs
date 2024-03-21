using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FileSlot : MonoBehaviour, IDropHandler
{

    public void OnDrop(PointerEventData data) {
        GameObject dropped = data.pointerDrag; // Get the UI Grid below mouse
        MoveFolders moveFolders = dropped.GetComponent<MoveFolders>(); // get the MoveFolders script from the UI below mouse
        moveFolders.parentAfterDrag = transform; // Change the parent to the UI below mouse
        // if it changes folder close all child folders
    }
}
