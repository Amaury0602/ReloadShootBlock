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
    public event Action OnActionsReceived;


    public void TimerEnd(int id)
    {
        if (OnTimerEndTrigger != null)
        {
            OnTimerEndTrigger(id);
        }
    }

    public void RefreshTimer()
    {
        if (OnActionsReceived != null)
        {
            OnActionsReceived();
        }
    }
}
