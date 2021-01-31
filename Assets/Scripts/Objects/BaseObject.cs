using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseObject : MonoBehaviour
{
    private float x;
    private float y;

    [Range(0, 10)]
    [SerializeField] private float speed;
    Transform transform;
    private MoveDirections direction;

    public float X
    {
        get => x;
        set => x = value;
    }

    public float Y
    {
        get => y;

        set => y = value;
    }

    public float Speed
    {
        get => speed;
        set => speed = value;
    }

    public MoveDirections Direction
    {
        get => direction;
        set => direction = value;
    }

    public Transform ObjectTransform
    {
        get => transform;
        set => transform = value;
    }
    
    private IEnumerator Move()
    {
        var innerSpeed = speed;
        while(innerSpeed > 0)
        {
            if(innerSpeed <= 0)
            {
                yield break;
            }
            Vector3 currentPos = transform.position;
            
        }

    }

    protected void StartNewMove()
    {
        StopAllCoroutines();
        StartCoroutine(Move());
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    
}
