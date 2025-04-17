using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float lookSpeed = 2f;
    public Transform cameraTransform;

    private Rigidbody rb;
    private float xRotation = 0f;

    private Rigidbody heldItemRb;
    private Collider heldItemCollider;
    private bool isHolding = false;

    public float holdDistance = 1.5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeed;

        transform.Rotate(Vector3.up * mouseX);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        if (Input.GetKeyUp(KeyCode.Mouse0) && isHolding)
        {
            DropItem();
        }
    }

    private void FixedUpdate()
    {
        float moveX = -Input.GetAxis("Horizontal");
        float moveZ = -Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);

        if (isHolding && heldItemRb != null)
        {
            Vector3 targetPos = cameraTransform.position + cameraTransform.forward * holdDistance;
            heldItemRb.MovePosition(targetPos);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !isHolding && other.CompareTag("Inventory"))
        {
            PickupItem(other);
        }
    }

    private void PickupItem(Collider other)
    {
        heldItemRb = other.attachedRigidbody;
        heldItemCollider = other;

        if (heldItemRb == null || heldItemCollider == null) return;

        heldItemRb.useGravity = false;
        heldItemRb.isKinematic = false;

        Collider playerCollider = GetComponent<Collider>();
        if (playerCollider != null)
        {
            //Physics.IgnoreCollision(playerCollider, heldItemCollider, true);
        }

        isHolding = true;
    }

    private void DropItem()
    {
        if (heldItemRb == null || heldItemCollider == null) return;

        heldItemRb.useGravity = true;
        heldItemRb.isKinematic = false;

        Collider playerCollider = GetComponent<Collider>();
        if (playerCollider != null)
        {
            //Physics.IgnoreCollision(playerCollider, heldItemCollider, false);
        }

        heldItemRb = null;
        heldItemCollider = null;
        isHolding = false;
    }
}





/*using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 0.2f;
    public float lookSpeed = 2f;

    public Transform cameraTransform;
    private Rigidbody rb;
    private float xRotation = 0f;

    private Rigidbody rbItem;

    private Collider playerCollider;
    private Collider itemCollider;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); //Get Rigidbody component from Player
        playerCollider = GetComponent<Collider>(); // сохраняем коллайдер игрока
    }


    void FixedUpdate() //FixedUpdate is better for synchronization physics and movement
    {
        // Player movement
        float moveX = -Input.GetAxis("Horizontal");
        float moveZ = -Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);
    }

    void Update()
    {

        // Get mouse movement
        float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeed;

        // Rotate player left/right
        transform.Rotate(Vector3.up * mouseX);

        // Rotate player up/down
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }




        private void OnTriggerStay(Collider other)
        {
            if(other.CompareTag("Inventory"))
            {
                rbItem = other.GetComponent<Rigidbody>();

                if (Input.GetKey(KeyCode.Mouse0))
                {
                    //other.transform.position = this.gameObject.transform.position;

                    float moveX = -Input.GetAxis("Horizontal");
                    float moveZ = -Input.GetAxis("Vertical");

                    Vector3 move = transform.right * moveX + transform.forward * moveZ;
                    rbItem.MovePosition(rbItem.position + move * speed * Time.fixedDeltaTime);

                    // Get mouse movement
                    float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
                    // Rotate left/right
                    other.transform.Rotate(Vector3.up * mouseX);

                }
            }
        }
    }
}*/

