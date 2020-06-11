using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerActions : MonoBehaviour
{
    private Button[] actionButtons;
    SelectedAction selectedAction;


    void Start()
    {
        // lets get the 3 action buttons in an array and add listener so we can set callback
        actionButtons = GetComponentsInChildren<Button>();
        actionButtons[0].onClick.AddListener(delegate { SelectOnClick(0, SelectedAction.Reload); }); //buttonReload
        actionButtons[1].onClick.AddListener(delegate { SelectOnClick(1, SelectedAction.Block); }); //button Block
        actionButtons[2].onClick.AddListener(delegate { SelectOnClick(2, SelectedAction.Shoot); }); //button Shoot
    }
    

    public void SelectOnClick(int index, SelectedAction action)
    {
        selectedAction = action;
    }
}

public enum SelectedAction
{
    //by default, the block action is the selectedAction
    Block, Shoot, Reload
}
