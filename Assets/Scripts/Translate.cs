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
                    case "..-.":
                        message += "F";
                        break;
                    case "--.":
                        message += "G";
                        break;
                    case "....":
                        message += "H";
                        break;
                    case "..":
                        message += "I";
                        break;
                    case ".---":
                        message += "J";
                        break;
                    case "-.-":
                        message += "K";
                        break;
                    case ".-..":
                        message += "L";
                        break;
                    case "--":
                        message += "M";
                        break;
                    case "-.":
                        message += "N";
                        break;
                    case "---":
                        message += "O";
                        break;
                    case ".--.":
                        message += "P";
                        break;
                    case "--.-":
                        message += "Q";
                        break;
                    case ".-.":
                        message += "R";
                        break;
                    case "...":
                        message += "S";
                        break;
                    case "-":
                        message += "T";
                        break;
                    case "..-":
                        message += "U";
                        break;
                    case "...-":
                        message += "V";
                        break;
                    case ".--":
                        message += "W";
                        break;
                    case "-..-":
                        message += "X";
                        break;
                    case "-.--":
                        message += "Y";
                        break;
                    case "--..":
                        message += "Z";
                        break;
                }
            }

            messageOutput.text = message;
            message = "";
        }

    }

}
