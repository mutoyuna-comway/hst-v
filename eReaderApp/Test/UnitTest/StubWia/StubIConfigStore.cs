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

        private int _count = 0;
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
        
        public StubIConfigStore() { }
        public event EventHandler CollectionChanging;
        public event EventHandler CollectionChanged;
        public IEnumerator<IJobConfig> GetEnumerator()
        {
            return null;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return null;
        }
    }
}
