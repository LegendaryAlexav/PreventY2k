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

            messageInput.text = "";
            messageOutput.text = message;
            message = "";
        }

    }

    public void TranslateVigenere() {

        if (vigenereButtonCount == 0) { // If the button is pressed for the first time

            // If the input field is empty
            if (messageInput.text == "") {

                messageOutput.text = "You have given me NOTHING!";

            } else {
                
                // Store the input field's text into the temp variable, and request the key
                vigenereTempMessage = messageInput.text;
                messageInput.text = "";
                messageOutput.text = "Please now enter the key";
                vigenereButtonCount++;

            }
            
        } else if (vigenereButtonCount == 1) { // If the button is pressed for the second time

            // Modify the key string and setup key counter
            String key = messageInput.text.ToLower();
            int keyCounter = 0;

            // For every character in the given message
            foreach (char c in vigenereTempMessage.ToLower().Trim()) {

                // If the character is a letter
                if (char.IsLetter(c)) {

                    // If the counter reaches the end of the key
                    if (keyCounter == key.Length) {

                        // Reset the counter
                        keyCounter = 0;
                    }

                    // Decrypt the character
                    int x = (c - key[keyCounter] + 26) % 26;
                    x += 'A';
                    message += (char) x;

                    // Increase the counter
                    keyCounter++;

                } else {

                    //If not a letter, just add the character
                    message += c;

                }

            }

            // Do final cleanup
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
                    message += (char)(((lowerC - 10 - 'a'+ 26) % 26) + 'a');

                } else {

                    // If not a letter, just add the character
                    message += c;
                }
            }

            messageInput.text = "";
            // Put the final message output to upper case
            messageOutput.text = message.ToUpper();

            message = "";
        }
    }

    public void TranslateAtBash() {

        // If the input field is empty
        if (messageInput.text == "") {

            messageOutput.text = "You have given me NOTHING!";

        } else {

            char[] characterList = messageInput.text.Trim().ToCharArray();

            // Loop through every character in the input
            foreach (char c in characterList) {
                
                // If the current character is a letter
                if (char.IsLetter(c)) {

                    // Apply character converison on lowercase letters
                    if (c >= 'a' && c <= 'z') {
                        message += (char) (96 + (123 - c));
                    }

                    // Apply character conversion in uppercase letters
                    if (c >= 'A' && c <= 'Z') {
                        message += (char) (64 + (91 - c));
                    }

                } else {

                    // If not a letter, just add the character
                    message += c;
                }
            }

            messageInput.text = "";
            messageOutput.text = message;
            message = "";

        }
    }

}
