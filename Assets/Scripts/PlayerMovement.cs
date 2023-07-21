using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController controller;
    public float speed = 5;
    public float jumpHeight;
    public float gravity;
    private float jumpVelocity;
    private Vector2 startTouchPosition, endTouchPosition;

    private void Update() {
        Vector3 direction = transform.forward * speed;
        if (controller.isGrounded) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                jumpVelocity = jumpHeight;
            }
        } else {
            jumpVelocity -= gravity;
        }
        direction.y = jumpVelocity;
        controller.Move(direction * Time.deltaTime);
    }

    private void Start(){
        controller = GetComponent<CharacterController>();
    }
}