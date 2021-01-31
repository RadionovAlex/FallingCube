using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlexibleCircleCollider : MonoBehaviour
{
    [SerializeField] CircleCollider2D collider;
    [Range(0,1)]
    [SerializeField] float imageFilling;

    public void Start()
    {
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        if(rectTransform!=null)
        {
            var rect = rectTransform.rect;
            this.collider.radius = rect.width / 2 * imageFilling;
        }
        else
        {
            throw new System.Exception("Obj withou rectTransorm: " + this.gameObject.name);
        }
    }
}
