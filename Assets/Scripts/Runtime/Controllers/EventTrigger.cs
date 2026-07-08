using Assets.Scripts.Runtime.Interface;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Abstraction
{
    public abstract class EventTrigger : MonoBehaviour,
        IEventTrigger
    {
        public virtual void TriggerEnter()
        {
            
        }

        public virtual void TriggerExit()
        {
            
        }

        public virtual void OnInteract()
        {

        }
    }
}
