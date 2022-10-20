using UnityEngine;

public class PlayerAliveState : PlayerStateBase, IPlayerState
{
    public void OnStateEnter(PlayerStateMachine stateMachineManager)
    {
        _stateMachine = stateMachineManager;
        CheckIfPlayerIsDead();
    }
    private void CheckIfPlayerIsDead()
    {
        if (!_stateMachine.ThePlayerStatus.GetPlayerAliveStatus())
        {
            _stateMachine.ThePlayerStatus.ResurrectPlayer();
        }
    }

    public void OnStateUpdate(PlayerStateMachine stateMachineManager)
    {
        WatchPlayerStatus();
    }

    protected override void WatchPlayerStatus()
    {
        bool isPlayerAlive = _stateMachine.ThePlayerStatus.GetPlayerAliveStatus();
        if (!isPlayerAlive)
        {
            _stateMachine.SwitchState(_stateMachine.DeadState);
        }
    }
}
