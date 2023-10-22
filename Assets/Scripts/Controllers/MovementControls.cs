using UnityEngine;

namespace Controllers
{
    public class MovementControls : MonoBehaviour
    {
        // TODO add particle to engines dependent on the movement
        // TODO add ship animation dependent on the movement
        [SerializeField] private float movementSpeed;
        private Vector3 _extents;

        private void Awake()
        {
            _extents = gameObject.GetComponent<Collider2D>().bounds.extents;
        }

        private void Update()
        {
            var verticalInput = Input.GetAxis("Vertical");
            var horizontalInput = Input.GetAxis("Horizontal");

            var movementVector = (Vector3.up * verticalInput + Vector3.right * horizontalInput);
            if (movementVector.magnitude >= 1) movementVector = movementVector.normalized;
            var translation = movementSpeed * Time.deltaTime * movementVector;
            if (GameScreen.IsOffScreen(transform.position + translation, -_extents)) return;
            transform.Translate(translation);
        }
    }
}
