using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager current;
    [SerializeField] GameObject gameDisplayer;
    [SerializeField] GameObject endScreen;
    private int leftPoints;
    private int rightPoints;
    SceneManager sceneManager;

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
        endScreen.SetActive(true);
    }

    public void NextMatch()
    {
        SceneManager.LoadScene(0);
    }
}
