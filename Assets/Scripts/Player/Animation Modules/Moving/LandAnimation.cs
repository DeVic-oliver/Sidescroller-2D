using UnityEngine;
public class LandAnimation : AnimationsBase, IToggleAnimation, IPlayerOnGround
{
    private bool hasLanded = false;
    private void Update()
    {
        WatchIfPlayerLands();
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground")) //could use a interface called landable
        {
            _animator.SetBool("HasLanded", true);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground")) //could use a interface called landable
        {
            _animator.SetBool("HasLanded", false);
        }
    }
}
