using System.Collections.Generic;

namespace Other
{
    public class TwoSidedList<T>
    {
        private List<T> _items;
        private int _negativeShift;

        public TwoSidedList()
        {
            _items = new();
            _negativeShift = 0;
        }

        public T this[int index]
        {
            get
            {
                return _items[index + _negativeShift];
            }
            set
            {
                _items[index + _negativeShift] = value;
            }
        }

        public int PositiveLength => _items.Count - _negativeShift;

        public int NegativeLength => _negativeShift;

        public int FirstIndex => _negativeShift * -1;

        public int LastIndex => _items.Count - _negativeShift -1;

        public void Add(T item)
        {
            _items.Add(item);
        }

        public void ReverseAdd(T item)
        {
            _items.Insert(0, item);
            _negativeShift++;
        }

        public void Remove(T item)
        {
            if (_items.Contains(item))
            {
                int itemIndex = _items.IndexOf(item);

                if (itemIndex < _negativeShift)
                {
                    _negativeShift--;
                }

                _items.RemoveAt(itemIndex);
            }
        }

        public void RemoveAt(int index)
        {
            int itemIndex = index + _negativeShift;

            if (itemIndex < default(int) || itemIndex >= _items.Count)
            {
                return;
            }

            if (itemIndex < _negativeShift)
            {
                _negativeShift--;
            }

            _items.RemoveAt(itemIndex);
        }
    }
}