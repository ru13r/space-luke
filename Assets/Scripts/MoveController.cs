using UnityEngine;

public class Movement : MonoBehaviour
{
    // TODO Add acceleration to movement
    // TODO add particle to engines dependent on the movement
    // TODO add ship animation dependent on the movement
    public float movementSpeed;

    private Screen _screen;

    private void Start()
    { 
        _screen = GameObject.Find("GameManager").GetComponent<Screen>();
    }

    private void Update()
    {
        var verticalInput = Input.GetAxis("Vertical");
        var horizontalInput = Input.GetAxis("Horizontal");
        var movementVector = (Vector3.up * verticalInput + Vector3.right * horizontalInput).normalized;
        transform.Translate(movementSpeed * Time.deltaTime * movementVector);
        transform.position = _screen.MovementClamp(transform.position);
    }


}
