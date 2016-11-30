﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trie
{
    class TrieNode
    {
        public TrieNode[] arr;
        public bool isEnd;
        public TrieNode()
        {
            this.arr = new TrieNode[26];
        }
    }
    class Trie
    {
        private TrieNode root;
        public Trie()
        {
            root = new TrieNode();
        }
        public void insert(string word)
        {
            TrieNode p = root;
            for (int i = 0; i < word.Length; i++)
            {
                char c = word[i];
                int index = c - 'a';
                if (p.arr[index]==null)
                {
                    TrieNode temp = new TrieNode();
                    p.arr[index] = temp;
                    p = temp;
                }else
                    p = p.arr[index];
            }
            p.isEnd = true;
        }
        public TrieNode searchWord(string word)
        {
            TrieNode p = root;
            for (int i = 0; i < word.Length; i++)
            {
                char c = word[i];
                int index = c - 'a';
                if (p.arr[index] != null)
                {
                    p = p.arr[index];
                }
                else
                    return null;
            }
            if (p==root)
            {
                return null;
            }
            return p;
        }
        public bool search(string word)
        {
            TrieNode p = searchWord(word);
            if (p==null)
            {
                return false;
            }
            else
            {
                if (p.isEnd)
                    return true;
            }
            return false;
        }
        public bool startsWith(string prefix)
        {
            TrieNode p = searchWord(prefix);
            if (p == null)
                return false;
            else return true;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
