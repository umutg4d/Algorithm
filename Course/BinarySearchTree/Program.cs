using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinarySearchTree
{
    class NodeBST
    {
        protected NodeBST parent;
        protected NodeBST left;
        protected NodeBST right;
        protected int key;
        private int height;
        public NodeBST(int key)
        {
            this.parent = null;
            this.key = key;
            this.left = null;
            this.right = null;
        }
        public NodeBST find(int key)
        {
            if (key==this.key)
                return this;
            else if (key<this.key)
            {
                if (this.left == null)
                    return null;
                else return this.left.find(key);
            }
            else //Key şu andaki node'un key değerinden büyükse sağ tarafta aramaya geç.
            {
                if (this.right==null)
                    return null;
                else
                    return this.right.find(key);
            }
        }
        public NodeBST Find_Min()
        {
            //Tree'de yer alan en küçük elemanı gönderir.
            NodeBST current=this;
            while (current!=null)
            {
                current = current.left;
            }
            return current;
        }
        public NodeBST Next_Larger()
        {
            //Şu ankinden bir büyük sırada olan node'u döndürür.
            NodeBST current = this;
            if (current.right!=null)
            {
                return current.right.Find_Min();
            }
            while (current.parent!=null&&current==current.parent.right)
            {
                current = current.parent;
            }
            return current.parent;
        }
        public void Insert(NodeBST node)
        {
            if (node==null)
                return;
            else
            {
                if (this.key>node.key)
                {
                    if (this.left == null)
                    {
                        this.left = node;
                        node.parent = this;
                    }
                    else this.left.Insert(node);
                }
               else
                {
                    if (this.right == null)
                    {
                        this.right = node;
                        node.parent = this;
                    }
                    else this.right.Insert(node);
                }
            }
        }
        public NodeBST Delete()
        {
            if (this.left==null||this.right==null)
            {
                if (this==this.parent.left)
                {
                    if (this.left == null)
                        this.parent.left = this.right;
                    else
                        this.parent.left = this.left;
                    if (this.parent.left!=null)
                        this.parent.left.parent = this.parent;
                }
                else
                {
                    if (this.left == null)
                        this.parent.right = this.right;
                    else
                        this.parent.right = this.left;
                    if (this.parent.right!=null)
                        this.parent.right.parent = this.parent;
                }
                return this;
            }else
            {
                NodeBST s= this.Next_Larger();
                s.left=this.left;s.right = this.right;s.key = this.key;s.parent = this.parent;
                return s.Delete();
            }
        }
        public void UpdateHeight()
        {
            this.height = Math.Max(GetHeight(this.left), GetHeight(this.right)) + 1;
        }
        public int GetHeight(NodeBST node)
        {
            if (node==null)
            {
                return -1;
            }else
            {
                return node.height;
            }
        }
    }
    class NodeAVL : NodeBST
    {
        public NodeAVL(int key):base(key)
        {
            
        }
        public void Insert(NodeAVL node)
        {
            base.Insert(node);
            node.ReBalance();
        }
        public new void Delete()
        {
            NodeAVL node=(NodeAVL)base.Delete();
            ((NodeAVL)node.parent).ReBalance();
        }
        public void RightRotate()
        {
            NodeAVL y = (NodeAVL)this.left;
            y.parent = this.parent;
            if (((NodeAVL)y.parent).right == this)
            {
                ((NodeAVL)y.parent).right = y;
            }
            else if (((NodeAVL)y.parent).left == this)
            {
                ((NodeAVL)y.parent).left = y;
            }
            this.left = y.right;
            if (this.left != null)
                ((NodeAVL)this.left).parent = this;
            y.right = this;
            this.parent = y;
            UpdateHeight();
            y.UpdateHeight();
        }
        public void LeftRotate()
        {
            NodeAVL y = (NodeAVL)this.right;
            y.parent = this.parent;
            if (((NodeAVL)y.parent).left==this)
            {
                ((NodeAVL)y.parent).left = y;
            }
            else if (((NodeAVL)y.parent).right==this)
            {
                ((NodeAVL)y.parent).right = y;
            }
            this.right = y.left;
            if (this.right != null)
                ((NodeAVL)this.right).parent = this;
            y.left = this;
            this.parent = y;
            UpdateHeight();
            y.UpdateHeight();
        }
        public void ReBalance()
        {
            NodeAVL node = this;
            while (node!=null)
            {
                node.UpdateHeight();
                if (GetHeight(node.right)>=2+GetHeight(node.left))
                {
                    if (GetHeight(((NodeAVL)node.right).right)>=GetHeight(((NodeAVL)node.right).left))
                        LeftRotate();
                    else
                    {
                        ((NodeAVL)node.right).RightRotate();
                        LeftRotate();
                    }
                }
                else if (GetHeight(node.left) >= 2 + GetHeight(node.right))
                {
                    if (GetHeight(((NodeAVL)node.left).left) >= GetHeight(((NodeAVL)node.left).right))
                        RightRotate();
                    else
                    {
                        ((NodeAVL)node.left).LeftRotate();
                        RightRotate();
                    }
                }
                node = (NodeAVL)node.parent;
            }
        }
    }
    class HackerRankBinTree
    {
        public HackerRankBinTree left, right;
        public int data;
        public HackerRankBinTree(int data)
        {
            this.data = data;
        }
        public void Insert(int value)
        {
            if (value<=data)
            {
                if (left==null)
                    left = new HackerRankBinTree(value);
                else
                    left.Insert(value);
            }else
            {
                if (right==null)
                    right = new HackerRankBinTree(value);
                else
                    right.Insert(value);
            }
        }
        public void PrintInOrderTraversal()
        {
            if (left!=null)
            {
                left.PrintInOrderTraversal();
            }
            Console.WriteLine(this.data);
            if (right!=null)
            {
                right.PrintInOrderTraversal();
            }
        }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            HackerRankBinTree root = new HackerRankBinTree(3);
            //root.Insert(1);root.Insert(2);root.Insert(3); root.Insert(5); root.Insert(4); root.Insert(6); root.Insert(7);
            //bool a=checkDuplication(root.left, 2);
            root.left = new HackerRankBinTree(2);root.left.left = new HackerRankBinTree(1);root.left.right = new HackerRankBinTree(4);root.right = new HackerRankBinTree(6);root.right.left = new HackerRankBinTree(5);root.right.right = new HackerRankBinTree(7);

            bool b=checkBST(root);
        }
        static bool checkBST(HackerRankBinTree root)
        {
            return isBSTUtil(root,int.MinValue,int.MaxValue);
        }
        static bool isBSTUtil(HackerRankBinTree root,int min,int max)
        {
            if (root==null)
            {
                return true;
            }
            if (root.data<=min||root.data>=max)//Eşitlik halinde bu koşula girmesi duplication olduğu anlamına gelir.
            {
                return false;
            }
            return isBSTUtil(root.left, min, root.data) && isBSTUtil(root.right, root.data, max);
        }
        static HackerRankBinTree FindMin(HackerRankBinTree root)
        {
            HackerRankBinTree result = root;
            while (result.left != null)
            {
                result = result.left;
            }
            return result;
        }
        static HackerRankBinTree FindMax(HackerRankBinTree root)
        {
            HackerRankBinTree result = root;
            while (result.right!=null)
            {
                result = result.right;
            }
            return result;
        }
        
    }
}
