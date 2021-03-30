using System;

namespace Tries
{
    class Program
    {
        static void Main(string[] args)
        {
            Trie trie = new Trie();
            trie.Insert("cap");
            trie.Insert("carpet");
            if(trie.search("cap") == true)
                Console.WriteLine("true");
            ;

        }
    }
    public class Trie
    {
        private Node root;
        public Trie()
        {
            root = new Node('\0');
        }
        public void Insert(string word)
        {
            Node current = root;
            for(int i= 0; i<word.Length; i++)
            {
                char c = word[i];
                if(current.children[c - 'a'] == null)
                {
                    current.children[c - 'a'] = new Node(c);
                }
                current = current.children[c - 'a'];
            }
            current.isWord = true;
        }
        public bool search(string word)
        {
            Node node = getNode(word);
            if (node !=null && node.isWord)
            {
                return true;

            }
            return false;
        }
        public bool StartsWith(string prefix)
        {
            return getNode(prefix) != null;
        }
        private Node getNode(string word)
        {
            Node current = root;
            for(int i= 0; i<word.Length; i++)
            {
                char c = word[i];
                if(current.children[c - 'a'] == null)
                {
                    return null;
                }
                current = current.children[c-'a'];
            }
            return current;
        }
        public class Node
        {
            public Node[] children;
            public bool isWord;
            public char c;
            public Node(char c)
            {
                children = new Node[26];
                isWord = false;
                this.c = c;
            }
        }
    }
}
