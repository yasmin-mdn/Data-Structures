using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;
using System.Diagnostics.CodeAnalysis;
using Priority_Queue;

namespace C10
{
    public class Q1Huffman : Processor
    {
        public Q1Huffman(string testDataName) : base(testDataName) {
        }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string,string>)Solve);

        public Dictionary<char, int> GenerateDict(string s)
        {
            Dictionary<char, int> dict=new Dictionary<char, int>();
            foreach(var c in s){
                if(dict.ContainsKey(c)){
                    dict[c]++;
                }
                else{
                    dict.Add(c,1);
                }
            }
            return dict;
        }

        public string Solve(string s)
        {
            Dictionary<char, int> leaves=GenerateDict(s);
            SimplePriorityQueue<Node,Node> nodes=new SimplePriorityQueue<Node, Node>();
            foreach(var leaf in leaves.Keys){
                Node n = new Node(leaf,leaves[leaf]);
                n.left=null;
                n.right=null;
                nodes.Enqueue(n,n);
             }

           while(nodes.Count >=2 ){
            Node n1=nodes.Dequeue();
            Node n2=nodes.Dequeue();
            Node parent=new Node('$',n2.left.freq+n1.right.freq);
            parent.left=n1;
            parent.right=n2;
            nodes.Enqueue(parent,parent);
           }
            Node root=nodes.Dequeue();
             Dictionary<char, string> codewords=new Dictionary<char, string>();
             GeneratecodeWords(root,"",codewords);
             StringBuilder stringBuilder=new StringBuilder();
             foreach(char c in s){
                 stringBuilder.Append(codewords[c]);
             }
            return stringBuilder.ToString();
        }

        private void GeneratecodeWords(Node root, string v,Dictionary<char, string> codewords)
        {
            if(root!=null){
                if(root.chr=='$'){
                    codewords.Add(root.chr,v);
                    GeneratecodeWords(root.left,v+'0',codewords);
                    GeneratecodeWords(root.right,v+'1',codewords);


                }
            }
        }
    }
}
