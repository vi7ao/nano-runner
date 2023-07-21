using UnityEngine;

public class SwipeDetection : MonoBehaviour
{

    [SerializeField]
    private float minimumDistance = .2f;
    [SerializeField]
    private float maximumTime = 1f;
    [SerializeField, Range(0f, 1f)]
    private float directionThreshold = .9f;
    private InputManager inputManager;
    private Vector2 startPosition, endPosition;
    private float startTime, endTime;
    private Movement movementScript;

    private void Awake(){
        inputManager = InputManager.Instance;
        movementScript = GetComponent<Movement>();
    }

    private void OnEnable(){
        inputManager.OnStartTouch += SwipeStart;
        inputManager.OnEndTouch += SwipeEnd;
    }

    private void OnDisable(){
        inputManager.OnStartTouch -= SwipeStart;
        inputManager.OnEndTouch -= SwipeEnd;
    }

    private void SwipeStart(Vector2 position, float time){
        startPosition = position;
        startTime = time;
    }

    private void SwipeEnd(Vector2 position, float time){
        endPosition = position;
        endTime = time;
        DetectSwipe();
    }

    private void DetectSwipe(){
        if (Vector3.Distance(startPosition, endPosition) >= minimumDistance && (endTime - startTime) <= maximumTime){
            Debug.Log("Swipe Detected");
            Debug.DrawLine(startPosition, endPosition, Color.red, 5f);
            Vector3 direction = endPosition - startPosition;
            Vector2 direction2D = new Vector2(direction.x, direction.y);
            SwipeDirection(direction2D);
        }
    }

    private void SwipeDirection(Vector2 direction){
        if (Vector2.Dot(Vector2.up, direction) > directionThreshold ){
            Debug.Log("Swipe Up");
        }
        if (Vector2.Dot(Vector2.down, direction) > directionThreshold ){
            Debug.Log("Swipe Down");
        }
        if (Vector2.Dot(Vector2.right, direction) > directionThreshold ){
            movementScript.SwipeMove(Vector2.right);
        }
        if (Vector2.Dot(Vector2.left, direction) > directionThreshold ){
            movementScript.SwipeMove(Vector2.left);
        }
    }
}
