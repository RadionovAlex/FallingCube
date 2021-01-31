using Assets.Scripts.Objects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    float ySpeed = 0f;
    float multiplexer = 0.1f;
    
    [SerializeField] private Vector2 minStartPosition;
    [SerializeField] private Vector2 maxStartPosition;
    [SerializeField] private Vector2 goalPosition;
    [SerializeField] float startYSpeed;
    [SerializeField] float maxSpeed;
    [SerializeField] Vector2 fallingVector;

    public event Action OnFalled;
    private void Start()
    {
        ySpeed = startYSpeed;
        multiplexer = UnityEngine.Random.Range(0.05f, 0.1f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        var border = collision.gameObject.GetComponent<WorldEdge>();
        if (border != null)
        {
            OnFalled?.Invoke();
            IncreaseSpeed();
            ToStartPosition();
        }
    }

    public void StartMove()
    {
        StopAllCoroutines();
        ToStartPosition();
        StartCoroutine(InfinityMove());
    }

    public void EndMove()
    {
        StopAllCoroutines();
        ToStartPosition();
        ySpeed = startYSpeed;
    }

    public void IncreaseSpeed()
    {
        var newSpeed = ySpeed + ySpeed * multiplexer;
        ySpeed = newSpeed <= maxSpeed ? newSpeed : ySpeed;
    }
    

    private void ToStartPosition()
    {
        GenerateNewPosition();   
    }

    private IEnumerator InfinityMove()
    {
        var currentPosition = transform.position;
        while(currentPosition.y > goalPosition.y)
        {
            Vector3 curPosition = transform.position;
            Vector3 moveVector = new Vector3(curPosition.x, curPosition.y + fallingVector.y * ySpeed * Time.deltaTime, curPosition.z);
            transform.position =  moveVector;

            yield return new WaitForFixedUpdate();
        }        
    }

    private void GenerateNewPosition()
    {
        var x = UnityEngine.Random.Range(minStartPosition.x, maxStartPosition.x);
        var y = UnityEngine.Random.Range(minStartPosition.y, maxStartPosition.y);
        var curZ = transform.position.z;

        transform.position = new Vector3(x, y, curZ);
    }

}
