using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlexibleCollider : MonoBehaviour
{
    [SerializeField] BoxCollider2D collider;
    protected void Start()
    {
        RectTransform rectTransform = this.GetComponent<RectTransform>();
        if (rectTransform != null)
        {
            var rect = rectTransform.rect;
            this.collider.size = new Vector2(rect.width, rect.height);
        }
        else
        {
            throw new System.Exception("Obj withou rectTransorm: " + this.gameObject.name);
        }
    }
}
