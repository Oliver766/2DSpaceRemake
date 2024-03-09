using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonUpdate : MonoBehaviour
{
    public ScriptableObjectshop objectshop;

    public TextMeshProUGUI namext;

    public int choice;

    private void Start()
    {
        objectshop.unlocked = false;
    }

    public void Update()
    {
        namext.text = objectshop.Name;
        
    }

    public void buy()
    {
        choice = objectshop.choice;
        PlayerPrefs.SetInt("choice", choice);
        Debug.Log(choice);
        objectshop.unlocked = true;
    }


}
