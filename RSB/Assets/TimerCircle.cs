using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCircle : MonoBehaviour
{
    [SerializeField] private float maximumTime;
    [SerializeField] private int id;
    private float actualTimer;
    private Image fillCircle;

    // Start is called before the first frame update
    void Start()
    {
        actualTimer = maximumTime;
        fillCircle = transform.GetChild(0).GetComponent<Image>();
        GameEvents.current.onTimerEndTrigger += OnTimerEnd;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (actualTimer >= 0) actualTimer -= Time.deltaTime;
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
    }





    private void OnDestroy()
    {
        GameEvents.current.onTimerEndTrigger -= OnTimerEnd;
    }
}
