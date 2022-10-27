using UnityEngine;
[RequireComponent(typeof (PlayerActions))]
public class MoveAnimation : AnimationsBase, IToggleAnimation
{
    private void Update()
    {
        WatchMoveAnimation();
    }
    private void WatchMoveAnimation()
    {
        bool isPlayerMoving = _playerActions.CheckIfPlayerIsMoving();
        if (isPlayerMoving)
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
