using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab13
{
    public class Journal
    {
        private List<JournalEntry> entries;

        public List<JournalEntry> JournalEntries { get { return entries; } }

        public Journal()
        {
            entries = new List<JournalEntry>();
        }

        public void CollectionCountChanged(object sourse, CollectionHandlerEventArgs e)
        {
            JournalEntry je = new JournalEntry(e.NameCollection, e.TypeChange, e.Data.ToString());
            entries.Add(je);

        }
        public void CollectionReferenceChanged(object sourse, CollectionHandlerEventArgs e)
        {
            JournalEntry je = new JournalEntry(e.NameCollection, e.TypeChange, e.Data.ToString());
            entries.Add(je);
        }

        public void Show()
        {
            foreach (JournalEntry je in entries)
            {
                Console.WriteLine(je.ToString());
            }
        }
    }
}
