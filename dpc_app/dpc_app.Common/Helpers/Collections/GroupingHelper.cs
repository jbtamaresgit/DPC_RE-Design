using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace dpc_app.Common.Helpers.Collections
{
    public class GroupingHelper <K, T> : ObservableCollection<T>
    {
        public K Key { get; set; }
        public GroupingHelper(K key, IGrouping<K, T> group)
        {
            Key = key;

            foreach(T item in group)
            {
                this.Items.Add(item);
            }
        }

        public GroupingHelper(K key, IEnumerable<T> items)
        {
            Key = key;

            foreach (T item in items)
            {
                this.Items.Add(item);
            }
        }
    }
}
