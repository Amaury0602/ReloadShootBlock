using System.Collections;
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
        GameEvents.current.onTimerEndTrigger += OnTimerEnd;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (actualTimer >= 0 && !timerMustStop) actualTimer -= Time.deltaTime;
        fillCircle.fillAmount = actualTimer / maximumTime;


        if (actualTimer <= 0)
        {
            GameEvents.current.TimerEnd(id);
            actualTimer = maximumTime; // the timer just loops so we can test it
        }
    }

    private void OnTimerEnd(int id)
    {
        if (id == this.id) Debug.Log("the times endsssss"); // trigger something when timer ends
        playerAction.SendActionOnClick(1, SelectedAction.Block, playerAction.id); // the default sent action is Block
        //player cannot pickAction anymore
    }

    
    private void OnDestroy()
    {
        GameEvents.current.onTimerEndTrigger -= OnTimerEnd;
    }
}
