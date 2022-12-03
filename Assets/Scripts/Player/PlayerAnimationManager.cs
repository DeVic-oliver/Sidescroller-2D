using UnityEngine;
namespace Assets.Scripts.PlayerComponent
{
    public class PlayerAnimationManager
{
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private string moveAnimID = "IsMoving";
    private string jumpAnimID = "IsJumping";
    private string landAnimID = "Landing";
    private string fallAnimID = "IsFalling";
    private string idleAnimID = "IsIdle";
    private string aliveAnimID = "IsAlive";


    public PlayerAnimationManager(Animator animator, Rigidbody2D playerRigidbody)
    {
        _animator = animator;
        _rigidbody = playerRigidbody;
    }
    public void WatchMovingAnimation()
    {
        if (_rigidbody.velocity.x != Vector2.zero.x)
        {
            _animator.SetBool(idleAnimID, false);
            _animator.SetBool(moveAnimID, true);
        }
        else
        {
            _animator.SetBool(moveAnimID, false);
            _animator.SetBool(idleAnimID, true);
        }
    }
    public void WatchingAirAnimation()
    {
        if (_rigidbody.velocity.y > Vector2.zero.y)
        {
            _animator.SetBool(idleAnimID, false);
            _animator.SetBool(idleAnimID, false);
            _animator.SetBool(moveAnimID, false);
            _animator.SetBool(fallAnimID, false);
            _animator.SetBool(jumpAnimID, true);
        }
        else if(_rigidbody.velocity.y < Vector2.zero.y)
        {
            _animator.SetBool(idleAnimID, false);
            _animator.SetBool(moveAnimID, false);
            _animator.SetBool(jumpAnimID, false);
            _animator.SetBool(fallAnimID, true);
        }
        else
        {
            _animator.SetBool(jumpAnimID, false);
            _animator.SetBool(fallAnimID, false);
            _animator.SetTrigger(landAnimID);
        }
    }
    public void WatchLifeAnimation(bool aliveValue)
    {
        _animator.SetBool(aliveAnimID, aliveValue);
    }
}
}
