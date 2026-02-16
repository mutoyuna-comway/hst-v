using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Wia.Abstractions;

namespace StubWia
{
  
    public class StubIConfigStore : IConfigStore
    {
        private IJob _parentJob;
        public IJob ParentJob
        {
            get { return this._parentJob; }
            private set
            {
                this._parentJob = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ParentJob)));
            }
        }

        private int _count = 1;
        public int Count
        {
            get { return this._count; }
            private set
            {
                this._count = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Count)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        public event EventHandler CollectionChanging;
        public event EventHandler CollectionChanged;

        public IEnumerator<IJobConfig> GetEnumerator()
        {
            return new List<IJobConfig>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IJobConfig GetOrDefault(int configId)
        {
            return new StubIJobConfig();
        }
    }
}
