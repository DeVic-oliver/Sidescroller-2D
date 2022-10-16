using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ButtonAnimationManager : MonoBehaviour
{
    [Header("Animation Parameters")]
    [SerializeField] private float duration;
    [SerializeField] private Ease animationEase;
    [SerializeField] private float buttonScale;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = Vector2.zero;
        GrowButtonsInScale();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GrowButtonsInScale()
    {
        transform.DOScale(buttonScale, duration).SetDelay(1.2f).SetEase(animationEase);
    }
}
