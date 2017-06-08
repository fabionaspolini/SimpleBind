using System;

namespace SimpleBind.Core.ComponentMap
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ComponentMapAttribute : Attribute
    {
        public int Id { get; set; }

        public ComponentMapAttribute()
        {
        }

        public ComponentMapAttribute(int aId)
        {
            Id = aId;
        }
    }
}