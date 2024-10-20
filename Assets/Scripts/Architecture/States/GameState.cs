using UnityEngine;

namespace TDS.Architecture.States
{
    public class GameState : AppState
    {
        #region Public methods

        public override void Enter()
        {
            Debug.Log($"'{nameof(GameState)}' was entered.");
        }

        public override void Exit() { }

        #endregion
    }
}