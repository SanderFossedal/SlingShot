
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public class MouseSling : MonoBehaviour
{ 
    [SerializeField] private float forceMultiplier = 10f;
    private Rigidbody2D rigidbody2D;
    private bool isClicked = false;
    [SerializeField] private float slowMotion;
    [SerializeField] private float maxVelocity = 10f;
    [SerializeField] private float strecthMultiplier;
    private Vector2 initialScale;

    private LineRenderer line;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        line = GetComponent<LineRenderer>();
        initialScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player has pressed the mouse button
        if (Input.GetMouseButtonDown(0))
        {
            // Store the start position of the mouse
            //mouseStartPos = Input.mousePosition;
            isClicked = true;

            

            Time.timeScale = slowMotion;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
        }

        stretch();
        // Check if the player has released the mouse button
        if (Input.GetMouseButtonUp(0) && isClicked)
        {
            // Calculate the distance the mouse has moved
            //Vector2 endPosition = Input.mousePosition;
            //Vector2 distance = endPosition - mouseStartPos;

            //// Convert the distance to a force and apply it to the ball
            //Vector2 force = distance * forceMultiplier;
            //rigidbody2D.AddForce(force, ForceMode2D.Impulse);

            Vector2 startPos = line.GetPosition(0);
            Vector2 endPos = line.GetPosition(1);
            Vector2 distance = (startPos - endPos) * forceMultiplier;
            

            rigidbody2D.velocity = Vector2.zero;
            rigidbody2D.AddForce(distance * -1, ForceMode2D.Impulse);

            //Debug.Log(rigidbody2D.velocity.magnitude);
            isClicked = false;

            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.02f;
        }
    }

    private void FixedUpdate()
    {
        // Check if the ball's velocity has exceeded the maximum velocity limit
        if (rigidbody2D.velocity.magnitude > maxVelocity)
        {
            // Scale down the ball's velocity to match the maximum velocity limit
            rigidbody2D.velocity = rigidbody2D.velocity.normalized * maxVelocity;
        }
        //endrer scale tilbake til orginal størrelse
        transform.localScale = Vector2.Lerp(transform.localScale, initialScale, Time.deltaTime * 5);
    }

    private void stretch()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            //endrer på scale.x av ballen
            transform.localScale = new Vector2(transform.localScale.x + line.GetPosition(1).magnitude / 2000, transform.localScale.y);
            //endrer rotasjon av ball til å peke på line pos(1)
            transform.right = line.GetPosition(1) - transform.position;
            if (transform.localScale.x >= 3.6f)
            {
                transform.localScale = new Vector2(3.6f, transform.localScale.y);
            }
        }
    }

}
