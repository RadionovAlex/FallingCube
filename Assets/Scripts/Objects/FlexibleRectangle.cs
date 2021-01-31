using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlexibleRectangle : MonoBehaviour
{
    [SerializeField] RectTransform rectTransform;
    [SerializeField] float percentSize;
    void Start()
    {
        Rect rect = rectTransform.rect;
        rect.width = Screen.width * percentSize;
        rect.height = Screen.height * percentSize;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
