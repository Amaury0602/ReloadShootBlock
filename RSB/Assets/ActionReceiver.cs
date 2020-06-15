using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionReceiver : MonoBehaviour
{
    public static ActionReceiver current;
    public Image[] actionImage;

    private void Awake()
    {
        current = this;
    }

    void Start()
    {
        actionImage = GetComponentsInChildren<Image>(); // we get both images in children
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
