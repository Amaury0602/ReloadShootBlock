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
    public event Action OnActionsReceived;


    public void RefreshTimer()
    {
        if (OnActionsReceived != null)
        {
            OnActionsReceived();
        }
    }

    public void UpdatePoints(int id)
    {
        if (OnPointUpdate != null)
        {
            OnPointUpdate(id);
        }
    }
}
