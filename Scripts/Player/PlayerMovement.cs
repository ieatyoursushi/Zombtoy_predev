using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f; //how fast is the player
    private Animator anim; // reference the animator controller
    private Vector3 movement; //store movement we want to apply to player
    private Rigidbody playerRigidbody; //reference to rigidbody component
    private int floorMask;
    private float camRayLength = 100f;
    public bool walking;
    //fires as soon as the game "wakes up" or starts no matter if the script is enabled or not
	//Can be declared as public and the components dragged in
	void Awake(){
		//set up references
		playerRigidbody = GetComponent<Rigidbody>(); //Set the variable playerRigidbody variable to be the rigidbody of the player
        anim = GetComponent<Animator>(); //sets anim to be the animatorcontroller on the player
        floorMask = LayerMask.GetMask("Floor");
	}
    //Fires every physics update
	void FixedUpdate(){
		//Show input manager to explain this
		float h = Input.GetAxisRaw ("Horizontal"); //Get raw input so there is no acceleration, he just moves. We are getting the input from the buttons mapped to be horizontal input
		float v = Input.GetAxisRaw ("Vertical");
		//call the functions
		Move (h, v);
        Turning ();
        Animating(h, v);
	}
    
    void Turning(){
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;
        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            playerRigidbody.MoveRotation(newRotation);
            Debug.DrawLine(floorHit.point, transform.position);            
        }
	}

    void Move(float h, float v){
		movement.Set (h, 0f, v); //sets the movement vector
		//normalize the diagonal vector so that it's length is not greater than the length of the vector in either direction (so they don't get a speed boost by goind diaganol)
		movement = movement.normalized * speed * Time.deltaTime; //multiply by speed and time.delta time so it moves a distance every second not every fixed update (.02 of a second)
		playerRigidbody.MovePosition(transform.position + movement); //moves player from current position to new postion
	}

    //create an animate function
	void Animating(float h, float v){
        walking = h != 0f || v != 0f; //sets walking to true if h or v is not zero
        anim.SetBool("IsWalking", walking); // set the animater controller condition of iswalking to true or false
	}
}
