using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lists.IntNode
{
    public class IntNode
    {
        private int value;
        private IntNode next;

        public IntNode(int value)
        {
            this.value = value;
            this.next = null;
        }
        
        private IntNode(int value, IntNode next)
        {
            this.value = value;
            this.next = next;
        }

        public override string ToString() 
        {
            string str = "";
            try { str += $"{this.value}, "; }
            catch (Exception) { }
            str += this.next;
            return str;
        }
        public int GetValue() => this.value;
        public IntNode GetNext() => this.next;

        internal void SetValue(int value) => this.value = value;
        internal void SetNext(IntNode next) => this.next = next;

        private bool HasNext() => GetNext() != null;
        private IntNode GetPreviousNode(IntNode current)
        {
            IntNode first = this;
            for (IntNode next = first.GetNext(); first.HasNext(); first = next,
                next = first.GetNext())
            {
                if (next == current)
                    return first;
            }
            return null;
        }
        private IntNode GetNodeWithVal(int val)
        {
            IntNode first = this;

            if (first.GetValue() == val)
                return first;
            for (IntNode next = first.GetNext(); first.HasNext(); first = next,
                next = first.GetNext())
            {
                if (next.GetValue() == val)
                    return next;
            }
            return null;
        }
        public bool AddNode(int val)
        {
            IntNode first = this;
            if (val < this.GetValue())
            {
                this.SetNext(new IntNode(this.GetValue(), this.GetNext()));
                this.SetValue(val);
                return true;
            }

            for (IntNode next = first.GetNext(); first.HasNext(); first = next,
                next = first.GetNext())
            {
                if (next != null && val < next.GetValue())
                {
                    first.SetNext(new IntNode(val, next));
                    return true;
                }
                if (val == next.GetValue())
                    return false;
            }
            first.SetNext(new IntNode(val));
            return true;
        }
        public bool RecursiveAdd(int val)
        {
            if (val == this.GetValue())
                return false;
            if (val < this.GetValue())
            {
                this.SetNext(new IntNode(this.GetValue(), this.GetNext()));
                this.SetValue(val);
                return true;
            }
            if (!this.HasNext())
            {
                this.SetNext(new IntNode(val));
                return true;
            }
            return this.GetNext().RecursiveAdd(val);
        }
        public bool RecursiveRemove(int val) { IntNode node = GetNodeWithVal(val); if (node is not null) return RecursiveRemove(node); return false; }
        public bool RecursiveRemove(IntNode curr)
        {
            if (HasNext())
            {
                IntNode next = GetNext();
                if (next == curr)
                {
                    SetNext(next.GetNext());
                    curr.SetNext(null);
                    return true;
                }
                if (curr == this)
                {
                    SetValue(next.GetValue());
                    SetNext(next.GetNext());
                    next.SetNext(null);
                    return true;
                }
                return GetNext().RecursiveRemove(curr);
            }
            Console.WriteLine("No.");
            return false;
        }
        public bool RemoveNode(IntNode curr)
        {
            if (curr == this)
            {
                if (!curr.HasNext())
                    return false;
                IntNode next = curr.GetNext();
                SetValue(next.GetValue());
                SetNext(next.GetNext());
                return true;
            }
            IntNode prev = GetPreviousNode(curr);
            if (prev == null)
                return false;
            prev.SetNext(curr.GetNext());
            return true;
        }
        public bool RemoveNode(int val)
        {
            IntNode curr = GetNodeWithVal(val);
            if (curr == null)
                return false;
            return RemoveNode(curr);
        }
        public static void CouplesList(IntNode list, int num)
        {
            IntNode p = list;
            IntNode r;
            while (p is not null)
            {
                r = new IntNode(num - p.GetValue());
                r.SetNext(p.GetNext());
                p=p.GetNext();
            }
        }
        public static IntNode BuildRandList(int length, int min, int max, Random rand = null)
        {
            if (rand is null) rand = new Random();// else rand = new Random(seed);
            int rInt = rand.Next(min, max + 1);
            IntNode first = new(rInt);
            IntNode last = first;
            if (length > 1)
            {
               // int nextint = rand.Next() * rand.Next();
                last.SetNext(BuildRandList(length - 1, min, max, rand));
            }
            return first;
        }
        /*public static IntNode BuildRandList(int length, int min, int max)
        {
            Random rand = new Random();
            int x = rand.Next(min, max);
            IntNode first = new IntNode(x);
            IntNode last = first;
            for (int i = 0; i < length -1; i++)
            {
                x = rand.Next(min, max + 1);
                last.SetNext(new IntNode(x));
                last = last.GetNext();
            }
            return first;

        }*/
    }
}
