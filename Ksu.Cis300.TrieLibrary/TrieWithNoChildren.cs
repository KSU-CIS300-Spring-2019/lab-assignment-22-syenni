/* TrieWithNoChildren.cs
 * Author: Rod Howell
 * Modified: Seth Yenni
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    public class TrieWithNoChildren : ITrie
    {
        /// <summary>
        /// Indicates whether the empty string is stored in the trie rooted at the node
        /// </summary>
        private bool _hasEmptyString = false;

        /// <summary>
        /// Add method for TrieWithNoChildren, uses TrieWithOneChild if there's something to add
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public ITrie Add(string s)
        {
            if (s == "")
            {
                _hasEmptyString = true;
                return this;
            }
            else
            {
                return new TrieWithOneChild(s, _hasEmptyString);
            }
        }

        /// <summary>
        /// Looks to see if s is in the trie
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool Contains(string s)
        {
            if (s == "")
            {
                return _hasEmptyString;
            }
            else
            {
                return false;
            }
        }
    }
}
