using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }
    public void EnableAnimation(string animationID, bool value)
    {
        _animator.SetBool(animationID, value);
    }
    public void DisableAnimation(string animationID, bool value)
    {
        _animator.SetBool(animationID, value);
    }
    public void TriggerAnimation(string animationID)
    {
        _animator.SetTrigger(animationID);
    }
    public void EnableIdleAnimation()
    {
        _animator.SetBool("IsAlive", true);
    }
    public void EnableDeathAnimation()
    {
        _animator.SetBool("IsAlive", false);
    }
    public void EnableRunAnimation()
    {
        _animator.SetBool("IsMoving", true);
    }
    public void DisableRunAnimation()
    {
        _animator.SetBool("IsMoving", false);
    }
    public void TriggerJumpAnimation()
    {
        _animator.SetTrigger("Jump");
    }
    public void TriggerFallAnimation()
    {
        _animator.SetTrigger("Fall");
    }
    public void TriggerLandAnimation()
    {
        _animator.SetTrigger("Land");
    }
}
