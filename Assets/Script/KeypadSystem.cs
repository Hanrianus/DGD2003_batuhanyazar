using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class KeypadSystem : MonoBehaviour
{
    [Header("UI Elemanlarý")]
    public GameObject keypadPanel;
    public TextMeshProUGUI displayText;

    [Header("Ayarlar")]
    public string correctCode = "1234";
    public SimpleSlideDoor targetDoor;

    private string currentInput = "";

    void Update()
    {
       
        if (keypadPanel.activeSelf && Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            CloseKeypad();
        }
    }

    public void OpenKeypad()
    {
        keypadPanel.SetActive(true);
        currentInput = "";
        displayText.text = "";
        displayText.color = Color.white;

        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        var pm = FindObjectOfType<PlayerMovement>();
        if (pm != null) pm.isHacking = true;
    }

    public void CloseKeypad()
    {
        keypadPanel.SetActive(false);

        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        var pm = FindObjectOfType<PlayerMovement>();
        if (pm != null) pm.isHacking = false;
    }

    
    public void PressButton(string number)
    {
        if (currentInput.Length < 4)
        {
            currentInput += number;
            displayText.text = currentInput;
        }

        
        if (currentInput.Length == 4)
        {
            CheckCode();
        }
    }

    public void CheckCode()
    {
        if (currentInput == correctCode)
        {
            displayText.text = "ERÝSÝM ONAYLANDI";
            displayText.color = Color.green;

         
            if (targetDoor != null)
            {
                targetDoor.OpenDoor();
            }

           
            Invoke("CloseKeypad", 1f);
        }
        else
        {
            displayText.text = "HATALI SÝFRE";
            displayText.color = Color.red;
            currentInput = ""; 
            Invoke("ResetDisplay", 1f);
        }
    }

    void ResetDisplay()
    {
        if (currentInput == "")
        {
            displayText.text = "";
            displayText.color = Color.white;
        }
    }
}