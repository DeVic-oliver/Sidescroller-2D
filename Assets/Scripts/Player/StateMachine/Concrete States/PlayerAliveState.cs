using UnityEngine;

public class PlayerAliveState : PlayerStateBase, IPlayerState
{
    public void OnStateEnter(PlayerStateMachine stateMachineManager)
    {
        _stateMachine = stateMachineManager;
        _stateMachine.ThePlayerStatus.ResurrectPlayer();
        //_stateMachine.AnimationManager.EnableIdleAnimation();
        _stateMachine.GetComponent<PlayerMovement>().enabled = true;
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
