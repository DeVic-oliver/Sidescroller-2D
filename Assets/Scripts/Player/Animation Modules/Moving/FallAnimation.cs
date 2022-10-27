public class FallAnimation : AnimationsBase, IToggleAnimation
{
    private void Update()
    {
        WatchFallAnimation();
    }
    private void WatchFallAnimation()
    {
        bool isPlayerFalling = _playerActions.CheckIfPlayerIsFalling();
        if (isPlayerFalling)
        {
            EnableAnimation();
        }
        else
        {
            DisableAnimation();
        }
    }
    public void EnableAnimation()
    {
        _animator.SetBool("IsFalling", true);
    }

    public void DisableAnimation()
    {
        _animator.SetBool("IsFalling", false);
    }
}
