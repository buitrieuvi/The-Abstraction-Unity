using Abstraction.SharedModel;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Abstraction
{
    public class UIManager : MonoBehaviour
    {
        [Inject] private DiContainer _container;

        [Inject] private InputManager _input;
        [Inject] private GameDataManager _gameData;

        [SerializeField] Transform _handle;
        [SerializeField] DarkUI _dark;

        public bool IsTransitioning;

        private ViewBase _uiSelected;


        public async void Start()
        {
            //if (_input != null) { Debug.Log("11"); };
            //if (_input.InputActions != null) { Debug.Log("11"); }
            //;
            _input.InputActions.Player.Inventory.performed += async (e) =>
            {
                await OnUI<View_Inventory>(_gameData.PlayerData.Inventory);
            };

            //_input.Actions.FindActionMap("Player").FindAction("Inventory").started += async (e) =>
            //{
            //    await OnUI<View_Inventory>(_gameData.PlayerData.Inventory);
            //};

            _input.InputActions.Player.Esc.performed += async (e) =>
            {
                await OnUI<View_Menu>();
            };
        }

        public async UniTask OnUI<T>(DTO_Base data = null) where T : ViewBase
        {
            if (IsTransitioning)
                return;

            IsTransitioning = true;

            if (_uiSelected == null)
            {
                var panelExist = FindPanel<T>(true);

                if (panelExist != null)
                {
                    _uiSelected = panelExist;

                    await _dark.Transition(() =>
                    {
                        _uiSelected.Open(data);
                    });

                    IsTransitioning = false;
                    return;
                }

                await _dark.Transition(() =>
                {
                    var panel = _container
                        .InstantiatePrefabForComponent<T>(_gameData.GetPanel<T>(), _handle);

                    panel.Open(data);
                    _uiSelected = panel;
                });

                IsTransitioning = false;
                return;
            }

            if (_uiSelected.GetType() == typeof(T))
            {
                await _dark.Transition(() =>
                {
                    _uiSelected.Close();
                    _uiSelected = null;
                });

                IsTransitioning = false;
                return;
            }

            await _dark.Transition(() =>
            {
                _uiSelected.Close();
                _uiSelected = null;
            });

            IsTransitioning = false;
        }


        public T FindPanel<T>(bool curr)
        {
            var comp = _handle.transform.GetComponentInChildren<T>(curr);
            return comp;
        }
    }
}