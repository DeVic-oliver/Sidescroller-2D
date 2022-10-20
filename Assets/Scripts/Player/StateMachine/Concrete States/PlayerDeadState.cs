using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : PlayerStateBase, IPlayerState
{
    public void OnStateEnter(PlayerStateMachine stateMachineManager)
    {
        _stateMachine = stateMachineManager;
        stateMachineManager.ThePlayerStatus.KillPlayer();
        _stateMachine.AnimationManager.EnableDeathAnimation();
        _stateMachine.GetComponent<PlayerMovement>().enabled = false;
    }

    public void OnStateUpdate(PlayerStateMachine stateMachineManager)
    {
        WatchPlayerStatus();
    }

    protected override void WatchPlayerStatus()
    {
        bool isPlayerAlive = _stateMachine.ThePlayerStatus.GetPlayerAliveStatus();
        if (isPlayerAlive || Input.anyKeyDown)
        {
            _stateMachine.SwitchState(_stateMachine.AliveState);
        }
    }
}
