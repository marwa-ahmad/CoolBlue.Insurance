using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Insurance.Domain.ValidationExtension
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CannotBeEmtyListAttribute : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            var enumerable = value as IEnumerable;
            return enumerable != null && enumerable.GetEnumerator().MoveNext();
        }
    }
}
