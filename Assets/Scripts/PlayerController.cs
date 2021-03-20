using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class PlayerController : MonoBehaviour
{
    [SerializeField] float rotationPower = 3f;
    [SerializeField] float walkSpeed = 1f;
    [SerializeField] float sprintSpeed = 3f;
    [SerializeField] Transform followTransform;
    [SerializeField] Transform cameraTransform;
    [SerializeField] Animator animator;
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] CanvasItemDisplay canvasHandler;

    Vector2 moveInput;
    Vector2 lookInput;
    float sprintInput;
    bool freeze;
    public bool slowed;

    public Inventory inventory;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        freeze = false;
        slowed = false;
        inventory = new Inventory(15f);
    }

    private void Update()
    {
        LookingAtItem();
    }

    private void FixedUpdate()
    {
        if(!freeze)
        {
            PlayerMovement();
        }
    }

    private void PlayerMovement()
    {
        moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        lookInput = new Vector2(Input.GetAxis("Mouse X"), -Input.GetAxis("Mouse Y"));
        if(!slowed)
        {
            sprintInput = Input.GetAxis("Sprint");
        }

        UpdateFollowTargetRotation();

        float speed = 0;
         speed = Mathf.Lerp(walkSpeed, sprintSpeed, sprintInput);
        
        Vector3 movement = (transform.forward * moveInput.y * speed) + (transform.right * moveInput.x * speed);
        rigidbody.velocity = new Vector3(movement.x, rigidbody.velocity.y, movement.z);

        animator.SetFloat("MovementSpeed", moveInput.y * (speed / walkSpeed));

        //only rotate the player when moving, allows user to look at the player when idle
        if (moveInput.magnitude > 0.01f)
        {
            //Set the player rotation based on the look transform
            transform.rotation = Quaternion.Euler(0, followTransform.eulerAngles.y, 0);
            //reset the y rotation of the look transform
            followTransform.localEulerAngles = new Vector3(followTransform.localEulerAngles.x, 0, 0);
        }
    }
    private void UpdateFollowTargetRotation()
    {
        //Update follow target rotation
        followTransform.rotation *= Quaternion.AngleAxis(lookInput.x * rotationPower, Vector3.up);
        followTransform.rotation *= Quaternion.AngleAxis(lookInput.y * rotationPower, Vector3.right);

        var angles = followTransform.localEulerAngles;
        angles.z = 0;
        var angle = angles.x;

        //Clamp the Up/Down rotation
        if (angle > 180 && angle < 340)
        {
            angles.x = 340;
        }
        else if (angle < 180 && angle > 40)
        {
            angles.x = 40;
        }
        followTransform.localEulerAngles = angles;
    }


    private bool LookingAtItem()
    {

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 3))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            if(hit.transform.tag.Equals("Collectable"))
            {
                Debug.Log("Looking at Pickable object");

                canvasHandler.setItemName(hit.transform.GetComponent<Item>().GetItemName());

                if(Input.GetKeyDown(KeyCode.E))
                {
                    if(inventory.TryToAddItem(hit.transform.GetComponent<Item>()))
                    {
                        StartCoroutine(FreezePlayer(1));
                        animator.SetTrigger("PickUp");
                        Destroy(hit.transform.gameObject);
                        Debug.Log("Object Picked Up");

                        Debug.Log("Inventory size : " + inventory.GetInventorySize());
                    }

                }
                return true;
            }
            else
            {
                canvasHandler.setItemName("");

                Debug.Log("Scouting");
                return false;
            }

        }

        return false;
    }

    private void PickUpItem()
    {
        if(LookingAtItem())
        {

        }
    }

    private IEnumerator FreezePlayer(float FreezeTimeInSeconds)
    {
        freeze = true;
        yield return new WaitForSeconds(FreezeTimeInSeconds);
        freeze = false;
    }
}
