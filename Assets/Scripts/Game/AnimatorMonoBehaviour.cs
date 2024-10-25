using UnityEngine;

namespace TDS.Game
{
    [RequireComponent(typeof(Animator))]
    public abstract class AnimatorMonoBehaviour : MonoBehaviour
    {
        #region Variables

        protected Animator Animator;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            Animator = GetComponent<Animator>();
        }

        #endregion
    }
}