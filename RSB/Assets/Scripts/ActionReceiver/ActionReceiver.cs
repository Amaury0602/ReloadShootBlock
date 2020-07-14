using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionReceiver : MonoBehaviour
{
    public static ActionReceiver current;
    [SerializeField] Image leftSquare;
    [SerializeField] Image rightSquare;
    private Color initialColor;
    private int playerPlayed = 0;
    private SelectedAction leftPlayerAction;
    private SelectedAction rightPlayerAction;
    PlayerActions[] players;
    PlayerPoints[] playerPoints;


    private void Awake()
    {
        current = this;
    }

    void Start()
    {
        players = FindObjectsOfType<PlayerActions>(); // find a better way to reference those objects
        playerPoints = FindObjectsOfType<PlayerPoints>(); // find a better way to reference those objects
        leftPlayerAction = SelectedAction.Null;
        rightPlayerAction = SelectedAction.Null;
        initialColor = leftSquare.color;
    }

    public void ReceiveAction(int playerId, SelectedAction action)
    {
        if (playerId == 0) // left player
        {
            leftSquare.color = Color.green;
            leftPlayerAction = action;            
        }
        else if (playerId == 1) // right player
        {
            rightSquare.color = Color.green;
            rightPlayerAction = action;
        }

        if (playerPlayed == 1) // so is receiving the second action
        {
            TriggerActions();
        }
        else
        {
            playerPlayed++;
        }
    }

    public void RefreshImages()
    {
        leftSquare.color = initialColor;
        rightSquare.color = initialColor;
    }

    private void TriggerActions()
    {
        playerPlayed = 0; // reset the square so turn goes back to beginning
        //StartCoroutine(RefreshTimerTimeout()); 
        GameEvents.current.RefreshTimer(); // sends event to both timers and RefreshTimers() (GameEvents)
        RefreshImages();
        foreach (var player in players)
        {
            player.ActionAlreadySelected = false;
        }

        // check if actionCombo exists for the specific player

        foreach (var playerPoint in playerPoints)
        {
            playerPoint.GetOtherPlayerAction(leftPlayerAction, rightPlayerAction);
        }

        // set a little timer



        RoundsManager.current.NextRound();
    }

    IEnumerator RefreshTimerTimeout()
    {
        yield return new WaitForSeconds(3f);
        GameEvents.current.RefreshTimer();
    }
}
