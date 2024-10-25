using UnityEngine;

namespace TDS.Game.Player
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimator : AnimatorMonoBehaviour
    {
        #region Variables

        private readonly int _isDead = Animator.StringToHash("IsDead");

        private readonly int _moveSpeed = Animator.StringToHash("MoveSpeed");
        private readonly int _shot = Animator.StringToHash("Shot");

        #endregion

        #region Public methods

        public void SetIsDead()
        {
            Animator.SetTrigger(_isDead);
        }

        public void SetMovement(float value)
        {
            Animator.SetFloat(_moveSpeed, value);
        }

        public void SetShot()
        {
            Animator.SetTrigger(_shot);
        }

        #endregion
    }
}