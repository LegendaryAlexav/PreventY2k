using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Translate : MonoBehaviour
{
    
    private String message = "";

    private int vigenereButtonCount = 0;

    private String vigenereTempMessage;

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

    public void TranslateVigenere() {

        if (vigenereButtonCount == 0) {

            if (messageInput.text == "") {

                messageOutput.text = "You have given me NOTHING!";

            } else {

                vigenereTempMessage = messageInput.text;
                messageInput.text = "";
                messageOutput.text = "Please now enter the key";
                vigenereButtonCount++;

            }

        } else if (vigenereButtonCount == 1) {

            String key = messageInput.text.ToLower();
            int keyCounter = 0;

            foreach (char c in vigenereTempMessage.ToLower().Trim()) {

                if (char.IsLetter(c)) {

                    if (keyCounter == key.Length) {
                        keyCounter = 0;
                    }

                    int x = (c - key[keyCounter] + 26) % 26;
                    
                    x += 'A';
                    message += (char) x;

                    keyCounter++;
                } else {

                    message += c;

                }

            }

            messageOutput.text = message;
            message = "";
            messageInput.text = "";
            vigenereTempMessage = "";
            vigenereButtonCount--;

        }

    }

    public void TranslateCeaser() {

        // If the input is empty
        if (messageInput.text == "") {

            messageOutput.text = "You have given me NOTHING!";

        } else {

            // Loop through every letter in the input
            foreach (char c in messageInput.text.Trim()) {

                // Check to see if the current character is a letter
                if (char.IsLetter(c)) {

                    // Convert the character to lowercase
                    char lowerC = char.ToLower(c);

                    // Apply the shift of 5
                    message += (char)(((lowerC - 5 - 'a'+ 26) % 26) + 'a');

                } else {

                    // If not a letter, just add the character
                    message += c;
                }
            }

            // Put the final message output to upper case
            messageOutput.text = message.ToUpper();

            message = "";
        }
    }

}
