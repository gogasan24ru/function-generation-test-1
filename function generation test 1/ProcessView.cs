using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace function_generation_test_1
{
    public partial class Process : Form
    {
        private int EPSILON = 100;

        private bool pause = false;
        private int MAX_POPULATION = 50;
        private Graphics gr;
        private Tree tree;
        private List<List<argument>> source;
        private List<double> eqs;

        public Process(List<List<argument>> collection, List<double> equals)
        {
            eqs = equals;
            source = collection;
            InitializeComponent();
            tree = new Tree(collection[0].Count);
            PB_graph.Image = new Bitmap(PB_graph.Width, PB_graph.Height);
            gr = Graphics.FromImage(PB_graph.Image);
        }

        private void BTN_cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BTN_pause_Click(object sender, EventArgs e)
        {
            pause = !pause;
            BTN_cancel.BackColor = !pause ? Color.Green : Color.Red;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gr.Clear(Color.White);
            tree = genTree();
            tree.Draw(gr, new Point(PB_graph.Width/2, 10));

            PB_graph.Invalidate();
            PB_graph.Refresh();
            PB_graph.Update();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gr.Clear(Color.White);
            //tree.Mutate(gr, new Point(PB_graph.Width/2, 10), (new Random()).Next(1, 4));
            //tree.Draw(gr,new Point(PB_graph.Width/2,10));
            PB_graph.Invalidate();
            PB_graph.Refresh();
            PB_graph.Update();
            richTextBox1.Clear();
            richTextBox1.AppendText("D: " + tree.Depth() + "\n" + "S: " + tree.TreeRoot.Count() + "\n\n");
            label2.Text = (tree.TreeRoot.ToString() + "\n");
        }

        private void Process_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                PB_graph.Width = Width - Left;
                PB_graph.Height = Height - Top;
                PB_graph.Image = new Bitmap(PB_graph.Width, PB_graph.Height);
                gr = Graphics.FromImage(PB_graph.Image);

            }
            catch (Exception)
            {
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            gr.Clear(Color.White);
            richTextBox1.AppendText("Calc: " + tree.calculate(source[0]) + "\n\n");
            tree.Draw(gr, new Point(PB_graph.Width/2, 10));

            PB_graph.Invalidate();
            PB_graph.Refresh();
            PB_graph.Update();
            label2.Text = (tree.TreeRoot.ToString() + "\n");
        }

        private Tree currentTree = null;

        private void button4_Click(object sender, EventArgs e)
        {
            if (currentTree == null)
            {

                currentTree = new Tree(source[0].Count);
                currentTree.TreeRoot.mutate('O');
                currentTree.TreeRoot.n1.mutate('O');
                currentTree.TreeRoot.n2.mutate('O');
            }

            //currentTree.Draw(gr, new Point(PB_graph.Width/2, 200));



            //PB_graph.Invalidate();
            //PB_graph.Refresh();
            //PB_graph.Update();

            //MessageBox.Show("let's ROCK!");




            gr.Clear(Color.White);
            int lal = 150;
            currentTree.Draw(gr, new Point(PB_graph.Width/2, lal + 10));
            tree.Draw(gr, new Point(PB_graph.Width/2, 10));


            Tree[] childs = functions.crossTrees(tree, currentTree);
            //            Tree child = crossTrees(tree, currentTree);
            int t = 2;
            foreach (var child in childs)
            {
                child.Draw(gr, new Point(PB_graph.Width/2, 10 + lal*(t++)));
            }


            PB_graph.Invalidate();
            PB_graph.Refresh();
            PB_graph.Update();

            //tree = childs[0];
            //currentTree = childs[1];


        }

        public Tree crossTrees(Tree t1, Tree t2)
        {
            //            var child = new Tree(source[0].Count);

            var child = t1;

            List<Node> way = child.TreeRoot.Way(); //создание уникального маршрута
            List<Node> way2 = t2.TreeRoot.Way();

            int depth = functions.r.Next(1, child.Depth()); //случ число от 0 до максимальной глубины

            depth = Math.Min(depth, way.Count); //проверка подходит ли

            way[way.Count - depth] = way2[way2.Count - depth];
                //здесь не происходит копирования. фактически идет замена элемента в списке маршрута
            //            way[way.Count - depth] = way2[way2.Count - depth].Copy();

            return child;
        }

        private Tree genTree()
        {
            var currentTree = new Tree(source[0].Count);
            currentTree.TreeRoot.mutate('O');
            currentTree.TreeRoot.n1.mutate('O');
            currentTree.TreeRoot.n2.mutate('O');
            return currentTree;
        }

        private List<Tree> population;
        private DateTime partyBegin;
        private DateTime partyEnd;

        private void BTN_partyBegin_Click(object sender, EventArgs e)
        {
            partyBegin = DateTime.Now;
            /*
             * Описание процедуры работы системы
             * Индивид = дерево
             * Популяция = n деревьев
             * Случайно сгенерированные деревья проходят серию экспериментов по таблице равенств, заданной пользователми
             * -> В деревья подставляются аргументы. Вычисляется разность по модулю. Разности суммируются в рейтинг.
             * Индивид с наименьшим рейтингом доминирует. 
             * Производится скрещивание доминанта с остальными. Производится мутация.
             * Производятся эксперименты. Худшая половина популяции (n) уничтожается. Блаблабла. Все счастливы. 
             * 
             * */



            if (population == null)
            {

                population = new List<Tree>();
                for (int i = 0; i < MAX_POPULATION; i++) population.Add(genTree());
                //population create complete
            }
            pause = true;
            while (pause)
            {
                Iteration(population, MAX_POPULATION);
            }

            if ((partyEnd != null) && (partyBegin != null))
            {
                var deltaParty = partyEnd - partyBegin;
                MessageBox.Show(deltaParty.ToString() + " time gone.");
            }
            else MessageBox.Show("Smth wrong with dateTime operating. No data for you.");
        }

        private
            void Iteration(List<Tree> population, int MAX_POPULATION)
        {
            Application.DoEvents();
            //prepare population to cross...
            ratePopulation(population);

            if(pause&&false)
            {
                gr.Clear(Color.White);

                population[population.Count - 1].Draw(gr, new Point(PB_graph.Width / 2, 0 + 10));
                PB_graph.Invalidate();
                PB_graph.Refresh();
                PB_graph.Update();


            }


            var pop2 = new List<Tree>();
            Parallel.ForEach(population, individum =>
                                         //foreach (var individum in population)
                {
                    try
                    {
                        Application.DoEvents();
                        Tree[] temp = functions.crossTrees(population[population.Count - 1], individum);
                        pop2.Add(temp[0]);
                        pop2.Add(temp[1]);
                        if (!pause) return;
                    }
                    catch (Exception)
                    {
                    }
                    ;
                }
                )
                ;
            if (!pause) return;
            try
            {
                population.AddRange(pop2);

            }
            catch (Exception)
            {

                //throw;
            }
            //!!!
            //for (int k = 0; k < population.Count; k++)
            //    if ((population[k].Count() > 100) || (population[k].Depth() > 7) || (population[k].Count() > 50)) population[k] = genTree();

            //mutation
            for (int i = 0; i < MAX_POPULATION/15; i++)
                population[functions.r.Next(0, population.Count)].Mutate();
            if (!pause) return;
            ratePopulation(population);


            //population.RemoveRange(MAX_POPULATION, population.Count - MAX_POPULATION - 1);
            population.RemoveRange(0, population.Count - MAX_POPULATION - 1);

            gr.Clear(Color.White);
            //population[0].Draw(gr, new Point(PB_graph.Width/2, PB_graph.Height/2+10));

            if (!pause) return;
            population[population.Count - 1].Draw(gr, new Point(PB_graph.Width/2, 0 + 10));
            //population[population.Count - 1].Draw(gr, new Point(PB_graph.Width / 2, 0 + 10));

            for (int k = 0; k < population.Count; k++)
                if ((population[k].Count() > 100) /*|| (population[k].Depth() > 7)*/|| (population[k].Count() > 40))
                    population[k] = genTree();

            PB_graph.Invalidate();
            PB_graph.Refresh();
            PB_graph.Update();
            if (!pause) return;
            //label2.Text = population[0].ToString();
            //richTextBox1.Clear();
            richTextBox1.AppendText("Badest:\nD: " + population[0].Depth() + "\nS: " + population[0].Count() + "\nR:" +
                                    population[0].calculate(source[0]));
            richTextBox1.AppendText("\n" + (++iterations) + " iterations\n");
            label2.Text = iterations + " iteratons complete.";
            Application.DoEvents();
        }

        private int iterations = 0;

        private void ratePopulation(List<Tree> population)
        {
            Parallel.ForEach(population, individum =>
                                         //  foreach (var individum in population)
                {
                    //try
                    {
                        int Ieq = 0;
                        individum.raiting = 0;
                        Parallel.ForEach(source, arguments =>
                                                 //foreach (var arguments in source)
                            {
                                Application.DoEvents();
                                if (arguments.Count != 0) //== break;
                                {

                                    if (!pause) return;
                                    individum.raiting += Math.Abs(eqs[Ieq++] -
                                                                  individum.calculate(arguments));
                                    //individum.raiting += individum.Count() + individum.Depth();
                                }
                            }
                            )
                            ;
                    }
                    //catch (Exception) { }
                });
            population.Sort(functions.Sort);
            //int fixer = individum.Count() + individum.Depth();
            int fixer = 0;
            if (Math.Abs(population[population.Count - 1].raiting - fixer) < (EPSILON))
            {
                pause = false;
                partyEnd = DateTime.Now;
                gr.Clear(Color.White);
                //population[0].Draw(gr, new Point(PB_graph.Width/2, PB_graph.Height/2+10));

                population[population.Count - 1].Draw(gr, new Point(PB_graph.Width / 2, 0 + 10));
                //population[population.Count - 1].Draw(gr, new Point(PB_graph.Width / 2, 0 + 10));


                PB_graph.Invalidate();
                PB_graph.Refresh();
                PB_graph.Update();
                MessageBox.Show("Solution found: " + population[population.Count - 1].TreeRoot.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.Enabled = false;
            //int MAX_POPULATION = 50;

            if (population == null)
            {

                population = new List<Tree>();
                for (int i = 0; i < MAX_POPULATION; i++) population.Add(genTree());
                //population create complete
            }
            //pause = true;
            {
                Iteration(population, MAX_POPULATION);
            }
            //
            MessageBox.Show(population.Count.ToString());
            button5.Enabled = true;
        }


        private void button6_Click(object sender, EventArgs e)
        {
            population = null;
        }
    }

}