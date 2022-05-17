using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Domain
{
    public static class ValueObjectExtensions
    {
        public static void UpdateFrom<T>(this List<T> source,List<T> destination) where T:ValueObject<T>
        {
            var addedObjects=destination.Except(source).ToList();
            var removedObjects=source.Except(destination).ToList();

            addedObjects.ForEach(source.Add);

            removedObjects.ForEach(i => source.Remove(i));
        }
    }
}
