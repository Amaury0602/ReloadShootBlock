using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionCombo : MonoBehaviour
{
    public List<SelectedAction> actionList = new List<SelectedAction>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            actionList.Add(SelectedAction.Null);
        }

        Debug.Log(actionList[0] +" " +  actionList[1] + " " +  actionList[2]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddAction(SelectedAction action)
    {
        actionList[2] = actionList[1];
        actionList[1] = actionList[0];
        actionList[0] = action;
        Debug.Log(actionList[0] + " " + actionList[1] + " " + actionList[2]);
    }
}
