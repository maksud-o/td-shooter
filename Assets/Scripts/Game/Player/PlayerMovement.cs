using UnityEngine;
using UnityEngine.InputSystem;

namespace TDS.Game.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        #region Variables

        [SerializeField] private InputActionReference _moveAction;
        [SerializeField] private InputActionReference _lookAction;

        [SerializeField] private PlayerAnimator _playerAnimator;
        [SerializeField] private float _movementSpeed = 10f;

        private Camera _camera;
        private Rigidbody2D _rb;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            ProcessMovement(_moveAction.action.ReadValue<Vector2>());
            ProcessLook(_lookAction.action.ReadValue<Vector2>());
        }

        private void OnEnable()
        {
            _rb.simulated = true;
        }

        private void OnDisable()
        {
            _rb.simulated = false;
        }

        #endregion

        #region Private methods

        private void ProcessLook(Vector2 value)
        {
            Vector3 mouseWorldPos = _camera.ScreenToWorldPoint(value);
            Vector2 direction = (mouseWorldPos - transform.position).normalized;
            transform.up = direction;
        }

        private void ProcessMovement(Vector2 value)
        {
            Vector2 movement = value.normalized * (_movementSpeed * Time.deltaTime);
            transform.Translate(movement, Space.World);
            _playerAnimator.SetMovement(value.magnitude);
        }

        #endregion
    }
}