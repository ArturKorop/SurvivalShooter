using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 6f;

    Vector3 movement;
    Animator anim;
    Rigidbody playerRigidbody;
    int floorMask;
    float camRayLength = 100f;

    public void Awake()
    {
        this.floorMask = LayerMask.GetMask("Floor");
        this.anim = this.GetComponent<Animator>();
        this.playerRigidbody = this.GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        this.Move(h, v);
        this.Turning();
        this.Animating(h, v);
    }

    private void Move(float h, float v)
    {
        this.movement.Set(h, 0f, v);
        this.movement = movement.normalized * this.Speed * Time.deltaTime;

        this.playerRigidbody.MovePosition(transform.position + this.movement);
    }

    private void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;

        if(Physics.Raycast(camRay, out floorHit, this.camRayLength, this.floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            this.playerRigidbody.MoveRotation(newRotation);
        }
    }

    private void Animating(float h, float v)
    {
        bool walking = h != 0f || v != 0f;
        this.anim.SetBool("IsWalking", walking);
        Debug.Log(string.Format("IsWalking: {0}", walking));
    }
}
