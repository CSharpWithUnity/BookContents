/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Chapter 8.10 Architecture and Organization                            *
 *                                                                       *
 * Copyright © 2018 Alex Okita                                           *
 *                                                                       *
 * This software may be modified and distributed under the terms         *
 * of the MIT license.  See the LICENSE file for details.                *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
namespace GameCo.ZombieGame
{
    using System.Collections;
    using System.Collections.Generic;

    public partial class BaseItemInfo : IEnumerator
    {
        private ItemInfoCollection ItemInfoCollection;
        private int CurrentItemInfoIndex;
        private BaseItemInfo CurrentItemInfo;

        public bool MoveNext()
        {
            throw new System.NotImplementedException();
        }

        public void Reset()
        {
            throw new System.NotImplementedException();
        }

        public object Current => throw new System.NotImplementedException();
    }

    public class ItemInfoCollection : ICollection<BaseItemInfo>
    {
        public void Add(BaseItemInfo item)
        {
            throw new System.NotImplementedException();
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public bool Contains(BaseItemInfo item)
        {
            throw new System.NotImplementedException();
        }

        public void CopyTo(BaseItemInfo[] array, int arrayIndex)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(BaseItemInfo item)
        {
            throw new System.NotImplementedException();
        }

        public int Count => throw new System.NotImplementedException();

        public bool IsReadOnly => throw new System.NotImplementedException();

        public IEnumerator<BaseItemInfo> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}