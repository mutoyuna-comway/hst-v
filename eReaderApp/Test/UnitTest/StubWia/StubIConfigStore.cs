using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Wia.Abstractions;

namespace StubWia
{
  
    public class StubIConfigStore : IConfigStore
    {
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
