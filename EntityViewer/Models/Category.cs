using System.Collections;
using System.Collections.Generic;

namespace EntityViewer.Models
{
    public class Category : ICollection<Item>
    {
        private List<Item> _items;
        public int Count => _items?.Count ?? 0;
        public bool IsReadOnly => false;

        public void Add(Item child)
        {
            if (_items == null)
                _items = new List<Item>();
            else if (_items.Contains(child))
                return;

            _items.Add(child);
        }

        public bool Remove(Item child)
        {
            return _items != null && _items.Contains(child) && _items.Remove(child);
        }

        public void Clear()
        {
            _items?.Clear();
        }

        public bool Contains(Item item)
        {
            return _items?.Contains(item) ?? false;
        }

        public void CopyTo(Item[] array, int arrayIndex)
        {
            _items?.CopyTo(array, arrayIndex);
        }

        IEnumerator<Item> IEnumerable<Item>.GetEnumerator()
        {
            return _items?.GetEnumerator() ?? new List<Item>().GetEnumerator();
        }

        public IEnumerator GetEnumerator()
        {
            return _items?.GetEnumerator() ?? new List<Item>().GetEnumerator();
        }
    }
}