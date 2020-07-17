using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;


    public class StringEditor : ITextEditor
    {
        private Trie<BigList<char>> usersStrings;
        private Trie<Stack<string>> usersStack;

        public StringEditor()
        {
            this.usersStrings = new Trie<BigList<char>>();
            this.usersStack = new Trie<Stack<string>>();

        }
        public void Login(string username)
        {
            this.usersStack.Insert(username, new Stack<string>());
            this.usersStrings.Insert(username, new BigList<char>());
        }

        public void Logout(string username)
        {
            if (this.usersStrings.Contains(username))
            {
                this.usersStrings.Delete(username);
                this.usersStack.Delete(username);

            }
        }

        public void Prepend(string username, string str)
        {
            if (!this.usersStrings.Contains(username))
            {
                return;
            }

            this.usersStack.GetValue(username).Push(string.Join("", this.usersStrings.GetValue(username)));
            this.usersStrings.GetValue(username).AddRangeToFront(str);
        }

        public void Insert(string username, int index, string str)
        {
            if (!this.usersStrings.Contains(username))
            {
                return;
            }

            this.usersStack.GetValue(username).Push(string.Join("", this.usersStrings.GetValue(username)));

            this.usersStrings.GetValue(username).InsertRange(index, str);
        }

        public void Substring(string username, int startIndex, int length)
        {
            if (!this.usersStrings.Contains(username))
            {
                return;
            }
            this.usersStack.GetValue(username).Push(string.Join("", this.usersStrings.GetValue(username)));

            var userString = this.usersStrings.GetValue(username);
            var userHistory = this.usersStack.GetValue(username);
            userHistory.Push(string.Join("", userString));

            this.usersStrings.GetValue(username).GetRange(startIndex, length);
        }

        public void Delete(string username, int startIndex, int length)
        {
            if (!this.usersStrings.Contains(username))
            {
                return;
            }

            this.usersStack.GetValue(username).Push(string.Join("", this.usersStrings.GetValue(username)));

            this.usersStrings.GetValue(username).RemoveRange(startIndex, length);
        }

        public void Clear(string username)
        {
            if (!this.usersStrings.Contains(username))
            {
                return;
            }
            this.usersStack.GetValue(username).Push(string.Join("", this.usersStrings.GetValue(username)));

            this.usersStrings.Insert(username, new BigList<char>());
        }

        public int Length(string username)
        {
            throw new NotImplementedException();
        }

        public string Print(string username)
        {
            if (!this.usersStrings.Contains(username))
            {
                return " ";
            }

            return string.Join(" ", this.usersStrings.GetValue(username));
        }

        public void Undo(string username)
        {
            if (!this.usersStrings.Contains(username))
            {
                return;
            }

            var userString = this.usersStrings.GetValue(username);
            var userHistory = this.usersStack.GetValue(username);

            if (userHistory.Count == 0)
            {
                return;
            }
            var lastUserString = userHistory.Pop();
            userHistory.Push(string.Join("", userString));

            this.usersStrings.Insert(username, new BigList<char>(lastUserString));
        }

        public IEnumerable<string> Users(string prefix = "")
        {
            throw new NotImplementedException();
        }
    }

