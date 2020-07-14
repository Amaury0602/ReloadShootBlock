using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake()
    {
        current = this;
    }

    public event Action<int> OnTimerEndTrigger;
    public event Action<int> OnPointUpdate;
    public event Action<int> OnBulletChange;
    public event Action OnActionsReceived;


    public void RefreshTimer() // triggered in (Actioneceiver && TimerCircle) 
    {
        if (OnActionsReceived != null)
        {
            OnActionsReceived();
        }
    }

    public void UpdatePoints(int id) // update points according to specific events (PlayerPoints && PointsDisplayer)
    {
        if (OnPointUpdate != null)
        {
            OnPointUpdate(id);
        }
    }

    public void RefreshButton(int id)
    {
        if (OnBulletChange != null)
        {
            OnBulletChange(id);
        }
    }
}
