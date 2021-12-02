using UnityEngine;

namespace ExpressoBits.Inventory
{
    [CreateAssetMenu(fileName = "Item", menuName = "Expresso Bits/Inventory/Item")]
    public class Item : ScriptableObject, IItem
    {
        public byte ID => id;
        public string Name => name;
        public string Description => description;
        public Sprite Icon => icon;
        public float Weight => weight;
        public byte MaxStack => maxStack;
        public ItemObject ItemObjectPrefab => itemObjectPrefab;
        public Category Category => category;

        [SerializeField] private byte id = 0;
        [SerializeField, TextArea] private string description;
        [SerializeField] private Sprite icon;
        [SerializeField, Min(0.01f)] private float weight = 0.1f;
        [SerializeField, Min(1)] private byte maxStack = 64;
        [SerializeField] private ItemObject itemObjectPrefab;
        [SerializeField] private Category category;

        internal void Setup(byte id)
        {
            this.id = id;
        }

        public static implicit operator byte(Item item)
        {
            return item.ID;
        }

        public static implicit operator Item(byte id)
        {
            Items[] items = Resources.FindObjectsOfTypeAll<Items>();
            if(items.Length > 0)
            {
                return items[0].GetItem(id);
            }
            Debug.Log("There are no scriptable items in the project!");
            return null;
        }

    }
}
