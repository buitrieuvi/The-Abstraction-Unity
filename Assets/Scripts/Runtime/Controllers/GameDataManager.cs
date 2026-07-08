using Abstraction.SharedModel;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;


namespace Abstraction
{
    public class GameDataManager
    {
        public List<ViewBase> Panels = new();
        public List<ItemSO> ItemSOs = new();
        public List<RankSO> RankSOs = new();

        [Inject] public DTO_Player PlayerData;

        public GameDataManager()
        {
            LoadAllDataAsync().Forget();
        }



        public async UniTask LoadAllDataAsync()
        {
            Caching.ClearCache();

            var panels = LoadAssetsAsync<GameObject>("panel", so => Panels.Add(so.GetComponent<ViewBase>()));
            var items = LoadAssetsAsync<ItemSO>("item", so => ItemSOs.Add(so));
            var rank = LoadAssetsAsync<RankSO>("rank", so => RankSOs.Add(so));

            await UniTask.WhenAll(panels, items, rank).ContinueWith(() =>
            {
                PlayerData.Inventory.ChangeItemById("1", 10);
                PlayerData.Inventory.ChangeItemById("2", 10);

            });

            //await UniTask.WaitForSeconds(5f);
            //PlayerData.Inventory.ChangeItemById("2", 10);
        }

        private async UniTask UpdateRemoteCatalogIfAvailable()
        {
            var checkHandle = Addressables.CheckForCatalogUpdates();
            var catalogs = await checkHandle.Task;

            if (catalogs != null && catalogs.Count > 0)
            {
                Debug.Log("📦 Catalog update found. Updating...");
                var updateHandle = Addressables.UpdateCatalogs(catalogs);
                await updateHandle.Task;
                Debug.Log("✅ Catalog updated.");
            }
            else
            {
                Debug.Log("ℹ️ No catalog updates found.");
            }
        }

        private async UniTask LoadAssetsAsync<T>(string label, System.Action<T> onAssetLoaded)
        {
            var handle = Addressables.LoadAssetsAsync<T>(label, onAssetLoaded);
            await handle.Task;

            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                Debug.Log($"✅ Loaded {typeof(T).Name}: {handle.Result.Count}");
            }
            else
            {
                Debug.LogError($"❌ Failed to load {typeof(T).Name} with label '{label}'");
            }
        }

        public T GetPanel<T>()
        {
            return Panels.OfType<T>().First();
        }

        public string GetJson() 
        {
            return JsonConvert.SerializeObject(PlayerData);
        }
    }
}