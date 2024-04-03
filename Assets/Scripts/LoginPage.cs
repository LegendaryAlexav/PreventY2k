using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Login : MonoBehaviour
{

    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;

    public TMP_Text logInMessage;

    public void LogIn() {

        if (usernameInput.text == "" || passwordInput.text == "") {

            logInMessage.text = "Please fill in all given values";

        } else if (usernameInput.text != "PTHughesSDG" || passwordInput.text != "SwagThursday") {

            logInMessage.text = "Invalid password/username!";

        } else {

            logInMessage.text = "Success!";

        }


    }

    void OnGUI() {

        Event e = Event.current;

        if (e.type == EventType.KeyDown && e.keyCode == KeyCode.Return) {
            LogIn();
        }
        
    }

    /* 
    
    Username: PTHughesSDG
    Password: SwagThursday
    
    */

}
