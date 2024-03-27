using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Translate : MonoBehaviour
{

    [SerializeField] public TMP_InputField messageInput;
    [SerializeField] public TextMeshProUGUI messageOutput;
    
    public void TranslateMorse() {
        if (messageInput.text == null) {
            messageOutput.text = "You have given me NOTHING!";
        }
    }

}
