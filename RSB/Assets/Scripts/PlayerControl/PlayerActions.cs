using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerActions : MonoBehaviour
{
    [SerializeField] private TimerCircle timer;
    [SerializeField] public int id; // id lets you know which player sent the action
    private Button[] actionButtons;
    public SelectedAction ClickedAction { get; set; }


    void Start()
    {
        // lets get the 3 action buttons in an array and add listener so we can set callback
        actionButtons = GetComponentsInChildren<Button>();
        actionButtons[0].onClick.AddListener(delegate { SendActionOnClick(0, SelectedAction.Reload, id); }); //buttonReload
        actionButtons[1].onClick.AddListener(delegate { SendActionOnClick(1, SelectedAction.Block, id); }); //button Block
        actionButtons[2].onClick.AddListener(delegate { SendActionOnClick(2, SelectedAction.Shoot, id); }); //button Shoot
    }


    //SelectedAction to send when player clicks on UI button
    public SelectedAction SendActionOnClick(int index, SelectedAction action, int id)
    {
        timer.timerMustStop = true; // so the TimerCircle stops running
        return action;
        // send action to ActionReceiver.current with id so you trigger right image
    }
}




public enum SelectedAction
{
    //by default, the block action is the selectedAction
    Block, Shoot, Reload
}
