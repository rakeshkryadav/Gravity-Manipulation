using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator playerAnimation;
	private Rigidbody player;
	[SerializeField] float playerSpeed;
	[SerializeField] float playerTurnSpeed;
	private Vector3 jump;
	[SerializeField] float jumpForce;
	[SerializeField] GameObject hologram;
	private bool running = false;
	private Vector3 gravityOrientation = Vector3.down;
    // Start is called before the first frame update
    void Start()
    {
		// Initializing Components.
        playerAnimation = gameObject.GetComponentInChildren<Animator>();
		player = gameObject.GetComponent<Rigidbody>();

		// Set the gravity to default.
		Physics.gravity = Vector3.down * 9.81f;

		// Default Jump Height.
		jump = new Vector3(0.0f, 2.0f, 0.0f);
		hologram.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
		Hologram();
		MovePlayer();
		PlayerAnimation();
    }

	void MovePlayer(){
		// Movement of player using WASD keys.
		if(Input.GetKey(KeyCode.W)){
			transform.Translate(0f, 0f, playerSpeed * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.A)){
			transform.Rotate(-Vector3.up * playerSpeed * playerTurnSpeed * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.D)){
			transform.Rotate(Vector3.up * playerSpeed * playerTurnSpeed * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.S)){
			transform.Translate(0f, 0f, -playerSpeed * Time.deltaTime);
		}

		// Jump using Space key.
		if(Input.GetKeyDown(KeyCode.Space)){
			player.AddRelativeForce(jump * jumpForce, ForceMode.Impulse);
		}
	}

	void PlayerAnimation(){
		// Trigger the animation with respective keys.
		if(Input.GetKeyDown(KeyCode.W)){
            playerAnimation.SetTrigger("Run");
			playerAnimation.ResetTrigger("Idle");
			running = true;
        }
		if(Input.GetKeyUp(KeyCode.W)){
            playerAnimation.SetTrigger("Idle");
			playerAnimation.ResetTrigger("Run");
			running = false;
        }
		if(Input.GetKeyDown(KeyCode.S)){
            playerAnimation.SetTrigger("Back");
			playerAnimation.ResetTrigger("Idle");
			running = true;
        }
		if(Input.GetKeyUp(KeyCode.S)){
            playerAnimation.SetTrigger("Idle");
			playerAnimation.ResetTrigger("Back");
			running = false;
        }
		if(Input.GetKeyDown(KeyCode.Space)){
			playerAnimation.SetTrigger("Jump");
			playerAnimation.ResetTrigger("Idle");
		}
		if(Input.GetKeyUp(KeyCode.Space)){
			// If jump was pressed while running then execute the run condition else execute the else condition.
			if(running){
				playerAnimation.SetTrigger("Run");
				playerAnimation.ResetTrigger("Jump");
			}
			else{
				playerAnimation.SetTrigger("Idle");
				playerAnimation.ResetTrigger("Jump");
			}
		}
		// Jump while running.
		if(Input.GetKeyDown(KeyCode.Space) && Input.GetKeyDown(KeyCode.W)){
			playerAnimation.SetTrigger("Jump");
			playerAnimation.ResetTrigger("Run");
		}
	}

	void Hologram(){
		// Set the hologram direction using the arrow keys.

		// Set gravity in the Forward direction.
		if(Input.GetKeyDown(KeyCode.UpArrow)){
			// Active the hologram in the pointed direction.
			hologram.SetActive(true);
			hologram.transform.Rotate(-Vector3.right * 90f);
		}
		if(Input.GetKeyUp(KeyCode.UpArrow)){
			// Inactive the hologram if key is released.
			hologram.SetActive(false);
			// Set hologram's rotation of initial.
			hologram.transform.Rotate(Vector3.right * 90f);

			// Initialize the driction for gravity.
			gravityOrientation = Vector3.forward;
			// Update the gravity direction.
			GravityManipulation();
			// Update the Player body direction in respect to the gravity.
			transform.Rotate(-Vector3.right * 90f);
		}

		// Set gravity in the Upward direction.
		if(Input.GetKeyDown(KeyCode.DownArrow)){
			// Active the hologram in the pointed direction.
			hologram.SetActive(true);
			hologram.transform.Rotate(Vector3.right * 180f);
		}
		if(Input.GetKeyUp(KeyCode.DownArrow)){
			// Inactive the hologram if key is released.
			hologram.SetActive(false);
			// Set hologram's rotation of initial.
			hologram.transform.Rotate(-Vector3.right * 180f);

			// Initialize the driction for gravity.
			gravityOrientation = Vector3.up;
			// Update the gravity direction.
			GravityManipulation();
			// Update the Player body direction in respect to the gravity.
			transform.Rotate(Vector3.right * 180f);
		}

		// Set gravity in the Left direction.
		if(Input.GetKeyDown(KeyCode.LeftArrow)){
			// Active the hologram in the pointed direction.
			hologram.SetActive(true);
			// Update the Player body direction in respect to the gravity.
			hologram.transform.Rotate(-Vector3.forward * 90f);
		}
		if(Input.GetKeyUp(KeyCode.LeftArrow)){
			// Inactive the hologram if key is released.
			hologram.SetActive(false);
			// Set hologram's rotation of initial.
			hologram.transform.Rotate(Vector3.forward * 90f);

			// Initialize the driction for gravity.
			gravityOrientation = Vector3.left;
			// Update the gravity direction.
			GravityManipulation();
			// Update the Player body direction in respect to the gravity.
			transform.Rotate(-Vector3.forward * 90f);
		}
		
		// Set gravity in the Right direction.
		if(Input.GetKeyDown(KeyCode.RightArrow)){
			// Active the hologram in the pointed direction.
			hologram.SetActive(true);
			hologram.transform.Rotate(Vector3.forward * 90f);
		}
		if(Input.GetKeyUp(KeyCode.RightArrow)){
			// Inactive the hologram if key is released.
			hologram.SetActive(false);
			// Set hologram's rotation of initial.
			hologram.transform.Rotate(-Vector3.forward * 90f);

			// Initialize the driction for gravity.
			gravityOrientation = Vector3.right;
			// Update the gravity direction.
			GravityManipulation();
			// Update the Player body direction in respect to the gravity.
			transform.Rotate(Vector3.forward * 90f);
		}
	}

	void GravityManipulation(){
		// Get the gravity's new direction. 
		gravityOrientation = transform.TransformDirection(gravityOrientation);
		// Apply the gravity.
		Physics.gravity = gravityOrientation * 9.81f;
	}
}
