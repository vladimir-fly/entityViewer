using System;

namespace EntityViewer.Models
{
    public enum DisplayType { Field, Collection, Property }

    public class DisplayEntityTypeAttribute : Attribute
    {
        public DisplayType DisplayType { get; set; }
        public DisplayEntityTypeAttribute(DisplayType type)
        {
            DisplayType = type;
        }
    }
}