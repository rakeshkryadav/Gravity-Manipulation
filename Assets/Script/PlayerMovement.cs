using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator playerAnimation;
	private Rigidbody player;
	[SerializeField] float playerSpeed;
	[SerializeField] float playerTurnSpeed;
	private Vector3 jump;
	[SerializeField] float jumpForce;
	private bool running = false;
    // Start is called before the first frame update
    void Start()
    {
		// Initializing Components.
        playerAnimation = gameObject.GetComponent<Animator>();
		player = gameObject.GetComponent<Rigidbody>();
		jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
		MovePlayer();
		PlayerAnimation();
    }

	void MovePlayer(){
		if(Input.GetKey(KeyCode.W)){
			transform.Translate(0f, 0f, playerSpeed * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.A)){
			transform.Rotate(-transform.up * playerSpeed * playerTurnSpeed * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.D)){
			transform.Rotate(transform.up * playerSpeed * playerTurnSpeed * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.S)){
			transform.Translate(0f, 0f, -playerSpeed * Time.deltaTime);
		}
		if(Input.GetKeyDown(KeyCode.Space)){
			player.AddRelativeForce(jump * jumpForce, ForceMode.Impulse);
		}
	}

	void PlayerAnimation(){
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
		if(Input.GetKeyDown(KeyCode.Space)){
			playerAnimation.SetTrigger("Jump");
			playerAnimation.ResetTrigger("Idle");
		}
		if(Input.GetKeyUp(KeyCode.Space)){
			if(running){
				playerAnimation.SetTrigger("Run");
				playerAnimation.ResetTrigger("Jump");
			}
			else{
				playerAnimation.SetTrigger("Idle");
				playerAnimation.ResetTrigger("Jump");
			}
		}
		if(Input.GetKeyDown(KeyCode.Space) && Input.GetKeyDown(KeyCode.W)){
			playerAnimation.SetTrigger("Jump");
			playerAnimation.ResetTrigger("Run");
		}
	}
}
