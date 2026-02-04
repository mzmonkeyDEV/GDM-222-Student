using UnityEngine;

namespace Solution
{
    public abstract class ItemData : ScriptableObject
    {
        public string ItemName;
        public Sprite icon;
        [TextArea] public string description;
        public virtual void Use(Identity identity)
        {
            Debug.Log("Use Item by" + identity.Name);
        }
    }
}
