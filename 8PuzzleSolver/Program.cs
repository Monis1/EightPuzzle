using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8pleSolver
{
    enum position
    {
        left,right,up,down,nop
    };
   
    class Program
    {
        static void Main(string[] args)
        {
            char[,] arr = { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '_', '8' } };
            node n1 = new node(null, arr);

            game g1 = new game(n1);

            node temp=g1.run();
            while (temp != null)
            { temp.display();
            temp = temp.parent;
            }
        }
    }

    class game
    {
        node root;
        int i, j;
        public game(Object root)
        {
            this.root = (node)root;
        
        }

        public node run()
        {
            Queue<node> queue = new Queue<node>();
            node cnode,solution;
            queue.Enqueue(root);
            char[,] temp = new char[3, 3];
            
            while (true)
            {
                
                cnode = queue.Dequeue();
              
                temp = move(position.up, cnode.ple);
            
              
                if (temp != null && cnode.current != position.down)
                {
                    cnode.ple[i - 1, j] = cnode.ple[i, j];
                    cnode.ple[i, j] = '_';  
                    node newp = new node(cnode, temp);

                    if (compare(newp.ple))
                    {
                       solution= newp;
                        cnode.children.Add(newp);
                        return newp;
                    }
                    newp.current = position.up;
                    cnode.children.Add(newp);
                    queue.Enqueue(newp);



                    

                }
                temp = null;
                temp = move(position.down, cnode.ple);
                if (temp != null && cnode.current != position.up)
                {
                    cnode.ple[i+1, j] = cnode.ple[i , j];
                    cnode.ple[i + 1, j] = '_';
                   
                    node newp = new node(cnode, temp);
                    if (compare(newp.ple))
                    {
                        solution = newp;
                        cnode.children.Add(newp);
                        return newp;
                    }
                    newp.current = position.down;
                    cnode.children.Add(newp);
                    queue.Enqueue(newp);

                  


                }
                temp = null;
                temp = move(position.left, cnode.ple);
                if (temp != null && cnode.current != position.right)
                {
                    cnode.ple[i, j-1] = cnode.ple[i, j ];
                   cnode.ple[i, j ] = '_';
                   
                    node newp = new node(cnode, temp);
                    if (compare(newp.ple))
                    {
                        solution = newp;
                        cnode.children.Add(newp);
                        return newp;
                    }
                    newp.current = position.left;
                    cnode.children.Add(newp);
                    queue.Enqueue(newp);
                  

                }
                temp = null;
                temp = move(position.right,cnode.ple);
                if (temp != null && cnode.current != position.left)
                {

                    cnode.ple[i, j+1] = cnode.ple[i, j ];
                    cnode.ple[i, j ] = '_';
                    node newp = new node(cnode, temp);
                    if (compare(newp.ple))
                    {
                        solution = newp;
                        cnode.children.Add(newp);
                        return newp;
                    }
                    newp.current = position.right;
                    cnode.children.Add(newp);
                    queue.Enqueue(newp);
                   

                }
               
               

            }
          
        }
        public bool compare(char[,] p1)
        {
            char[,] p2 = { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '_' } };
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (p1[i, j] != p2[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public  char[,] move(position pos, char[,] p)
        {
             i = 0; j = 0;int flag = 0;
            try
            {
                if (pos == position.down)
                {
                    for (i = 0; i <= 2; i++)
                    {
                        for (j = 0; j <= 2; j++)
                        {
                            if (p[i, j] == '_')
                            {
                                flag = 1;
                                break;
                            }


                        }
                        if (flag == 1)
                            break;

                    }

                    p[i, j] = p[i + 1, j];
                    p[i + 1, j] = '_';
                }
                else if (pos == position.up)
                {
                    for (i = 0; i <= 2; i++)
                    {
                        for (j = 0; j <= 2; j++)
                        {
                            if (p[i, j] == '_')
                            {
                                flag = 1;
                                break;
                            }
                        }
                        if (flag == 1)
                            break;

                    }

                    p[i, j] = p[i - 1, j];
                    p[i - 1, j] = '_';
                }
                else if (pos == position.left)
                {
                    for (i = 0; i <= 2; i++)
                    {
                        for (j = 0; j <= 2; j++)
                        {
                            if (p[i, j] == '_')
                            {
                                flag = 1;
                                break;
                            }
                        }
                        if (flag == 1)
                            break;
                    }
                    p[i, j] = p[i, j - 1];
                    p[i, j - 1] = '_';
                }
                else if (pos == position.right)
                {
                    for (i = 0; i <= 2; i++)
                    {
                        for (j = 0; j <= 2; j++)
                        {
                            if (p[i, j] == '_')
                            {
                                flag = 1;
                                break;
                            }
                        }
                        if (flag == 1)
                            break;

                    }




                    p[i, j] = p[i, j + 1];
                    p[i, j + 1] = '_';
                }
            }
            catch
            {
                return null;
            }

            return p;
        }


    }

    class node
    {
        public node parent;
public        char[,] ple;

 
        public position current;
        public List<node> children;
        public node(node parent, char[,] ple)
        {
            this.parent = parent;
            this.ple = ple;
            current = position.nop;
            children = new List<node>();

        }
        public void display()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(ple[i, j] + " ");
                }
                Console.WriteLine();
            }
        }


    }
}  






    

