using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAnimation : AnimationsBase, IToggleAnimation
{
    private PlayerMovement _playerMoviment;
    private void Start()
    {
        _playerMoviment = GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        WatchMoveAnimation();
    }
    private void WatchMoveAnimation()
    {
        if (_playerMoviment.IsPlayerMoving())
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
        TheAnimator.SetBool( "IsMoving", false );
    }

    public void EnableAnimation()
    {
        TheAnimator.SetBool("IsMoving", true);
    }
}
