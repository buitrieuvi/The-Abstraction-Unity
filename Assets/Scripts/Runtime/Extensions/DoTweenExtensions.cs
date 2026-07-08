using Assets.Scripts.Runtime.Interface;
using DG.Tweening;
using ModestTree;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Graphs;
using UnityEngine;
using UnityEngine.UI;

namespace Abstraction 
{
    public static class DoTweenExtensions
    {
        //public static void AbstractionSequence(List<Tweener> tweeners, Action act)
        //{
        //    Sequence sequence = DOTween.Sequence();

        //    foreach (var tween in tweeners)
        //    {
        //        sequence.Append(tween);
        //    }

        //    sequence.OnComplete(() => act());
        //    sequence.Play();
        //}

        public static void Selected(Image bg, TMP_Text text, Color color1, Color color2)
        {
            bg.color = color2;
            text.color = color1;

        }

        public static void DeSelected(Image bg, TMP_Text text, Color color1, Color color2)
        {
            bg.color = color1;
            text.color = color2;
        }

        public static void Hover(this RectTransform view)
        {
            view?.DOKill();
            view.DOScale(1.05f, 0.2f);
        }

        public static void UnHover(this RectTransform view)
        {
            view?.DOKill();
            view.DOScale(1f, 0.2f);
        }

        public static Tweener Transform(this RectTransform view, float time1, float time2)
        {

            view?.DOKill();

            RectTransform par = view.parent.GetComponent<RectTransform>();

            return view.DOAnchorPosX(0f, time1)
                    .From(new Vector2(-500f, par.anchoredPosition.y))
                    .SetDelay(par.GetSiblingIndex() * time2);
        }
    }
}

