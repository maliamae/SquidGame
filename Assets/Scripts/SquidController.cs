using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SquidController : MonoBehaviour
{
    private Rigidbody2D rb;
    //public float rotationSpeed;
    private Vector2 direction;

    public float moveSpeed;
    public SquidHeadControls squidSprite;
    public float dashSpeedMult = 2f;
    public float dashDuration = .25f;
    
    private bool hasDashed = false;

    public PlayerControls playerControls;
    private InputAction move;
    private InputAction dash;
    //public float squidSpriteSpeed;

    private void Awake()
    {
        playerControls = new PlayerControls();
        //squidSpriteSpeed = squidSprite.GetComponent<SquidHeadControls>().moveSpeed;
        
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
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.MoveTowards(transform.position, cursorPos, moveSpeed * Time.deltaTime);
        */

        direction = move.ReadValue<Vector2>();

        if (dash.WasPressedThisFrame() && hasDashed == false)
        {
            StartCoroutine(PlayerDash());
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);
    }

    /*
    private void PlayerDash()
    {

    }
    */

    IEnumerator PlayerDash()
    {
        float initialSpeed = moveSpeed;
        float initialSquidSpeed = squidSprite.moveSpeed;
        moveSpeed *= dashSpeedMult;
        squidSprite.moveSpeed = moveSpeed;
        hasDashed = true;

        //Debug.Log("Squid Speed: " +  squidSprite.moveSpeed);
        yield return new WaitForSeconds(dashDuration);

        moveSpeed = initialSpeed;
        squidSprite.moveSpeed = initialSquidSpeed;
        hasDashed = false;
    }
}
