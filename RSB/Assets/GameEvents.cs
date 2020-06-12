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

    public event Action<int> onTimerEndTrigger;


    public void TimerEnd(int id)
    {
        if (onTimerEndTrigger != null)
        {
            onTimerEndTrigger(id);
        }
    }
}
