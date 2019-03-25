/* TriewithOneChild.cs
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
    public class TrieWithOneChild : ITrie
    {
        /// <summary>
        /// Bool used to keep track whether or not the ITrie shoudl have an empty string
        /// </summary>
        private bool _hasEmptyString;
        /// <summary>
        /// The single ITrie for just one child
        /// </summary>
        private ITrie _child;
        /// <summary>
        /// The label to include on the child
        /// </summary>
        private char _childLabel;

        /// <summary>
        /// Adds the given string to the trie
        /// </summary>
        /// <param name="s">String to add</param>
        /// <returns>The trie with added string</returns>
        public ITrie Add(string s)
        {
            if (s == "")
            {
                _hasEmptyString = true;
                return this;
            }
            else if (s[0] == _childLabel)
            {
               _child = _child.Add(s.Substring(1));
                return this;
            }
            else
            {
                return new TrieWithManyChildren(s, _hasEmptyString, _childLabel, _child);
            }
        }

        /// <summary>
        /// Checks to see if a string is in a trie
        /// </summary>
        /// <param name="s">String to check in trie</param>
        /// <returns>True or false if s is there</returns>
        public bool Contains(string s)
        {
            if (s == "")
            {
                return _hasEmptyString;
            }
            else
            {
                if (s[0] == _childLabel)
                {
                    return _child.Contains(s.Substring(1));
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Constructs a trie with the given string
        /// </summary>
        /// <param name="s">String to put into the trie</param>
        /// <param name="hasEmpty">Indicates whether the trie should be empty or not</param>
        public TrieWithOneChild(string s, bool hasEmpty)
        {
            if (s == "" || s[0] < 'a' || s[0] > 'z')
            {
                throw new ArgumentException();
            }
            _hasEmptyString = hasEmpty;
            _childLabel = s[0];
            _child = new TrieWithNoChildren().Add(s.Substring(1));
        }
    }
}
