using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Translate : MonoBehaviour
{
    private String message;

    public TMP_InputField messageInput;
    
    public TMP_Text messageOutput;
    
    public void TranslateMorse() {
        
        Debug.Log("You've pressed me!");

        if (messageInput.text == "") {
            messageOutput.text = "You have given me NOTHING!";
        } else if (!messageInput.text.Contains("-") && !messageInput.text.Contains(".")) {
            messageOutput.text = "I can't work with this!";
        } else {

            String[] messageBits = messageInput.text.Split(' ');

            for (int i = 0; i < messageBits.Length; i++) {
                switch (messageBits[i])
                {
                    case ".-":
                        message += "A";
                        break;
                    case "-...":
                        message += "B";
                        break;
                    case "-.-.":
                        message += "C";
                        break;
                    case "-..":
                        message += "D";
                        break;
                    case ".":
                        message += "E";
                        break;
                    
                }
            }

            messageOutput.text = message;
        }


    }

}
