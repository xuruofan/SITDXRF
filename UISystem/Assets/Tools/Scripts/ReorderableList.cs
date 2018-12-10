using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shimmer.Tools
{
    public abstract class ReorderableListBase
    { }

    public class ReorderableList<T> : ReorderableListBase
    {
        public T[] Items;
    }
}

