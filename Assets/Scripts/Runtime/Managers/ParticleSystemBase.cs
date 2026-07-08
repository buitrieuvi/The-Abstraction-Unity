using UnityEngine;

namespace Abstraction
{
    public class ParticleSystemBase : MonoBehaviour
    {
        ObjectPool _parent;
        ParticleSystem _children;

        private void Awake()
        {
            _parent = GetComponentInParent<ObjectPool>();
            _children = GetComponent<ParticleSystem>();
        }

        private void OnDisable()
        {
            _children.transform.SetAsFirstSibling();
            _parent.Pooling.Push(_children);
        }
    }
}