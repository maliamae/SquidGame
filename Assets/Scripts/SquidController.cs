using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SquidController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float rotationSpeed = 15f;

    public float moveSpeed = 20f;
    public GameObject squidSprite;
    public float dashSpeedMult = 2f;
    public float dashDuration = .25f;
    
    public bool hasDashed = false;

    public PlayerControls playerControls;
    private InputAction move;
    private InputAction dash;

    public bool hitWater;
    public bool inWater;
    public bool hasSpedUp = false;

    public Vector3 velocity;

    private Vector2 inputVal;
    
    

    private void Awake()
    {
        playerControls = new PlayerControls();
        
        
    }

    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();

        dash = playerControls.Player.Dash;
        dash.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
        dash.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        direction = move.ReadValue<Vector2>();
        //direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.MoveTowards(transform.position, cursorPos, moveSpeed * Time.deltaTime);
        */


        //Debug.Log(move.ReadValue<Vector2>());
        /*
        float angle = Mathf.Atan2(target.transform.position.y, target.transform.position.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        */
        
        StartCoroutine(CalculateVel());
        if (inWater != true)
        {
            /*
            inputVal = Vector2.zero;

            Vector3 posChange = transform.up * inputVal.y + transform.right * inputVal.x; //stop effecting up axis while above water
            posChange = posChange * moveSpeed * Time.deltaTime;

            transform.position += posChange;

            Vector3 movementDir = new Vector3(move.ReadValue<Vector2>().x, move.ReadValue<Vector2>().y, 0);
            movementDir.Normalize();

            if (movementDir != Vector3.zero)
            {
                //squidSprite.transform.right = movementDir;
                squidSprite.transform.right = Vector3.Lerp(squidSprite.transform.right, movementDir, rotationSpeed * Time.deltaTime);
            }


            if (dash.WasPressedThisFrame() && hasDashed == false)
            {
                StartCoroutine(PlayerDash());
            }
            */
            //Vector3 force = new Vector3(1, 1, 0);
            //rb.AddForce(force, ForceMode2D.Impulse);
            

            if (rb.velocity != Vector2.zero)
            {
                //squidSprite.transform.right = movementDir;
                squidSprite.transform.right = Vector3.Lerp(squidSprite.transform.right, rb.velocity, rotationSpeed * Time.deltaTime);
                
            }

            /*
            if (hasSpedUp != true)
            {
                rb.velocity *= 2;
                hasSpedUp = true;
            }
            */
            
        }
        else
        {
            inputVal = move.ReadValue<Vector2>();

            Vector3 posChange = transform.up * inputVal.y + transform.right * inputVal.x; 
            posChange = posChange * moveSpeed * Time.deltaTime;

            transform.position += posChange;

            Vector3 movementDir = new Vector3(move.ReadValue<Vector2>().x, move.ReadValue<Vector2>().y, 0);
            movementDir.Normalize();

            if (movementDir != Vector3.zero)
            {
                //squidSprite.transform.right = movementDir;
                squidSprite.transform.right = Vector3.Lerp(squidSprite.transform.right, movementDir, rotationSpeed * Time.deltaTime);
            }


            if (dash.WasPressedThisFrame() && hasDashed == false)
            {
                StartCoroutine(PlayerDash());
            }
        }

        


    }

    private void FixedUpdate()
    {
        if (hitWater == true)
        {
            //rb.velocity = Vector2.Lerp(rb.velocity, Vector2.zero, Time.deltaTime * 1);
            StartCoroutine(LerpVelocity(rb.velocity, Vector2.zero, 1f));
        }
    }

    IEnumerator PlayerDash()
    {
        float initialSpeed = moveSpeed;
        //float initialSquidSpeed = squidSprite.moveSpeed;
        moveSpeed *= dashSpeedMult;
        //squidSprite.moveSpeed = moveSpeed;
        hasDashed = true;

        //Debug.Log("Squid Speed: " +  squidSprite.moveSpeed);
        yield return new WaitForSeconds(dashDuration);

        moveSpeed = initialSpeed;
        //squidSprite.moveSpeed = initialSquidSpeed;
        hasDashed = false;
        
    }

    IEnumerator LerpVelocity(Vector2 initialVel, Vector2 finalVel, float duration)
    {
        float timeElapsed = 0;
        while (timeElapsed < duration)
        {
            float t = timeElapsed / duration;
            rb.velocity = Vector2.Lerp(initialVel, finalVel, t);
            timeElapsed += Time.deltaTime;

            yield return null;
        }

        rb.velocity = finalVel;
        
    }

    IEnumerator CalculateVel()
    {
        Vector3 previousPos = transform.position;
        yield return new WaitForEndOfFrame();

        velocity = (transform.position - previousPos)/Time.deltaTime;
        //Debug.Log("Custom vel: " + velocity.normalized);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Rock")
        {
            float pushX = Random.Range(-1f, 1f);
            float pushY = Random.Range(-1f, 1f);
            rb.AddForce(new Vector2(pushX*3, pushY*3), ForceMode2D.Impulse);

            Debug.Log("Rock Hit");
        }
    }

}
