﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCircle : MonoBehaviour
{
    [SerializeField] private float maximumTime;
    [SerializeField] private int id;
    public bool timerMustStop;
    private float actualTimer;
    private Image fillCircle;
    [SerializeField] private PlayerActions playerAction;

    // Start is called before the first frame update
    void Start()
    {
        timerMustStop = false;
        actualTimer = maximumTime;
        fillCircle = transform.GetChild(0).GetComponent<Image>();
        GameEvents.current.OnActionsReceived += RefreshTimer; // when both players sent action
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (actualTimer >= 0 && !timerMustStop) actualTimer -= Time.deltaTime; //timerMustStop is changed to true in PlayerAction.SendActionOnClick()
        fillCircle.fillAmount = actualTimer / maximumTime;


        if (actualTimer <= 0) SendDefaultAction(id);
    }

    private void SendDefaultAction(int id)
    {
        playerAction.SendActionOnClick(1, SelectedAction.Block, playerAction.id); // the default sent action is Block
    }


    public void RefreshTimer() // event triggered in ActionReceiver
    {
        actualTimer = maximumTime;
        timerMustStop = false;
    }



    
    private void OnDestroy()
    {
        GameEvents.current.OnActionsReceived -= RefreshTimer;
    }
}
