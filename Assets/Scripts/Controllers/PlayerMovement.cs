using UnityEngine;

namespace Controllers
{
    public class PlayerMovement : MonoBehaviour
    {
        // TODO Add acceleration to movement
        // TODO add particle to engines dependent on the movement
        // TODO add ship animation dependent on the movement
        public float movementSpeed;

        private ScreenManager _screenManager;
        private (float, float) _dimensions;

        private void Start()
        { 
            _screenManager = GameObject.Find("GameManager").GetComponent<ScreenManager>();
            _dimensions = GetComponent<Ship>().GetDimensions();
        }

        private void Update()
        {
            var verticalInput = Input.GetAxis("Vertical");
            var horizontalInput = Input.GetAxis("Horizontal");
            var movementVector = (Vector3.up * verticalInput + Vector3.right * horizontalInput).normalized;
            transform.Translate(movementSpeed * Time.deltaTime * movementVector);
            transform.position = _screenManager.MovementClamp(transform.position, _dimensions);
        }


    }
}
