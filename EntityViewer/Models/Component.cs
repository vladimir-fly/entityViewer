namespace MongoTest
{
    public class Component
    {
        private Item _item;

        public Component(Item item = null)
        {
            _item = item;
        }

        public Item Item
        {
            get { return _item; }
            set
            {
                if (_item == value)
                    return;

                var item = _item;
                _item = value;
                if (item != null)
                    item.Remove(this);

                if (_item != null)
                    _item.Add(this);
            }
        }
    }
}
