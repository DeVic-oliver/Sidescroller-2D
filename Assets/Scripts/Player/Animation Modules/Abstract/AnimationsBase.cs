using UnityEngine;

public abstract class AnimationsBase : MonoBehaviour
{
    protected Animator _animator;
    protected PlayerActions _playerActions;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _playerActions = GetComponent<PlayerActions>();
    }
}
