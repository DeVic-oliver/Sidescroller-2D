using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAnimation : AnimationsBase, IToggleAnimation
{
    private void Update()
    {
        WatchMoveAnimation();
    }
    private void WatchMoveAnimation()
    {
        if (_playerMoviment.CheckIfIsPlayerMoving())
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
        _animator.SetBool( "IsMoving", false );
    }

    public void EnableAnimation()
    {
        _animator.SetBool("IsMoving", true);
    }
}
