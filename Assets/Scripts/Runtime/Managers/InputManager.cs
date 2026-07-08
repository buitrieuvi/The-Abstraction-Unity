using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Abstraction
{
    public class InputManager : MonoBehaviour
    {
        //public InputActionAsset Actions;
        public InputSystem_Actions InputActions { get; private set; }

        ThoiTien thoiTien = new ThoiTien();

        public void Awake()
        {
            InputActions = new InputSystem_Actions();
            InputActions.Enable();
        }

        public void Start()
        {
            //Actions.Enable();

            foreach (int x in thoiTien.TienTra(41)) 
            {
                Debug.Log(x);
            }
        }


        public void IsCurrsor(bool status)
        {
            Cursor.visible = status;

            if (status)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }

        }
    }
}