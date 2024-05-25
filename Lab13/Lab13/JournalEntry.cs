using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab13
{
    public class JournalEntry
    {
        public string NameCollection { get; }
        public string TypeChange { get; }
        public string DataObject { get; }

        public JournalEntry(string nameCollection, string typeChange, string data)
        {
            NameCollection = nameCollection;
            TypeChange = typeChange;
            DataObject = data;
        }

        public override string ToString()
        {
            return $"Коллекция: {NameCollection}, Тип изменения: {TypeChange}, Данные: {DataObject}";
        }
    }
}
