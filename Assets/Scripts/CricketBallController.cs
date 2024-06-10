using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class CricketBallController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    private float movementX;
    private float movementY;
    public UIManager _UImanager;

    public int runs;

    Vector3 startPostion;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPostion = transform.position;
    }
    
    void OnMove(InputValue movementValue)
    {

        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;

    }
    
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.1f, movementY);
        rb.AddForce(movement * speed);
        
    }
    public void AddRuns(int score)
    {
        runs += score;
        _UImanager.updateScore(runs);
    }

    // When ball hits the boundary
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Boundary")
        {
            AddRuns(4);
            transform.position = startPostion;
        }
    }

}
