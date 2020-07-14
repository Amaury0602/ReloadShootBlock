using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager current;
    [SerializeField] GameObject gameDisplayer;
    private int leftPoints;
    private int rightPoints;

    private void Awake()
    {
        current = this;
    }

    private void Start()
    {
        //GameEvents.current.OnPointUpdate += UpdatePoints;
    }

    public void SetGameOver()
    {
        // get both player points
        // get historic of actions + combos
        gameDisplayer.SetActive(false);
    }
}
