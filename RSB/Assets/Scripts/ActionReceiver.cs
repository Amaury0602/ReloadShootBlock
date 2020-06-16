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
    private int squareTriggered = 0;
    SelectedAction leftPlayerAction;
    SelectedAction rightPlayerAction;

    private void Awake()
    {
        current = this;
    }

    void Start()
    {
        leftPlayerAction = SelectedAction.Null;
        rightPlayerAction = SelectedAction.Null;
        initialColor = leftSquare.color;
    }

    public void ReceiveAction(int imageId, SelectedAction action)
    {
        if (imageId == 0) // left player
        {
            leftSquare.color = Color.green;
            leftPlayerAction = action;
        }
        else if (imageId == 1) // right player
        {
            rightSquare.color = Color.green;
            rightPlayerAction = action;
        }

        if (squareTriggered == 1) // and just received the second action
        {
            TriggerActions();
        }
        else
        {
            squareTriggered++;
        }
    }

    public void RefreshImages()
    {
        leftSquare.color = initialColor;
        rightSquare.color = initialColor;
    }

    private void TriggerActions()
    {
        squareTriggered = 0; // reset the square so turn goes back to beginning
        Debug.Log(leftPlayerAction + "  " + rightPlayerAction);
        //send data to players / score;
        GameEvents.current.RefreshTimer(); // sends event to both timers and RefreshTimers()
        RefreshImages();
    }
}
