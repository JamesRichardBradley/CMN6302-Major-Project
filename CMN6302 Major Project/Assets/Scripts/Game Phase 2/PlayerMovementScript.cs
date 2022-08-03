using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovementScript : MonoBehaviour
{
    private float moveSpeed = 0.2f;
    private Vector3 moveDirection;
    private new Camera camera;
    private Rigidbody characterBody;
    public int score;

    UiManagment userInterface;

    private void Start()
    {
        camera = GetComponent<Camera>();
        userInterface = GameObject.Find("SolarSystemManagement").GetComponent<UiManagment>();
        characterBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //  Sets the players movement direction dependent on the input from Left Control stick, or WASD keys
        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        
        //  Gets the current number of collected anomalies, and Loads the Win Scenario if required number collected
        userInterface.scoreValue = score;
        if (score >= 8)
        {
            SceneManager.LoadScene(3);
        }
    }

    private void FixedUpdate()
    {
        //  Changes the characters position dependent on direction and movement speed
        characterBody.MovePosition(characterBody.position + transform.TransformDirection(moveDirection) * moveSpeed * Time.deltaTime);
    }
}
