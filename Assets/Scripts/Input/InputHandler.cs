using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public event Action<PointerEventData> OnScreenDown;
    public event Action<PointerEventData> OnScreenUp;
    public void OnPointerDown(PointerEventData eventData)
    {
        OnScreenDown?.Invoke(eventData);
        if(eventData.position.x > Screen.width/2)
        {
            Debug.Log("Right");
        }
        else
        {
            Debug.Log("Left");
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnScreenUp?.Invoke(eventData);
        Debug.Log("On pointer up");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
