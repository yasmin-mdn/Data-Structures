using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A8
{
    public class Q2TreeHeight : Processor
    {
        public Q2TreeHeight(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public long Solve(long nodeCount, long[] tree)
        {   Node[] nodes=new Node[nodeCount];
            Node root=new Node();
           for(int i = 0; i< nodeCount ;i++) {
               nodes[i]=new Node(i);
           }
           for(int i = 0; i< nodeCount ;i++) {
               if(tree[i]==-1){
                    root=nodes[i];
               }
               else{
                   nodes[tree[i]].addChild(nodes[i]);
               }
               
           }
           Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);
            var height = 0;
            while( q.Count!=0){
                 var size = q.Count;
                if (size > 0)
                    height = height + 1;
                for(int j=0; j<size;j++) {
                    var  item = q.Dequeue();
                    foreach(var i in item.children){
                        q.Enqueue(i);
                    }
                        
                }
                   
            }
               
            return height;
  
        }
    }


    public class Node{
       public List<Node> children;
        int index;

        public Node()
        {
        }

        public Node(int i)
        {
            children=new List<Node>();
            this.index=i;
        }

        public void addChild(Node child){
            children.Add(child);
        }

        
    }
}
