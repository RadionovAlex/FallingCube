using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D rigidbody;
    [SerializeField] protected Vector2 forceVector;

    protected void Move()
    {
        rigidbody.AddForce(forceVector, ForceMode2D.Impulse);
    }
}
