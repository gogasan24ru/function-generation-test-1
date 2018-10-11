using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace function_generation_test_1
{
    internal class functions
    {
        public static int Sort(Tree x, Tree y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    // If x is null and y is null, they're
                    // equal. 
                    return 0;
                }
                else
                {
                    // If x is null and y is not null, y
                    // is greater. 
                    return 1;
                }
            }
            else
            {
                // If x is not null...
                //
                if (y == null)
                // ...and y is null, x is greater.
                {
                    return -1;
                }
                else
                {
                    // ...and y is not null, compare the 
                    // lengths of the two strings.
                    //
                    int retval = x.raiting.CompareTo(y.raiting);

                    if (retval != 0)
                    {
                        // If the strings are not of equal length,
                        // the longer string is greater.
                        //
                        return -retval;
                    }
                    else
                    {
                        // If the strings are of equal length,
                        // sort them with ordinary string comparison.
                        //
                        return -x.raiting.CompareTo(y.raiting);
                    }
                }
            }
        }
public static string[] ColourValues = new string[] { 
        "FF0000", "00FF00", "0000FF", "FFFF00", "FF00FF", "00FFFF", "000000", 
        "800000", "008000", "000080", "808000", "800080", "008080", "808080", 
        "C00000", "00C000", "0000C0", "C0C000", "C000C0", "00C0C0", "C0C0C0", 
        "400000", "004000", "000040", "404000", "400040", "004040", "404040", 
        "200000", "002000", "000020", "202000", "200020", "002020", "202020", 
        "600000", "006000", "000060", "606000", "600060", "006060", "606060", 
        "A00000", "00A000", "0000A0", "A0A000", "A000A0", "00A0A0", "A0A0A0", 
        "E00000", "00E000", "0000E0", "E0E000", "E000E0", "00E0E0", "E0E0E0", 
    };
        public static Random r = new Random();
        //    public Font font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        private data_input formLink;

        /// <summary>
        /// Perform a deep Copy of the object.
        /// </summary>
        /// <typeparam name="T">The type of object being copied.</typeparam>
        /// <param name="source">The object instance to copy.</param>
        /// <returns>The copied object.</returns>
        public static T Clone<T>(T source)
        {
            if (!typeof (T).IsSerializable)
            {
                throw new ArgumentException("The type must be serializable.", "source");
            }

            // Don't serialize a null object, simply return the default for that object
            if (Object.ReferenceEquals(source, null))
            {
                return default(T);
            }

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            using (stream)
            {
                formatter.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);
                return (T) formatter.Deserialize(stream);
            }
        }

        public static void DrawCircle(Graphics g, Pen p, int X, int Y, int R)
        {
            g.FillRectangle(Brushes.White, X - R/2, Y - R/2, R, R);
            //g.DrawRectangle(p, X - R / 2, Y - R / 2, R, R);
            g.DrawEllipse(p, X - R/2, Y - R/2, R, R);
        }


        public static void noise()
        {
            //var buf = new byte[4];
            //var rand = new System.Security.Cryptography.RNGCryptoServiceProvider(new CspParameters());
            //rand.GetBytes(buf);
            //rand.GetBytes(buf);
            //int randomValue = BitConverter.ToInt32(buf, 0);
            //rand.Dispose();
        }

        public static char getRandomArgumentName(int k)
        {

            noise();
            noise();
            //MessageBox.Show(randomValue.ToString());

            char a = 'A';
            a = (char) ((int) a + r.Next(0, k));
            return a;
        }

        public static Tree[] crossTrees(Tree t1, Tree t2)
        {
            var child1 = Clone(t1);
            var child2 = Clone(t2);


            //var child1 = (Tree)t1.Clone();
            //var child2 = (Tree)t1.Clone();


            Tree [] ret=new Tree[2];
            int MAX_DEPTH = 1+Math.Max(t1.Depth(),t2.Depth());
            int depth1 = 0, depth2 = 0;


            //MAX_DEPTH = 100;
            depth1 = functions.r.Next(1, MAX_DEPTH);
            depth2 = r.Next(1, MAX_DEPTH);

            if (depth1 > MAX_DEPTH) depth1 = MAX_DEPTH;
            if (depth2 > MAX_DEPTH) depth2 = MAX_DEPTH;

            List<Node> w1 = child1.TreeRoot.Way();
            List<Node> w2 = child2.TreeRoot.Way();

            int depthFilter = 0;
            if (depth1 > w1.Count) depth1 = w1.Count - depthFilter;
            if (depth2 > w2.Count) depth2 = w2.Count - depthFilter;


            ////lalka hardcode
            //depth1 = 2;
            //depth2 = 2;
            ////eoh
            //depth1--;
            //depth2--;


            //genomes
            Node g1 = w1[w1.Count - depth1];
            Node g2 = w2[w2.Count - depth2];

            if ((g1.WayLoRs == 'C') && (g2.WayLoRs == 'C')) //both genomes are treeRoots.
            {
                ((Tree)(g1.parent)).TreeRoot = g2;
                ((Tree)(g2.parent)).TreeRoot = g1;
            }
            else  //genomes both are not treeRoots.
            {
                if ((g1.WayLoRs == 'C') && (g2.WayLoRs != 'C'))
                {
                    ((Tree)(g1.parent)).TreeRoot = g2;
                    switch (g2.WayLoRs)
                    {
                        case 'R':
                            {
                                ((Node) g2.parent).n2 = g1;
                                break;
                            }
                        case 'L':
                            {
                                ((Node)g2.parent).n1 = g1;
                                break;
                            }
                    }
                }
                else if ((g1.WayLoRs != 'C') && (g2.WayLoRs == 'C'))
                {
                    ((Tree)(g2.parent)).TreeRoot = g1;
                    switch (g1.WayLoRs)
                    {
                        case 'R':
                            {
                                ((Node)g1.parent).n2 = g2;
                                break;
                            }
                        case 'L':
                            {
                                ((Node)g1.parent).n1 = g2;
                                break;
                            }
                    }
                }
                else if ((g1.WayLoRs != 'C') && (g2.WayLoRs != 'C'))
                {
                    if (g1.WayLoRs == 'R')
                    {
                        ((Node)g1.parent).n2 = g2;
                    }
                    else { ((Node)g1.parent).n1 = g2; }
                    if (g2.WayLoRs == 'R')
                    {
                        ((Node)g2.parent).n2 = g1;
                    }
                    else
                    {
                        ((Node)g2.parent).n1 = g1;
                    }
                }
            }
            g1.crossed++;
            g2.crossed++;


            //w2[w2.Count - depth2].crossed++;
            //w1[w1.Count - depth1].crossed++;

#region SHIT
            if (false)
            if ((w1[w1.Count - depth1].parent != null) && (w2[w2.Count - depth2].parent != null))
            {

                Node temp = w1[w1.Count - depth1];
                //|| (w1[w1.Count - depth1].WayLoRs=='C')
                if ((w1[w1.Count - depth1].WayLoRs == 'R'))
                {
                    ((Node) (w1[w1.Count - depth1].parent)).n2 = w2[w2.Count - depth2];
                    w1[w1.Count - depth1].parent = w2[w2.Count - depth2].parent;
                }
                else if ((w1[w1.Count - depth1].WayLoRs == 'L'))
                {

                    ((Node) (w1[w1.Count - depth1].parent)).n1 = w2[w2.Count - depth2];
                    w1[w1.Count - depth1].parent = w2[w2.Count - depth2].parent;
                }
                else if ((w1[w1.Count - depth1].WayLoRs == 'C'))
                {

                    ((Tree)(w1[w1.Count - depth1].parent)).TreeRoot = w2[w2.Count - depth2];

                    if (w2[w2.Count - depth2].WayLoRs == 'C')
                        ((Tree)(w1[w1.Count - depth1].parent)).TreeRoot = ((Tree)(w2[w2.Count - depth2].parent)).TreeRoot;
                    else
                    ((Tree)(w1[w1.Count - depth1].parent)).TreeRoot = (Node)w2[w2.Count - depth2].parent;
                }

                if (w2[w2.Count - depth2].WayLoRs == 'R')
                {
                    ((Node) (w2[w2.Count - depth2].parent)).n2 = temp;
                    w2[w2.Count - depth2].parent = temp.parent;
                }
                else if (w2[w2.Count - depth2].WayLoRs == 'L')
                {
                    ((Node) (w2[w2.Count - depth2].parent)).n1 = temp;
                    w2[w2.Count - depth2].parent = temp.parent;
                }
                else
                    if (w2[w2.Count - depth2].WayLoRs == 'C')
                    {
                        ((Tree)(w2[w2.Count - depth2].parent)).TreeRoot = temp;
                        if ((w1[w1.Count - depth1].WayLoRs == 'C'))
                            ((Tree)(w2[w2.Count - depth2].parent)).TreeRoot=((Tree)temp.parent).TreeRoot;
                        else
                        ((Tree)(w2[w2.Count - depth2].parent)).TreeRoot = (Node)temp;//.parent
                    }


                w2[w2.Count - depth2].crossed++;
                w1[w1.Count - depth1].crossed++;
                //w2[w2.Count - depth2].parent.crossed++;
                //w1[w1.Count - depth1].parent.crossed++;

            }
#endregion
            //Node n2 = Clone(w2[w2.Count - depth2]);
            //Node temp = w1[0];
            //w1[0] = w2[0];
            //w2[0] = temp;
            int k = 0;
            if (child1.Count() == child2.Count())
                k++;
            ret[0] = child1;
            ret[1] = child2;
            //w2[w2.Count - depth2] = n1;
            //w1[w1.Count - depth1] = n2;
            return ret;
            // seems ok... 
        }
    }


    [Serializable]
    public class Tree
    {

        public Tree Clone()
        {
            return new Tree(vc,TreeRoot.Clone(null)){raiting=raiting};
        }

        private Tree()
        {
        }

        public Node TreeRoot;
        public double raiting = 0;
        public int vc;

        public Tree(int varCount, Node root = null)
        {
            vc = varCount;
            if (root == null)
            {
//                Node fakeRoot=null;
                TreeRoot = new Node('O', varCount, this, 'C');
//                fakeRoot=new Node('O',varCount,null,'C'){n1=TreeRoot,n2=TreeRoot};
            }
            else
            {
                TreeRoot = root;
                TreeRoot.parent = this;
                TreeRoot.WayLoRs = 'C';
            }
        }

        public void Draw(Graphics g, Point p, int id = 0)
        {
            TreeRoot.Draw(g, p, Color.Black, id);
            g.DrawString(TreeRoot.ToString(),
                            new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold,
                                                    System.Drawing.GraphicsUnit.Point, ((byte)(204))),
                            new SolidBrush(Color.Black), p.X+30, p.Y);

            g.DrawString(raiting.ToString(),
                            new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold,
                                                    System.Drawing.GraphicsUnit.Point, ((byte)(204))),
                            new SolidBrush(Color.Black), p.X + 30, p.Y+20);
        }

        public double calculate(List<argument> source)
        {
            foreach (var argument in source)
            {
                foreach (var argument1 in TreeRoot.find(argument.name))
                {
                    argument1.applyValue(argument.value);
                }
            }
            return TreeRoot.process();
        }

        /// <summary>counts maximal depth of tree
        /// 
        /// </summary>
        /// <returns></returns>
        public int Depth()
        {
            return TreeRoot.Depth();

        }

        public int Count()
        {
            return TreeRoot.Count();

        }

        /// <summary> Calls tree mutation
        /// Mutates random direction at depth steps.
        /// </summary>
        /// <param name="depth">count nodes from end to mutate at random direction</param>
        public void Mutate(int depth = 1)
        {
            /* STAGES:
             * 1. Find Node to mutate
             * 2. Mutate this Node!
             * 3. If Node is A type -> 
             *      a. Change argumetn (X -> Y, for example)
             *      b. Move Node to O type, randomize operation at O-Node, apply random arguments/operations to nexts.
             *    If Node is O type ->
             *      a. Randomize operation.
             *      b. Mutate arguments-nodes.
             */
            //TODO Fuck this.Mutate();
            depth = 2;
            if (depth > Depth()) depth = Depth(); //fuck NO!!!1
            //depth = 1
            ;
            //chose randdom way..
            var way = TreeRoot.Way(); //OHYETb
            if (depth > way.Count) depth = way.Count;
            way[way.Count - depth].mutate(); //dat power of oop. Bitches.
            //drawMutation(way[way.Count - depth].id);
            //Draw(g, p, way[way.Count - depth].id);
            //        way[way.Count-depth].Draw(g,p,Color.Red);
            //            TreeRoot.mutate(); //what??? it will call all tree mutate. Not good, moterfucka. \m/

        }


    }

    [Serializable]
    //[I]
    public class Node 
    {
        public Node Clone(object caller)
        {
            switch (type)
            {
                case 'A':
                    {
                        return new Node
                            {
                                crossed = crossed,
                                id = id,
                                n1 = null,
                                n2 = null,
                                parent = parent,
                                type = 'A',
                                value = ((argument) value).Clone(this),
                                vc = vc,
                                WayLoRs = WayLoRs
                            };

                    }
                case 'O':
                    {
                        return new Node
                            {
                                crossed = crossed,
                                id = id,
                                n1 = n1.Clone(this),
                                n2 = n2.Clone(this),
                                parent = caller,
                                type = 'O',
                                value = ((Operation) value).Clone(this),
                                vc = vc,
                                WayLoRs = WayLoRs
                            };
                    }
                default:
                    return null;
            }
        }

        public char type; //A for argument, O for operation
        public Node n1, n2;
        public object value;
        public int vc;
        
        public int id;
        public object parent;
        public int crossed = 0;
        public char WayLoRs; //n1-L or n2-R, C for tree root

        public new string ToString()
        {
            switch (type)
            {
                case 'A':
                    {
                        return ((argument) value).ToString();
                        break;
                    }
                case 'O':
                    {
                        return "(" + n1.ToString() + " " + ((Operation) value).type.ToString() + " " + n2.ToString() +
                               ")";
                        break;
                    }
            }
            return "Lalka dont waited!111";
        }

        private Node(){}//ONL FOR INTERNAL USE!

        public Node(char t, int varCount,object p, char wayLoR)
        {
            id = (int) (functions.r.NextDouble()*10000);
            type = t;
            vc = varCount;
            parent = p;
            WayLoRs = wayLoR;
            //if (WayLoRs == 'C')
            //{
            //    parent = new Node('A', 10, null, 'R') { n1 = this, n2 = this };
            //    WayLoRs = 'R';
            //}
            switch (t)
            {
                case 'A':
                    {
                        value = new argument(functions.getRandomArgumentName(varCount));
                        n1 = null;
                        n2 = null;
                        break;
                    }
                case 'O':
                    {
                        value = new Operation();
                        n1 = new Node('A', varCount,this,'L');
                        n2 = new Node('A', varCount,this,'R');
                        break;
                    }
            }
        }

        public double process()
        {
            switch (type)
            {
                case 'A':
                    {
                        return ((argument) value).value;
                    }
                case 'O':
                    {
                        
                        return ((Operation) value).operate(n1.process(), n2.process());
                    }
            }
            return 0;
        }

        int iters=1000;
        public void mutate(char t = 'N')
        {
            functions.noise();
            int rand = functions.r.Next(0, 100);
            //MessageBox.Show(rand.ToString());
            functions.noise();
            if (t == 'O') rand = 49;
            else if (t == 'A') rand = 51;
            if (iters-- < 1) {
                t = 'N';
                iters = 1000;
            }
            if (rand > 50) //a
            {
                if (type == 'O')
                {
                    type = 'A';
                    value = new argument(functions.getRandomArgumentName(vc));
                    n1 = null;
                    n2 = null;
                }
                else
                {
                    ((argument) value).mutate(vc);
                }

            }
            else
            {
                if (type == 'A')
                {
                    type = 'O';
                    n1 = new Node('A', vc,this,'L');
                    n2 = new Node('A', vc,this,'R');
                    value = new Operation();
                }
                else
                {

                    ((Operation) value).mutate();
                    n1.mutate(t);
                    n2.mutate(t);
                }
            }


        }

        public List<argument> find(char n)
        {
            var ret = new List<argument>();
            if (type == 'O')
            {
                ret.AddRange(n1.find(n));
                ret.AddRange(n2.find(n));
            }
            else
            {
                if (((argument) value).name == n)
                    ret.Add((argument) value);
            }
            return ret;
        }

        public int Count()
        {
            int count = 1;
            if (type == 'O')
            {
                count += n1.Count();
                count += n2.Count();
            }
            return count;
        }

        public int Depth()
        {
            int depth = 1;

            if (type == 'O')
            {
                //int temp1 = n1.Depth();
                //int temp2 = n2.Depth();
                //if (temp1 > temp2) depth += temp1;
                //else depth += temp2;
                depth += Math.Max(n1.Depth(), n2.Depth());
            }
            return depth;
        }

        public List<Node> Way()
        {
            List<Node> ret = new List<Node>();
            ret.Add(this);
            if (type == 'O')
            {

                functions.noise();
                int rand = functions.r.Next(0, 100);
                functions.noise();
                //  MessageBox.Show(rand.ToString());
                if (rand > 50)
                {
                    ret.AddRange(n1.Way());
                }
                else
                {
                    ret.AddRange(n2.Way());
                }

            }
            return ret;
        }

        public void Draw(Graphics g, Point a, Color c, int i)
        {
            var pen = new Pen(c,1);
            if (id == i) c = Color.Red;
            if (crossed > 0)
            {//c = Color.LimeGreen;

                if (crossed > functions.ColourValues.Length) crossed = 1;
            c = System.Drawing.ColorTranslator.FromHtml("#"+functions.ColourValues[crossed-1]);
                
            pen = new Pen(c,2);
            }
            //else {c = Color.Black;
            //pen = new Pen(c,1);
            //}
            //           else c = Color.Black;

            int fontNoise = 5;




            //g.DrawString(id.ToString(),
            //                 new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold,
            //                                         System.Drawing.GraphicsUnit.Point, ((byte)(204))),
            //                 new SolidBrush(c), a.X - fontNoise, a.Y+10 - fontNoise);


            if (type == 'A')
            {
                functions.DrawCircle(g, pen, a.X, a.Y, 15);
                g.DrawString(((argument) value).name.ToString(),
                             new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold,
                                                     System.Drawing.GraphicsUnit.Point, ((byte) (204))),
                             new SolidBrush(c), a.X - fontNoise, a.Y - fontNoise);
                g.DrawString(((argument) value).value.ToString("#.###"),
                             new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold,
                                                     System.Drawing.GraphicsUnit.Point, ((byte) (204))),
                             new SolidBrush(c), a.X - fontNoise, a.Y + 15 - fontNoise);
            }
            else
            {

                var kx = 30;
                var ky = 30;
                g.DrawLine(pen, a.X, a.Y, a.X - kx * n1.Count(), a.Y + ky /* n1.Count()*/);
                g.DrawLine(pen, a.X, a.Y, a.X + kx * n2.Count(), a.Y + ky /* n2.Count()*/);

                n1.Draw(g, new Point(a.X - kx * n1.Count(), a.Y + ky /* n1.Count()*/), c, i);

                n2.Draw(g, new Point(a.X + kx * n2.Count(), a.Y + ky /* n2.Count()*/), c, i);

                functions.DrawCircle(g, pen, a.X, a.Y, 15);

                g.DrawString(((Operation) value).type.ToString(),
                             new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold,
                                                     System.Drawing.GraphicsUnit.Point, ((byte) (204))),
                             new SolidBrush(c), a.X - fontNoise, a.Y - fontNoise);
                g.DrawString(this.process().ToString("#.###"),
                             new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold,
                                                     System.Drawing.GraphicsUnit.Point, ((byte) (204))),
                             new SolidBrush(c), a.X - fontNoise, a.Y + 15 - fontNoise);
            }
        }
    }

    [Serializable]
    public class Operation
    {
        private Operation(){}

        public Operation Clone(object caller)
        {
            return new Operation {type=type};
        }
        private Random r = functions.r;
        public char type; // variants: + - * / > <

        public void mutate()
        {
            functions.noise();
            switch (r.Next(0, 3))
            {
                case 0:
                    {
                        type = '+';
                        break;
                    }
                case 1:
                    {
                        type = '-';
                        break;
                    }
                case 2:
                    {
                        type = '*';
                        break;
                    }
                //case 3:
                //    {
                //        type = '/';
                //        break;
                //    }
                //case 4:
                //    {
                //        type = '<';
                //        break;
                //    }
                //case 5:
                //    {
                //        type = '>';
                //        break;
                //    }
            }
        }

        public double operate(double a, double b)
        {
            switch (type)
            {
                case '+':
                    {
                        return a + b;
                    }
                case '-':
                    {
                        return a - b;
                    }
                case '*':
                    {
                        return a*b;
                    }
                //case '/':
                //    {
                //        try
                //        {
                //            return a / b;
                //        }
                //        catch
                //        {
                //            return double.MaxValue;
                //        }
                //    }
                //case '<':
                //    {
                //        return Math.Min(a, b);
                //    }

                //case '>':
                //    {
                //        return Math.Max(a, b);
                //    }
                default:
                    {
                        return 0;
                    }
            }
        }

        public Operation(char t = 'n')
        {
            if (t != 'n')
                type = t;
            else
                mutate();
        }

    }


    [Serializable]
    public class argument
    {
        public argument Clone(object caller)
        {
            return new argument(name) {value = value};
        }

        public double value;
        public char name;

        public string ToString()
        {
            return name.ToString();
        }

        public argument(char n)
        {
            name = n;
        }

        public void mutate(int vc)
        {
            name = functions.getRandomArgumentName(vc);
        }

        public void applyValue(double v)
        {
            value = v;
        }
    }



    [Serializable]
    public class Point
    {
        public int X, Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}