public class LandAnimation : AnimationsBase, IFireAnimation
{
    private void Update()
    {
        WatchIfPlayerLands();
    }
    private void WatchIfPlayerLands()
    {
        bool hasPlayerLanded = _playerMoviment.CheckIfPlayerLands();
        if (hasPlayerLanded)
        {
            TriggerAnimation();
        }
    }
    public void TriggerAnimation()
    {
        _animator.SetTrigger("Land");
    }
}
