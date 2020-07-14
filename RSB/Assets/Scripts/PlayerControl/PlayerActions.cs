using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerActions : MonoBehaviour
{
    [SerializeField] private TimerCircle timer;
    public int id; // id lets you know which player sent the action
    private Button[] actionButtons;
    private ActionCombo actionCombo;
    public bool ActionAlreadySelected { get; set; }
    private PlayerPoints playerPoints;


    void Start()
    {
        GameEvents.current.OnBulletChange += RefreshButton;
        playerPoints = GetComponent<PlayerPoints>();

        // lets get the 3 action buttons in an array and add listener so we can set callback
        actionButtons = GetComponentsInChildren<Button>();
        actionButtons[0].onClick.AddListener(delegate { SendActionOnClick(0, SelectedAction.Reload, id); }); //button Reload
        actionButtons[1].onClick.AddListener(delegate { SendActionOnClick(1, SelectedAction.Block, id); }); //button Block
        actionButtons[2].onClick.AddListener(delegate { SendActionOnClick(2, SelectedAction.Shoot, id); }); //button Shoot

        actionButtons[2].interactable = false; // default : no  bullets so button deactivated

        actionCombo = GetComponent<ActionCombo>();
    }

    private void RefreshButton(int id) // event to check if need to refresh button after reload
    {
        if (this.id == id) actionButtons[2].interactable = playerPoints.Bullets > 0 ? true : false;
    }


    //SelectedAction to send when player clicks on UI button
    public void SendActionOnClick(int index, SelectedAction action, int id)
    {
        if (ActionAlreadySelected) return; // check if already sent action
        ActionAlreadySelected = true; // the bool is set back to false in ActionReceiver.TriggerActions()
        timer.timerMustStop = true; // so the TimerCircle stops running
        actionCombo.AddAction(action);
        ActionReceiver.current.ReceiveAction(id, action);  // send action to ActionReceiver.current with id so you trigger right image
    }
}


public enum SelectedAction
{
    //by default, the block action is the selectedAction, Null because the combo list starts with 3 "Null" actions
    Block, Shoot, Reload, Null
}
