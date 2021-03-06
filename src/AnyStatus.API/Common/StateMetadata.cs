﻿using System;

namespace AnyStatus.API
{
    [Serializable]
    public class StateMetadata : NotifyPropertyChanged
    {
        private string _color;

        public StateMetadata()
        {
        }

        public StateMetadata(int value, int priority, string displayName, string color, string icon)
        {
            Value = value;
            DisplayName = displayName;
            Priority = priority;
            Color = color;
            Icon = icon;
        }

        public int Value { get; set; }

        public int Priority { get; set; }

        public string DisplayName { get; set; }

        public string Color
        {
            get { return _color; }
            set { _color = value; OnPropertyChanged(); }
        }

        public string Icon { get; set; }

        public StateMetadata Clone()
        {
            return (StateMetadata)MemberwiseClone();
        }
    }
}
