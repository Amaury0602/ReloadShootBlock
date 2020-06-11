using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCircle : MonoBehaviour
{
    [SerializeField] private float maximumTime;
    private float actualTimer;
    private Image fillCircle;

    // Start is called before the first frame update
    void Start()
    {
        actualTimer = maximumTime;
        fillCircle = transform.GetChild(0).GetComponent<Image>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (actualTimer >= 0) actualTimer -= Time.deltaTime;
        fillCircle.fillAmount = actualTimer / maximumTime;


        if (actualTimer <= 0 && Input.GetKeyDown(KeyCode.P)) actualTimer = maximumTime;
    }
}
