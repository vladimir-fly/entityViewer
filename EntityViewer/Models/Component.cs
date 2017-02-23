namespace EntityViewer.Models
{
    public class Component
    {
        public string ComponentId { get; set; }
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
                item?.Remove(this);
                _item?.Add(this);
            }
        }
    }
}
