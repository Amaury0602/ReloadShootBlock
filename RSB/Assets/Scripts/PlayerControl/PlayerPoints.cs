using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPoints : MonoBehaviour
{
    public int id;
    private float pointIncrementInterval = .5f;
    float elapsedTime;
    public int Points { get; set; }

    private void Awake()
    {
        id = GetComponent<PlayerActions>().id;
    }

    void Start()
    {
        elapsedTime = pointIncrementInterval;
    }

    // Update is called once per frame
    void Update()
    {
        PointsGoingUp();
        Debug.Log(Points);
    }


    void PointsGoingUp()
    {
        pointIncrementInterval -= Time.deltaTime;
        if (pointIncrementInterval <= 0)
        {
            Points++;
            pointIncrementInterval = elapsedTime;
        }
    }
}
