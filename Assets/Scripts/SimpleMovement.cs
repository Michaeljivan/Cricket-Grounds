using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public float movementX;
    public float movementY;
    public UIManager _UImanager;
    public int runs;
    public int wickets;
    public float jumpSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = 10;
    }
    private void FixedUpdate()
    {
        // we need to take the input from the arrow keys pressed by the player. By default in unity, the left and right arrow keys are labeled as "Horizontal" and the up and down arrow keys as "Vertical"
        // we will define two variables where the value of each will be set "several times per frame" if the player presses the HorizontalMovement (i.e. the left or right key) and/or the VerticalMovement (i.e. the up or down key)
        float HorizontalMovement = Input.GetAxis("Horizontal");
        float VerticalMovement = Input.GetAxis("Vertical");

        // since we are dealing with three dimensional space, we will need to define a 3D vector based on which the ball should move. As such, we define a Vector3 called MoveBall that takes three parameters of X,Y,Z
        // movement on the X axis will be our HorizontalMovement (i.e. the left or right key) and on the Z axis the VerticalMovement (i.e. the up or down key). As we do not want to move the ball in the Y axis in the 3D space (i.e. up and down in the 3D space), the Y value will be set to 0
        Vector3 MoveBall = new Vector3(HorizontalMovement, 0, VerticalMovement);

        //lastly, we will need to access the physics component of our ball game object (i.e. the Rigidbody) and add a force to it based on the values of the vector we just defined. We will multiple this force value with our Speed variable to be able to control the Speed of the force as we wish.
        gameObject.transform.GetComponent<Rigidbody>().AddForce(MoveBall * speed);
    }

    public void AddRuns(int run)
    {
        runs += run;
        _UImanager.updateScore(runs);
    }

    public void AddWicket(int w)
    {
        wickets += w;
        _UImanager.updateWicket(wickets);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Boundary")
        {
            AddRuns(4);
            transform.position = new Vector3(0.64f, 0.147f, 0);
        }

        if (collision.gameObject.tag == "SixField")
        {
            AddRuns(6);
            transform.position = new Vector3(0.64f, 0.147f, 0);
        }
        if(collision.gameObject.tag == "Wicket")
        {
            AddWicket(1);
            Debug.Log("Wicket hit");
            Destroy(collision.gameObject);
            transform.position = new Vector3(0.64f, 0.147f, 0);
            
        }
    }
}
