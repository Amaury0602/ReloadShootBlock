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

    private void Awake()
    {
        current = this;
    }

    void Start()
    {
        initialColor = leftSquare.color;
    }
    
    public void ReceiveAction(int imageId) // id == 1 is Left player action
    {
        if (imageId == 0) leftSquare.color = Color.green;
        if (imageId == 1) rightSquare.color = Color.green;
        if (squareTriggered == 1) // and just received the second action
        {
            // TriggerActions();
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

    //private void TriggerActions()
    //{
    //    send data to players / score;
    //    refresh timer;
    //    set square triggers to false;
    //}

}
