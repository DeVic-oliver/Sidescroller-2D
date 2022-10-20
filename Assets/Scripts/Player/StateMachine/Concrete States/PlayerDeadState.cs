using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : PlayerStateBase, IPlayerState
{
    public void OnStateEnter(PlayerStateMachine stateMachineManager)
    {
        _stateMachine = stateMachineManager;
        stateMachineManager.ThePlayerStatus.KillPlayer();
        Debug.Log("The player is Dead");
    }

    public void OnStateUpdate(PlayerStateMachine stateMachineManager)
    {
        WatchPlayerStatus();
    }

    protected override void WatchPlayerStatus()
    {
        bool isPlayerAlive = _stateMachine.ThePlayerStatus.GetPlayerAliveStatus();
        if (isPlayerAlive)
        {
            _stateMachine.SwitchState(_stateMachine.AliveState);
        }
    }
}
