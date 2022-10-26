using UnityEngine;

public abstract class AnimationsBase : MonoBehaviour
{
    protected Animator _animator;
    protected PlayerMovement _playerMoviment;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _playerMoviment = GetComponent<PlayerMovement>();
    }
}
