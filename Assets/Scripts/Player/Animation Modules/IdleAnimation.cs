using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAnimation : AnimationsBase, IToggleAnimation
{
    private void Update()
    {
        WatchIdleAnimation();
    }
    private void WatchIdleAnimation()
    {
        bool isPlayerMoving = _playerActions.CheckIfPlayerIsMoving();
        bool isPlayerOnGround = _playerActions.CheckIfPlayerIsOnGround();
        if (!isPlayerMoving && isPlayerOnGround)
        {
            EnableAnimation();
        }
        else
        {
            DisableAnimation();
        }
    }
    public void DisableAnimation()
    {
        _animator.SetBool("IsIdle", false);
    }

    public void EnableAnimation()
    {
        _animator.SetBool("IsIdle", true);
    }
}
