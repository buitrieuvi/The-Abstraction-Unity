using Assets.Scripts.Runtime.Interface;
using System;
using UnityEngine;

namespace Abstraction 
{
    public class Select
    {
        protected ISelect select;
        protected ISelect hover;

        public virtual void OnChanged(ISelect newSelect)
        {

            select?.DeSelected();
            
            select = newSelect;

            select.Selected();
        }

        public virtual void OnHover(ISelect newHover)
        {
            hover = newHover;
            hover.Hover();
        }

        public virtual void OnUnHover()
        {
            hover.UnHover();
            hover = null;
        }
    }
}