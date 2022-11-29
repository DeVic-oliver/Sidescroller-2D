using UnityEngine;
using DG.Tweening;
[CreateAssetMenu(menuName = "ScriptableObjects/Main Menu", fileName = "SCO_ButtonsData", order = 1)]
public class ButtonsData : ScriptableObject
{
    [Header("Animation Parameters")]
    public float Duration;
    public Ease AnimationEase;
    public float AnimationDelay;
    public float ButtonScaleSize;
}
