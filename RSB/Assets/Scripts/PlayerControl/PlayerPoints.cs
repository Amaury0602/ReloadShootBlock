using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPoints : MonoBehaviour
{
    public int id;
    private float pointIncrementInterval = .5f;
    private float elapsedTime;
    public int Points { get; set; }
    private SelectedAction otherAction;
    private SelectedAction myAction;
    private ActionReceiver actionReceiver;
    public int Bullets { get; set; }

    void Start()
    {
        Bullets = 0;
        actionReceiver = ActionReceiver.current;
        elapsedTime = pointIncrementInterval;
    }


    void Update()
    {
        PointsGoingUp();
    }


    void PointsGoingUp()
    {
        pointIncrementInterval -= Time.deltaTime;
        if (pointIncrementInterval <= 0)
        {
            Points++;
            GameEvents.current.UpdatePoints(id);
            pointIncrementInterval = elapsedTime;
        }
    }


    public void GetOtherPlayerAction(SelectedAction leftPlayerAction, SelectedAction rightPlayerAction)
    {
        bool onPlayerLeft = id == 0 ? true : false;
        otherAction = onPlayerLeft ? rightPlayerAction : leftPlayerAction;
        myAction = onPlayerLeft ? leftPlayerAction : rightPlayerAction;

        switch (otherAction) // we receive the other player's action --> only shoot finally
        {
            case SelectedAction.Block:
                break;

            case SelectedAction.Shoot:
                //get shot if myAction != Block
                if (myAction == SelectedAction.Block) return;
                GetShot();
                break;

            default:
                break;
        }

        switch (myAction)
        {
            case SelectedAction.Shoot:
                Bullets--;
                GameEvents.current.RefreshButton(id);
                break;

            case SelectedAction.Reload:
                Bullets++;
                GameEvents.current.RefreshButton(id);
                break;

            default:
                break;
        }

        // i can get back the time to pick action here
    }

    private void GetShot()
    {
        Points -= 20;
        GameEvents.current.UpdatePoints(id);
    }
}
