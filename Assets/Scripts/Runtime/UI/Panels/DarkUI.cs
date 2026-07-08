using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Abstraction
{
    [RequireComponent(typeof(Image))]
    public class DarkUI : MonoBehaviour
    {
        [SerializeField] Image _darkImg;
        public float fadeDuration = 0.2f;

        private void Reset()
        {
            _darkImg = GetComponent<Image>();
            _darkImg.color = new Color(0, 0, 0, 0);
        }

        private void Hide()
        {
            gameObject.SetActive(false);
            _darkImg.DOFade(0, 0f);
        }

        private async UniTask FadeIn()
        {
            gameObject.SetActive(true);
            await _darkImg.DOFade(1f, fadeDuration).ToUniTask();
        }

        private async UniTask FadeOut()
        {
            await _darkImg.DOFade(0f, fadeDuration).OnComplete(Hide).ToUniTask();
        }

        public async void TransitionAsync(Func<UniTask> callBack)
        {
            await FadeIn();
            await callBack();
            await FadeOut();
        }

        public async UniTask Transition(UnityAction callBack)
        {
            //, bool isPopup
            //if (isPopup) 
            //{
            //    callBack?.Invoke();
            //    return;
            //}

            await FadeIn();
            await UniTask.WaitForSeconds(0.2f);
            callBack?.Invoke();
            await UniTask.WaitForSeconds(0.2f);
            await FadeOut();
        }
    } 
}