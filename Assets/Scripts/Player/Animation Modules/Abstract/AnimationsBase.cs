using UnityEngine;

public abstract class AnimationsBase : MonoBehaviour
{
    public Animator TheAnimator;
    // Start is called before the first frame update
    void Start()
    {
        TheAnimator = GetComponent<Animator>();    
    }
}
