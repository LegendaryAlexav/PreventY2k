using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FileSlot : MonoBehaviour, IDropHandler
{

    public MoveFolders originFolder;

    public void OnDrop(PointerEventData data) {
        GameObject dropped = data.pointerDrag; // Get the UI Grid below mouse
        MoveFolders moveFolders = dropped.GetComponent<MoveFolders>(); // get the MoveFolders script from the UI below mouse
        if(!moveFolders.containedFolders.Contains(originFolder)) { // Checks if the folder we are moving contains a folder that it is linked to
            
            if(moveFolders.parentFolder != null) {
                moveFolders.parentFolder.containedFolders.Remove(moveFolders); // Remove the folder we are moving from it's parent to be able to switch them
            }

            moveFolders.parentAfterDrag = transform; // Change the parent to the UI below mouse 
            originFolder.containedFolders.Add(moveFolders); // add moveFolders to the top folder's List

            moveFolders.parentFolder = originFolder; // Set the parent in the MoveFolder script
            
        }
        Debug.Log("DroppCheck");
    }
        
}
