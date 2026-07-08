using Abstraction.SharedModel;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Runtime.Interface
{
    public interface IView
    {
        public void Open(DTO_Base data);
        public void Close();

        public void OnCompleted();
        public void OnCloseCompleted();
    }
}