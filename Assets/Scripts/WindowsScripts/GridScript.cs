using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridScript : MonoBehaviour {
    private Component[] slots;

    [SerializeField]
    private GameObject fileGrid;

    private void Start() {
        slots = gameObject.GetComponents(typeof(MoveFolders));
        foreach(MoveFolders file in slots) {
            GameObject tempFileGrid = fileGrid;
            file.transform.SetParent(tempFileGrid.transform);
        }
        GameObject lastFileGrid = fileGrid;
    }
}
