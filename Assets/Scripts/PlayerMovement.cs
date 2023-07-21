using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController controller;
    [SerializeField]
    private float speed = 5;
    [SerializeField]
    private float jumpHeight;
    [SerializeField]
    private float gravity;
    private float jumpVelocity;

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

    public void SwipeMove(Vector2 direction){
        if (direction.x > 0){
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (direction.x < 0){
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (direction.y > 0){
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        if (direction.y < 0){
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
    }
}