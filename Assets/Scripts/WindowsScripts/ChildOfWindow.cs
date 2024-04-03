using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildOfWindow : MonoBehaviour {
    private ArrayList childOf = new ArrayList();

    private GameObject fileSlots = new GameObject();
    private List<MoveFolders> files = new List<MoveFolders>();

    private void Start() {
        fileSlots = transform.GetComponent("FileSlot").gameObject; // Get the children of window under the name FileSlot
        files = getChildOf();
    }

    public List<MoveFolders> getChildOf() {
        MoveFolders[] arrayFiles = fileSlots.GetComponents<MoveFolders>();
        List<MoveFolders> listFiles = new List<MoveFolders>();
        if(arrayFiles != null) {
            for (int i = 0; i < arrayFiles.Length; i++) {
                listFiles.Add(arrayFiles[i]); // Add all children of the window to the List<MoveFolders> files
            }
        }
        return listFiles;
    }
}
