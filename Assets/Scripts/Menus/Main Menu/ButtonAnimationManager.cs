using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class ButtonAnimationManager : MonoBehaviour
{
    #region ANIMATION SETUP
    [Header("Buttons Animation Setup")]
    [Space(30)]
    [Header("Button Data ScriptableObject")]
    [SerializeField] private ButtonsData ButtonsData;
    [SerializeField] private float delayThreshold;
    [SerializeField] private List<Button> buttonsList;
    #endregion
    private float delayThresholdFixedValue;
    private void Awake()
    {
        delayThresholdFixedValue = delayThreshold;
        SetButtonsScaleToZero();
    }
    private void SetButtonsScaleToZero()
    {
        foreach (Button button in buttonsList)
        {
            button.transform.localScale = Vector3.zero;
        }
    }

    void Start()
    {
        FireButtonsAnimation();
    }

    void Update()
    {
        
    }

    private void FireButtonsAnimation()
    {
        foreach (Button button in buttonsList)
        {
            button.transform.DOScale(ButtonsData.ButtonScaleSize, ButtonsData.Duration).SetDelay(ButtonsData.AnimationDelay * delayThreshold).SetEase(ButtonsData.AnimationEase);
            IncreaseAnimationDelay();
        }
    }
    private void IncreaseAnimationDelay()
    {
        delayThreshold += delayThresholdFixedValue;
    }
}
