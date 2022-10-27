using UnityEngine;
public class LandAnimation : AnimationsBase, IToggleAnimation, IPlayerOnGround
{
    private bool hasLanded = false;
    private void Update()
    {
        WatchIfPlayerLands();
        CheckIfPlayerLands();
    }
    private void WatchIfPlayerLands()
    {
        bool isPlayerLanding = _playerActions.CheckIfPlayerIsLanding();
        if (isPlayerLanding && !hasLanded)
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
        _animator.SetBool("IsLanding", true);
        SetPlayerOnGround(true);
    }
    public void DisableAnimation()
    {
        _animator.SetBool("IsLanding", false);
    }
    public void SetPlayerOnGround(bool value)
    {
        _animator.SetBool("IsGrounded", value);
    }
    private void CheckIfPlayerLands()
    {
        bool isPlayerLandingEnd = _animator.GetCurrentAnimatorStateInfo(0).IsName("ANIM_Astronaut_Jump_Landing");
        if (isPlayerLandingEnd)
        {
            hasLanded = true;
            _animator.SetBool("HasLanded", hasLanded);
            DisableAnimation();
        }
        else
        {
            hasLanded = false;
            _animator.SetBool("HasLanded", hasLanded);
        }
    }
}
