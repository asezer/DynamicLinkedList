using System;
using System.Text;

namespace DynamicLinkedList
{
    class DynamicLinkedList
    {
        #region Private Properties

        private LinkedListItem _startLinkedListItem;

        private LinkedListItem _lastLinkedListItem;

        private int _totalLinkedListItems;

        #endregion

        #region CRUD

        public void Add(object obj)
        {
            var elem = new LinkedListItem(obj);

            if (_totalLinkedListItems == 0)
            {
                _startLinkedListItem = elem;
            }
            else
            {
                _lastLinkedListItem.NextItem = elem;
            }

            _totalLinkedListItems++;
            _lastLinkedListItem = elem;
        }

        public void Add(int index, object obj)
        {
            if (index == _totalLinkedListItems)
            {
                Add(obj);
            }
            else
            {
                var insertLinkedListItem = new LinkedListItem(obj);

                var elem = GetLinkedListItem(index);

                insertLinkedListItem.NextItem = elem.NextItem;

                elem.NextItem = insertLinkedListItem;

                _totalLinkedListItems++;
            }
        }

        public object Retrive(int index)
        {
            var elem = GetLinkedListItem(index);

            return elem.Obj;
        }

        public void Update(int index, object obj)
        {
            var elem = GetLinkedListItem(index);

            elem.Obj = obj;
        }

        public void Delete(int index)
        {
            // Since we're going to ask one element before
            if (index < 1 || index > _totalLinkedListItems)
                throw new IndexOutOfRangeException();

            if (index == 1)
            {
                _startLinkedListItem = _startLinkedListItem.NextItem;
            }
            else
            {
                // Get the element one before the element we want to delete
                var elem = GetLinkedListItem(index - 1);

                // Get the element we want to delete
                var deleteElem = elem.NextItem;

                // Change the chain link (Make notting pointing to one we want to delete.
                elem.NextItem = deleteElem.NextItem;
            }
            _totalLinkedListItems--;  
        }

        #endregion

        #region Utility

        private LinkedListItem GetLinkedListItem(int index)
        {
            if (index < 1 || index > _totalLinkedListItems)
                throw new IndexOutOfRangeException();

            // We know we have at least one element
            var returnLinkedListItem = _startLinkedListItem;

            // Loop until reach the element
            for (var i = 1; i < index; i++)
            {
                returnLinkedListItem = returnLinkedListItem.NextItem;
            }

            return returnLinkedListItem;
        }

        public int Count()
        {
            return _totalLinkedListItems;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (var i = 1; i <= _totalLinkedListItems; i++)
            {
                sb.AppendFormat("[item{0}]: {1}, ", i, Retrive(i));
            }
            return sb.ToString();
        }

        #endregion
    }
}
