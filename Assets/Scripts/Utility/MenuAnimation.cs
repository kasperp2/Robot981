using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG;
using DG.Tweening;

public class MenuAnimation : MonoBehaviour
{
    [SerializeField] private RectTransform _headerTransform;
    [SerializeField] private RectTransform _startButtonTransform;
    [SerializeField] private RectTransform _quitButtonTransform;

    [SerializeField] private Vector3 _headerEndPosition;
    [SerializeField] private Vector3 _startEndPosition;
    [SerializeField] private Vector3 _quitEndPosition;

    [SerializeField] private float _headerAnimationDuration;
    [SerializeField] private float _startAnimationDuration;
    [SerializeField] private float _quitAnimationDuration;


    private void Awake()
    {
        _headerTransform.DOLocalMove(_headerEndPosition, _headerAnimationDuration);
        _startButtonTransform.DOLocalMove(_startEndPosition, _startAnimationDuration);
        _quitButtonTransform.DOLocalMove(_quitEndPosition, _quitAnimationDuration);
    }
}
