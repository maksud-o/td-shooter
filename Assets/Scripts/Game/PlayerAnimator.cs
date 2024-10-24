using UnityEngine;

namespace TDS.Game
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimator : MonoBehaviour
    {
        #region Variables

        private readonly int _moveSpeed = Animator.StringToHash("MoveSpeed");
        private readonly int _shot = Animator.StringToHash("Shot");

        private Animator _animator;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        #endregion

        #region Public methods

        public void SetMovement(float value)
        {
            _animator.SetFloat(_moveSpeed, value);
        }

        public void SetShot()
        {
            _animator.SetTrigger(_shot);
        }

        #endregion
    }
}