using UnityEngine;

namespace TDS.Architecture.States
{
    public class GameOverState : AppState
    {
        #region Public methods

        public override void Enter()
        {
            Debug.Log($"'{nameof(GameOverState)}' was entered.'");

            StateMachine.Enter<LoadGameState>();
        }

        public override void Exit() { }

        #endregion
    }
}