public class JumpAnimation : AnimationsBase, IFireAnimation
{
    private void Update()
    {
        WatchJumpAnimation();
    }
    private void WatchJumpAnimation()
    {
        float playerRigidbodyVelocity = _playerMoviment.GetPlayerRigidbodyVerticalVelocity();
        bool isPlayerJumping = _playerMoviment.CheckIfPlayerIsJumping();
        if (isPlayerJumping && playerRigidbodyVelocity > 0)
        {
            TriggerAnimation();
        }
    }
    public void TriggerAnimation()
    {
        _animator.SetTrigger("Jump");
    }
    
}
