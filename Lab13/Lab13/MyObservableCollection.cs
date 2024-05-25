using MyCollectionLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab13
{
    public class MyObservableCollection<T> : HTable<T> where T : ICloneable
    {
        public string Name { get; }

        public MyObservableCollection(string name)
        {
            Name = name;
        }

        public delegate void CollectionHandler(object source, CollectionHandlerEventArgs args);
        public event CollectionHandler CollectionCountChanged;
        public event CollectionHandler CollectionReferenceChanged;

        public void OnCollectionCountChanged(object source, CollectionHandlerEventArgs args)
        {
            if (CollectionCountChanged != null)
                CollectionCountChanged(source, args);
        }

        public void OnCollectionReferenceChanged(object source, CollectionHandlerEventArgs args)
        {
            if (CollectionReferenceChanged != null)
                CollectionReferenceChanged(source, args);
        }

        public override void Add(T data)
        {
            base.Add(data);

            OnCollectionCountChanged(this, new CollectionHandlerEventArgs("add", data, Name));
        }

        public override bool Remove(T data)
        {
            bool check = base.Remove(data);
            if (check)
                OnCollectionCountChanged(this, new CollectionHandlerEventArgs("remove", data, Name));
            return check;
        }

        public override T this[T key] 
        { 
            get => base[key];
            set
            {
                if (Contains(key))
                {
                    base.Remove(key);
                    base.Add(value);

                    OnCollectionReferenceChanged(this, new CollectionHandlerEventArgs("changed", value, Name));
                }
            }
        }
    }
}
