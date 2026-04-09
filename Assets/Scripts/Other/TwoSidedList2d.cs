using System.Collections.Generic;
using System;
using JetBrains.Annotations;
using UnityEngine.UIElements;

namespace Other
{
    public class TwoSidedList2d<T>
    {
        private TwoSidedList<TwoSidedList<T>> _items;

        public TwoSidedList2d(int xCapacity, int yCapacity)
        {
            _items = new();
            Init(xCapacity, yCapacity);
        }

        public T this[int x, int y]
        {
            get
            {
                return _items[x][y];
            }
            set
            {
                _items[x][y] = value;
            }
        }

        public int PositiveLengthX => _items.PositiveLength;

        public int NegativeLengthX => _items.NegativeLength;

        public int PositiveLengthY => _items[_items.FirstIndex].PositiveLength;

        public int NegativeLengthY => _items[_items.FirstIndex].NegativeLength;

        public void AddX()
        {
            _items.Add(new());

            for (int i = 0; i < PositiveLengthY; i++)
            {
                _items[_items.LastIndex].Add(default);
            }

            for (int i = 0; i < NegativeLengthY; i++)
            {
                _items[_items.LastIndex].ReverseAdd(default);
            }
        }

        public void AddY()
        {
            for (int i = _items.FirstIndex; i <= _items.LastIndex; i++)
            {
                _items[i].Add(default);
            }
        }

        public void AddNegativeX()
        {
            int positiveLength = PositiveLengthY;
            int negativeLength = NegativeLengthY;
            _items.ReverseAdd(new());

            for (int i = 0; i < positiveLength; i++)
            {
                _items[_items.FirstIndex].Add(default);
            }

            for (int i = 0; i < negativeLength; i++)
            {
                _items[_items.FirstIndex].ReverseAdd(default);
            }
        }

        public void AddNegativeY()
        {
            for (int i = _items.FirstIndex; i <= _items.LastIndex; i++)
            {
                _items[i].ReverseAdd(default);
            }
        }

        public Vector2Int IndexOf(T item)
        {
            Vector2Int index = Vector2Int.Zero;

            if (TryFindIndexOf(item, out index))
            {
                return index;
            }

            throw new InvalidOperationException("Is not contains the item");
        }

        public bool TryFindIndexOf(T item, out Vector2Int index)
        {
            bool isFounded = false;

            for (int x = NegativeLengthX * -1; x < PositiveLengthX; x++)
            {
                for (int y = NegativeLengthY * -1; y < PositiveLengthY; y++)
                {
                    if (this[x, y]?.Equals(item) ?? false)
                    {
                        isFounded = true;
                        index = new(x, y);
                        return isFounded;
                    }
                }
            }

            index = Vector2Int.Zero;
            return isFounded;
        }

        public bool Contains(T item)
        {
            return TryFindIndexOf(item, out _);
        }

        public List<T> GetAll()
        {
            List<T> allItems = new();

            for (int x = NegativeLengthX * -1; x < PositiveLengthX; x++)
            {
                for (int y = NegativeLengthY * -1; y < PositiveLengthY; y++)
                {
                    if (this[x, y]?.Equals(default) == false)
                    {
                        allItems.Add(this[x, y]);
                    }
                }
            }

            return allItems;
        }

        public bool IsInRange(Vector2Int index)
        {
            bool isInXRange = index.X >= NegativeLengthX * -1 && index.X < PositiveLengthX;
            bool isInYRange = index.Y >= NegativeLengthY * -1 && index.Y < PositiveLengthY;
            return isInXRange && isInYRange;
        }

        public void CorrectLength(Vector2Int index)
        {
            if (index.X < NegativeLengthX * -1)
            {
                while (NegativeLengthX + index.X < 0)
                {
                    AddNegativeX();
                }
            }

            if (index.X >= PositiveLengthX)
            {
                while (PositiveLengthX - index.X <= 0)
                {
                    AddX();
                }
            }

            if (index.Y < NegativeLengthY * -1)
            {
                while (NegativeLengthY + index.Y < 0)
                {
                    AddNegativeY();
                }
            }

            if (index.Y >= PositiveLengthY)
            {
                while (PositiveLengthY - index.Y <= 0)
                {
                    AddY();
                }
            }
        }

        private void Init(int xCapacity, int yCapacity)
        {
            for (int x = 0; x < xCapacity; x++)
            {
                AddX();
            }

            for (int y = 0; y < yCapacity; y++)
            {
                AddY();
            }
        }
    }
}