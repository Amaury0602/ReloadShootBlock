using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundsManager : MonoBehaviour
{
    public static RoundsManager current;

    private Image[] roundImages;
    private int actualRound = 0;


    private void Awake()
    {
        current = this;
    }

    void Start()
    {
        roundImages = GetComponentsInChildren<Image>();
    }
    
    public void NextRound()
    {
        roundImages[actualRound].color = Color.green;
        roundImages[actualRound].color = new Color(roundImages[actualRound].color.r, 1, roundImages[actualRound].color.b, 1f);
        actualRound++;
        if (actualRound == roundImages.Length)
        {
            GameManager.current.SetGameOver();
        }
    }
}
