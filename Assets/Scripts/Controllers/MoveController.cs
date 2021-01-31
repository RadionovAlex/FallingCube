using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MovableObject
{
    [SerializeField] InputHandler inputHandler;
    [SerializeField] float xSpeed;

    public event Action OnFallingObjectCollision;
    public bool Flag = false;

    void Start()
    {
        inputHandler.OnScreenDown += InputHandler_OnScreenDown;
        inputHandler.OnScreenUp += InputHandler_OnScreenUp;
    }

    private void OnDestroy()
    {
        inputHandler.OnScreenDown -= InputHandler_OnScreenDown;
        inputHandler.OnScreenUp -= InputHandler_OnScreenUp;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var fallingObect = collision.gameObject.GetComponent<FallingObject>();
        if(fallingObect!=null)
        {
            OnFallingObjectCollision?.Invoke();   
        }
        var border = collision.gameObject.GetComponent<Border>();
        if (border != null)
        {
            rigidbody.velocity = Vector2.zero;
        }
    }

    public void StopObject()
    {
        rigidbody.velocity = Vector2.zero;
    }

    private void InputHandler_OnScreenDown(UnityEngine.EventSystems.PointerEventData obj)
    {
        if (Flag)
        {
            rigidbody.velocity = Vector2.zero;
            if (obj.position.x > Screen.width / 2)
            {
                forceVector = new Vector2(xSpeed, 0);
            }
            else
            {
                forceVector = new Vector2(-xSpeed, 0);
            }
            Move();
        }
    }
    private void InputHandler_OnScreenUp(UnityEngine.EventSystems.PointerEventData obj)
    {
        rigidbody.velocity = Vector2.zero;
    }
}
