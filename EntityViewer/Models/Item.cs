using System;
using System.Collections;
using System.Collections.Generic;

namespace EntityViewer.Models
{
    public class Item : ICollection<Item>, ICollection<Component>
    {
        private Item _parent;
        private List<Item> _childs;
        private List<Component> _components;

        public Item(Item parent = null)
        {
            parent?.Add(this);
        }

        public Item Parent
        {
            get { return _parent; }
            set
            {
                if (_parent == value)
                    return;

                var parent = _parent;
                _parent = value;

                parent?.Remove(this);
                _parent?.Add(this);
            }
        }

        public ICollection<Item> Childs => this;
        public ICollection<Component> Components => this;

        public IEnumerable ComponentsAsEnumerable()
        {
            return _components ?? new List<Component>();
        }

        public IEnumerable ChildsAsEnumerable()
        {
            return _childs ?? new List<Item>();
        }

        #region ICollection<Item>

        public void Add(Item child)
        {
            if (_childs == null)
                _childs = new List<Item>();
            else if (_childs.Contains(child))
                return;

            _childs.Add(child);
            child.Parent = this;
        }

        public bool Remove(Item child)
        {
            var removed = false;
            if (_childs != null && _childs.Contains(child))
            {
                removed = _childs.Remove(child);
                child.Parent = null;
            }
            return removed;
        }

        int ICollection<Item>.Count => _childs?.Count ?? 0;

        bool ICollection<Item>.IsReadOnly => false;

        void ICollection<Item>.Clear()
        {
            if (_childs == null) return;
            var childs = _childs.ToArray();
            _childs.Clear();
            foreach (var child in childs)
                child.Parent = null;
        }

        bool ICollection<Item>.Contains(Item item)
        {
            return _childs != null && _childs.Contains(item);
        }

        void ICollection<Item>.CopyTo(Item[] array, int arrayIndex)
        {
            _childs.CopyTo(array, arrayIndex);
        }

        IEnumerator<Item> IEnumerable<Item>.GetEnumerator()
        {
            return _childs?.GetEnumerator() ?? new List<Item>().GetEnumerator();
        }

        #endregion ICollection<Item>

        #region ICollection<Component>

        public void Add(Component component)
        {
            if (_components == null)
                _components = new List<Component>();
            else if (_components.Contains(component))
                return;

            _components.Add(component);
            component.Item = this;
        }

        public bool Remove(Component component)
        {
            var removed = false;
            if (_components != null && _components.Contains(component))
            {
                removed = _components.Remove(component);
                component.Item = null;
            }
            return removed;
        }

        int ICollection<Component>.Count => _components?.Count ?? 0;

        bool ICollection<Component>.IsReadOnly => false;

        void ICollection<Component>.Clear()
        {
            if (_childs == null) return;
            var childs = _childs.ToArray();
            _childs.Clear();
            foreach (var child in childs)
                child.Parent = null;
        }

        bool ICollection<Component>.Contains(Component component)
        {
            return _components != null && _components.Contains(component);
        }

        void ICollection<Component>.CopyTo(Component[] array, int arrayIndex)
        {
            _components.CopyTo(array, arrayIndex);
        }

        IEnumerator<Component> IEnumerable<Component>.GetEnumerator()
        {
            return _components?.GetEnumerator() ?? new List<Component>().GetEnumerator();
        }

        #endregion ICollection<Component>

        #region IEnumerable

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
