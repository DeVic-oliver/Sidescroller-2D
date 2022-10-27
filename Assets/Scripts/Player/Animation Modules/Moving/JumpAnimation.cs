public class JumpAnimation : AnimationsBase, IToggleAnimation, IPlayerOnGround
{
    private void Update()
    {
        WatchJumpAnimation();
    }
    private void WatchJumpAnimation()
    {
        bool isPlayerJumping = _playerActions.CheckIfPlayerIsJumping();
        if (isPlayerJumping)
        {
            EnableAnimation();
        }else
        {
            DisableAnimation();
        }
    }
    public void EnableAnimation()
    {
        _animator.SetBool("IsJumping", true);
        SetPlayerOnGround(false);
    }
    public void DisableAnimation()
    {
        _animator.SetBool("IsJumping", false);
    }
    public void SetPlayerOnGround(bool value)
    {
        _animator.SetBool("IsGrounded", value);
    }
}
