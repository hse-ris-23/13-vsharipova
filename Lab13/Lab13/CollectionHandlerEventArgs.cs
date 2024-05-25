using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab13
{
    public class CollectionHandlerEventArgs : EventArgs
    {
        public string TypeChange { get; }
        public object Data { get; }
        public string NameCollection { get; set; }
        public CollectionHandlerEventArgs(string typeChange, object data, string nameCollection)
        {
            TypeChange = typeChange;
            Data = data;
            NameCollection = nameCollection;
        }
    }
}
