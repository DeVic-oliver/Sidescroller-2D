public class FallAnimation : AnimationsBase, IFireAnimation
{
    private void Update()
    {
        WatchFallAnimation();
    }
    private void WatchFallAnimation()
    {
        float playerRigidbodyVelocity = _playerMoviment.GetPlayerRigidbodyVerticalVelocity();
        bool isPlayerFalling = _playerMoviment.CheckIfIsPlayerFalling();
        if (isPlayerFalling && playerRigidbodyVelocity < 0)
        {
            TriggerAnimation();
        }
    }
    public void TriggerAnimation()
    {
        _animator.SetTrigger("Fall");
    }
}
