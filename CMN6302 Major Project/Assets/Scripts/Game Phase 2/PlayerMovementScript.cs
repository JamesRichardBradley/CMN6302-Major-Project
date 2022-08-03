using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovementScript : MonoBehaviour
{
    private float moveSpeed = 0.3f;
    private Vector3 moveDirection, rotateDirection;
    private new Camera camera;
    public int score;

    UiManagment userInterface;

    private void Start()
    {
        camera = GetComponent<Camera>();
        userInterface = GameObject.Find("SolarSystemManagement").GetComponent<UiManagment>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

        userInterface.scoreValue = score;

        if (score >= 8)
        {
            SceneManager.LoadScene(3);
        }
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(moveDirection) * moveSpeed * Time.deltaTime);
    }
}
