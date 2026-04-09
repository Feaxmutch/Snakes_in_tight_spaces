using System.Collections.Generic;
using System.Linq;

namespace Other
{
    public class Array2d<T>
    {
        private T[,] _items;

        public Array2d(int xCapacity, int yCapacity)
        {
            _items = new T[xCapacity, yCapacity];
        }

        public int LengthX => _items.GetLength(0);

        public int LengthY => _items.GetLength(1);

        public T this[int x, int y]
        {
            get
            {
                return _items[x, y];
            }
            set
            {
                _items[x, y] = value;
            }
        }

        public void Resize(int xCapacity, int yCapacity)
        {
            T[,] resizedItems = new T[xCapacity, yCapacity];

            for (int x = 0; x < LengthX && x < resizedItems.GetLength(0); x++)
            {
                for (int y = 0; y < LengthY && y < resizedItems.GetLength(1); y++)
                {
                    resizedItems[x, y] = _items[x, y];
                }
            }

            _items = resizedItems;
        }

        public Vector2Int IndexOf(T item)
        {
            for (int y = 0; y < LengthY; y++)
            {
                for (int x = 0; x < LengthX; x++)
                {
                    if (_items[x, y] != null && _items[x,y].Equals(item))
                    {
                        return new Vector2Int(x, y);
                    }
                }
            }

            return new Vector2Int(-1, -1);
        }

        public T[] GetAll()
        {
            List<T> res = new();
            T[] result = new T[LengthX * LengthY];

            for (int y = 0; y < LengthY; y++)
            {
                for (int x = 0; x < LengthX; x++)
                {
                    result[x + LengthX * y] = _items[x, y];
                }
            }

            return result.Where(item => item != null).ToArray();
        }
    }
}