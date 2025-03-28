using System;
using UnityEngine;
using UnityEngine.UI;

namespace LondonPlatform.Core
{
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField] private RectTransform Container;
        [SerializeField] private Transform Start;
        [SerializeField] private Transform End;
        [SerializeField] private Transform Player;
        [SerializeField] private Image ProgressBarImage;
        [SerializeField] private Image GuardImage;

        private void Update()
        {
            float maxDistance = (End.position - Start.position).sqrMagnitude;
            float actualDistance = (Player.position - Start.position).sqrMagnitude;
            
            ProgressBarImage.fillAmount = actualDistance / maxDistance;
            float x = Mathf.Lerp(Container.rect.xMin, Container.rect.xMax, actualDistance / maxDistance);
            GuardImage.transform.localPosition = new Vector3(x, GuardImage.transform.localPosition.y, GuardImage.transform.localPosition.z);
        }
    }
}