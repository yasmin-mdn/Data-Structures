using System.Collections.Generic;

namespace C8
{
    class DisjointSets
    {
        int[] parent;
        int n;
        public DisjointSets(int n)
        {
            this.n = n;
            parent = new int[n];
            makeSet();
        }

        public void makeSet()
        {
            for (int i = 0; i < this.n; i++)
            {
                parent[i] = i;
            }
        }

        public int find(int x)
        {
            if (parent[x] != x)
            {

               parent[x]= find(parent[x]);
            }
           return parent[x];
        }

        public void union(int x, int y)
        {
            int irep = this.find(x);

            int jrep = this.find(y);
            if(irep<jrep){
                this.parent[jrep] = irep;
            }
            else if(irep>jrep){
                this.parent[irep] = jrep;
            }
            
        }
    }
}
