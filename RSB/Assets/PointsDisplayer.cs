using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsDisplayer : MonoBehaviour
{
    private PlayerPoints playerPoints;
    private Text pointsText;
    private int id;

    private void Awake()
    {
        id = GetComponentInParent<PlayerPoints>().id;
        pointsText = GetComponent<Text>();
    }

    void Start()
    {
        GameEvents.current.OnPointUpdate += UpdatePoints;
        playerPoints = GetComponentInParent<PlayerPoints>();
    }

    public void UpdatePoints(int id) // points are updated in PlayerPoints script
    {
        if (id == this.id)
        {
            pointsText.text = playerPoints.Points.ToString();
        }
    }


    private void OnDestroy()
    {
        GameEvents.current.OnPointUpdate -= UpdatePoints;
    }
}
