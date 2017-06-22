﻿using System.ComponentModel;

namespace AnyStatus.API
{
    public abstract class Metric : Item
    {
        private object _value;

        [Browsable(false)]
        public object Value
        {
            get { return _value; }
            set
            {
                _value = value;
                OnPropertyChanged();
            }
        }
    }
}
