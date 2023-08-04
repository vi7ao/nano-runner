using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    int lives = 3;
    int score = 0;
    bool alive = true;
    private CharacterController controller;
    [SerializeField]
    private float speed = 5;
    [SerializeField]
    private float jumpHeight;
    [SerializeField]
    private float gravity;
    [SerializeField]
    private float swipeMoveSpeed = 10f;
    [SerializeField]
    private float laneDistance = 2f;
    private float jumpVelocity;

    private bool isSwiping = false;
    private Vector2 startTouchPosition;
    private Vector2 currentTouchPosition;

    private void Update()
    {
        if (!alive) return;

        Vector3 direction = transform.forward * speed;

        if (!controller.isGrounded)
        {   
            direction = transform.forward * (speed - 2);
            jumpVelocity -= gravity * Time.deltaTime;
        }

        direction.y = jumpVelocity;
        controller.Move(direction * Time.deltaTime);

        if (Input.touchCount > 0)
        {
            HandleSwipeGestures();
        }
    }

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void HandleSwipeGestures()
    {
        Touch touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Began)
        {
            isSwiping = true;
            startTouchPosition = touch.position;
            currentTouchPosition = touch.position;
        }
        else if (touch.phase == TouchPhase.Moved)
        {
            currentTouchPosition = touch.position;
        }
        else if (touch.phase == TouchPhase.Ended)
        {
            isSwiping = false;
            DetectSwipeDirection();
        }
    }

    private void DetectSwipeDirection()
    {
        Vector2 swipeDelta = currentTouchPosition - startTouchPosition;

        if (swipeDelta.magnitude < 50f)
            return;

        if (Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y))
        {
            if (swipeDelta.x > 0)
            {
                MoveCharacterRight();
            }
            else
            {
                MoveCharacterLeft();
            }
        }
        else
        {
            if (swipeDelta.y > 0)
            {
                Jump();
            }
            else
            {
                // Swipe down (crouch, if needed)
            }
        }
    }

    private void MoveCharacterLeft()
    {
        int targetLane = Mathf.RoundToInt(transform.position.x / laneDistance) - 1;
        targetLane = Mathf.Clamp(targetLane, -1, 1); // Clamp the target lane to stay between -1 and 1
        float targetX = targetLane * laneDistance;
        Vector3 newPosition = new Vector3(targetX, transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, newPosition, swipeMoveSpeed * Time.deltaTime);
    }

    private void MoveCharacterRight()
    {
        int targetLane = Mathf.RoundToInt(transform.position.x / laneDistance) + 1;
        targetLane = Mathf.Clamp(targetLane, -1, 1); // Clamp the target lane to stay between -1 and 1
        float targetX = targetLane * laneDistance;
        Vector3 newPosition = new Vector3(targetX, transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, newPosition, swipeMoveSpeed * Time.deltaTime);
    }

    private void Jump()
    {
        if (controller.isGrounded)
        {
            jumpVelocity = jumpHeight;
        }
    }

    public void Die()
    {
        Debug.Log("Player died!");
        alive = false;
        Invoke("Restart", 2);
    }

    void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
