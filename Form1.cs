using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace крестики_нолики
{
    public partial class Form1 : Form
    {
        public bool qwe = false;
        public bool pervhod = true;  //true говорит о том, что у ИИ нынче первый ход. первым ходом компьютер должен ходить в
                                   //центр, дальше по ситуации. значение false переправляет на путь "дальше по ситуации"
        public bool first = true;   //меняется на false сразу после первого хода юзера, который играет крестиками, нужен для проверки, был ли
                                  // первый ход в центр или нет
        public int cherta = 0;   // черта для вычеркивания выигрышной комбинации
        public int x = -1;
        public int y = -1;
        public int xfir = -1; // первый ход юзера
        public int yfir = -1; // когда он играет крестиками
        public int xlast = -1;//последний
        public int ylast = -1;// ход юзера
        public int win = 0;//если 1- выиграл ИИ, 2-пользователь, 3- ничья
        public bool hdpc = false;//true - сейчас ход ИИ, false - ход пользователя
        public int pc = 0;     // кто ходит первым, 1 - ходит ИИ, 2 первый ходит юзер
        public int[,] a = new int[3, 3];   //если равен 0 пустая клетка, равен 1 - был сделан ход ИИ, 2 - ход юзера
        public Form1()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 0; j++)
                {
                    a[i, j] = 0;
                }
            }
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            qwe = true;
            if (pc == 0)  // ИИ равен 0 тогда, когда пользователь еще не выбрал кто будет ходить первым
            {
               label1.Text="Выберите игрока, который будет ходить первым!";
            }
            else
            {
                if (pc == 1)  //первый ход ИИ
                {
                    hdpc = true;
                    hod1();
                    radioButton1.Visible = false;
                    radioButton2.Visible = false;
                }
                else     //первый ход пользователя
                {
                    hdpc = false;
                    label1.Text = "Ваш ход!";
                    radioButton1.Visible = false;
                    radioButton2.Visible = false;
                }
            }
        }    

        private void panel1_Paint(object sender, PaintEventArgs e)
        { // делит игровое поле на клетки-координаты, между которыми возможна черта при чьей-либо победе 
            Graphics gPanel = panel1.CreateGraphics();
            Pen p = new Pen(Color.Blue, 1);
            Pen p1 = new Pen(Color.Blue, 2);
            gPanel.DrawLine(p, new Point(0, 0), new Point(300, 0));
            gPanel.DrawLine(p, new Point(300, 0), new Point(300, 300));
            gPanel.DrawLine(p, new Point(0, 0), new Point(0, 300));
            gPanel.DrawLine(p, new Point(0, 300), new Point(300, 300));
            gPanel.DrawLine(p1, new Point(100,0), new Point(100, 300));
            gPanel.DrawLine(p1, new Point(200, 0), new Point(200, 300));
            gPanel.DrawLine(p1, new Point(0, 100), new Point(300, 100));
            gPanel.DrawLine(p1, new Point(0, 200), new Point(300, 200));
        }  

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (qwe)
            {
                if (pc == 0)  //если пользователь сразу нажимает на доску, не выбрав кто будет ходить первым
                {
                    label1.Text = "Выберите игрока, который будет ходить первым!";
                }
                else
                {
                    if (hdpc == false)   //ход пользователя
                    {
                        if (pc == 2)    //первый ход пользователя, значит он играет крестиками
                        {
                            if (e.Location.X > 0 && e.Location.X < 100 && e.Location.Y > 0 && e.Location.Y < 100)  //1 ячейка
                            {

                                if (a[0, 0] == 0) //если выбирается пользователем первая ячейка, то проверка пустая ячейка или нет
                                {
                                    Graphics gPanel = panel1.CreateGraphics();
                                    Pen p = new Pen(Color.Black, 3);
                                    gPanel.DrawLine(p, 2, 2, 98, 98);
                                    gPanel.DrawLine(p, 98, 2, 2, 98);
                                    a[0, 0] = 2;
                                    xlast = 0;
                                    ylast = 0;
                                    first = false;
                                }
                                else
                                {
                                    label1.Text = "Ячейка уже занята";
                                }
                            }

                            if (e.Location.X > 100 && e.Location.X < 200 && e.Location.Y > 0 && e.Location.Y < 100)//2 ячейка
                            {
                                if (a[1, 0] == 0)
                                {
                                    Graphics gPanel = panel1.CreateGraphics();
                                    Pen p = new Pen(Color.Black, 3);
                                    gPanel.DrawLine(p, 102, 2, 198, 98);
                                    gPanel.DrawLine(p, 198, 2, 102, 98);
                                    a[1, 0] = 2;
                                    xlast = 1;
                                    ylast = 0;
                                    first = false;
                                }
                                else
                                {
                                    label1.Text = "Ячейка уже занята";
                                }
                            }
                            if (e.Location.X > 200 && e.Location.X < 300 && e.Location.Y > 0 && e.Location.Y < 100)//3 ячейка
                            {
                                if (a[2, 0] == 0)
                                {
                                    Graphics gPanel = panel1.CreateGraphics();
                                    Pen p = new Pen(Color.Black, 3);
                                    gPanel.DrawLine(p, 202, 2, 298, 98);
                                    gPanel.DrawLine(p, 298, 2, 202, 98);
                                    a[2, 0] = 2;
                                    xlast = 2;
                                    ylast = 0;
                                    first = false;
                                }
                                else
                                {
                                    label1.Text = "Ячейка уже занята";
                                }
                            }
                            if (e.Location.X > 0 && e.Location.X < 100 && e.Location.Y > 100 && e.Location.Y < 200)//4 ячейка
                            {
                                if (a[0, 1] == 0)
                                {
                                    Graphics gPanel = panel1.CreateGraphics();
                                    Pen p = new Pen(Color.Black, 3);
                                    gPanel.DrawLine(p, 2, 102, 98, 198);
                                    gPanel.DrawLine(p, 98, 102, 2, 198);
                                    a[0, 1] = 2;
                                    xlast = 0;
                                    ylast = 1;
                                    first = false;
                                }
                                else
                                {
                                    label1.Text = "Ячейка уже занята";
                                }
                            }
                            if (e.Location.X > 100 && e.Location.X < 200 && e.Location.Y > 100 && e.Location.Y < 200)//5 ячейка
                            {
                                if (a[1, 1] == 0)
                                {
                                    Graphics gPanel = panel1.CreateGraphics();
                                    Pen p = new Pen(Color.Black, 3);
                                    gPanel.DrawLine(p, 102, 102, 198, 198);
                                    gPanel.DrawLine(p, 198, 102, 102, 198);
                                    a[1, 1] = 2;
                                    xlast = 1;
                                    ylast = 1;
                                    if (first)
                                    {
                                        xfir = 1;
                                        yfir = 1;
                                        first = false;
                                    }
                                }
                                else
                                {
                                    label1.Text = "Ячейка уже занята";
                                }
                            }
                            if (e.Location.X > 200 && e.Location.X < 300 && e.Location.Y > 100 && e.Location.Y < 200)//6 ячейка
                            {
                                if (a[2, 1] == 0)
                                {
                                    Graphics gPanel = panel1.CreateGraphics();
                                    Pen p = new Pen(Color.Black, 3);
                                    gPanel.DrawLine(p, 202, 102, 298, 198);
                                    gPanel.DrawLine(p, 298, 102, 202, 198);
                                    a[2, 1] = 2;
                                    xlast = 2;
                                    ylast = 1;
                                    first = false;
                                }
                                else
                                {
                                    label1.Text = "Ячейка уже занята";
                                }
                            }
                            if (e.Location.X > 0 && e.Location.X < 100 && e.Location.Y > 200 && e.Location.Y < 300)//7 ячейка
                            {
                                if (a[0, 2] == 0)
                                {
                                    Graphics gPanel = panel1.CreateGraphics();
                                    Pen p = new Pen(Color.Black, 3);
                                    gPanel.DrawLine(p, 2, 202, 98, 298);
                                    gPanel.DrawLine(p, 98, 202, 2, 298);
                                    a[0, 2] = 2;
                                    xlast = 0;
                                    ylast = 2;
                                    first = false;
                                }
                                else
                                {
                                    label1.Text = "Ячейка уже занята";
                                }
                            }
                            if (e.Location.X > 100 && e.Location.X < 200 && e.Location.Y > 200 && e.Location.Y < 300)//8 ячейка
                            {
                                if (a[1, 2] == 0)
                                {
                                    Graphics gPanel = panel1.CreateGraphics();
                                    Pen p = new Pen(Color.Black, 3);
                                    gPanel.DrawLine(p, 102, 202, 198, 298);
                                    gPanel.DrawLine(p, 198, 202, 102, 298);
                                    a[1, 2] = 2;
                                    xlast = 1;
                                    ylast = 2;
                                    first = false;
                                }
                                else
                                {
                                    label1.Text = "Ячейка уже занята";
                                }
                            }
                            if (e.Location.X > 200 && e.Location.X < 300 && e.Location.Y > 200 && e.Location.Y < 300)//9 ячейка
                            {
                                if (a[2, 2] == 0)
                                {
                                    Graphics gPanel = panel1.CreateGraphics();
                                    Pen p = new Pen(Color.Black, 3);
                                    gPanel.DrawLine(p, 202, 202, 298, 298);
                                    gPanel.DrawLine(p, 298, 202, 202, 298);
                                    a[2, 2] = 2;
                                    xlast = 2;
                                    ylast = 2;
                                    first = false;
                                }
                                else
                                {
                                    label1.Text = "Ячейка уже занята";
                                }
                            }
                        }
                        else   // все аналогично с первым условием, только здесь пользователь играет ноликами
                        {
                            if (e.Location.X > 0 && e.Location.X < 100 && e.Location.Y > 0 && e.Location.Y < 100)  //1 ячейка
                            {

                                if (a[0, 0] == 0)
                                {
                                    Graphics gPanel = panel1.CreateGraphics();
                                    Pen p = new Pen(Color.Black, 3);
                                    gPanel.DrawEllipse(p, 4, 4, 92, 92);
                                    a[0, 0] = 2;
                                    xlast = 0;
                                    ylast = 0;
                                }
                                else
                                {
                                    label1.Text = "Ячейка уже занята";
                                }
                            }

                            if (e.Location.X > 100 && e.Location.X < 200 && e.Location.Y > 0 && e.Location.Y < 100)//2 ячейка
                            {
                                if (a[1, 0] == 0)
                                {
                                    Graphics gPanel = panel1.CreateGraphics();
                                    Pen p = new Pen(Color.Black, 3);
                                    gPanel.DrawEllipse(p, 104, 4, 92, 92);
                                    a[1, 0] = 2;
                                    xlast = 1;
                                    ylast = 0;
                                }
                                else
                                {
                                    label1.Text = "Ячейка уже занята";
                                }
                            }
                            if (e.Location.X > 200 && e.Location.X < 300 && e.Location.Y > 0 && e.Location.Y < 100)//3 ячейка
                            {
                                if (a[2, 0] == 0)
                                {
                                    Graphics gPanel = panel1.CreateGraphics();
                                    Pen p = new Pen(Color.Black, 3);
                                    gPanel.DrawEllipse(p, 204, 4, 92, 92);
                                    a[2, 0] = 2;
                                    xlast = 2;
                                    ylast = 0;
                                }
                                else
                                {
                                    label1.Text = "Ячейка уже занята";
                                }
                            }
                            if (e.Location.X > 0 && e.Location.X < 100 && e.Location.Y > 100 && e.Location.Y < 200)//4 ячейка
                            {
                                if (a[0, 1] == 0)
                                {
                                    Graphics gPanel = panel1.CreateGraphics();
                                    Pen p = new Pen(Color.Black, 3);
                                    gPanel.DrawEllipse(p, 4, 104, 92, 92);
                                    a[0, 1] = 2;
                                    xlast = 0;
                                    ylast = 1;
                                }
                                else
                                {
                                    label1.Text = "Ячейка уже занята";
                                }
                            }
                            if (e.Location.X > 100 && e.Location.X < 200 && e.Location.Y > 100 && e.Location.Y < 200)//5 ячейка
                            {
                                if (a[1, 1] == 0)
                                {
                                    Graphics gPanel = panel1.CreateGraphics();
                                    Pen p = new Pen(Color.Black, 3);
                                    gPanel.DrawEllipse(p, 104, 104, 92, 92);
                                    a[1, 1] = 2;
                                    xlast = 1;
                                    ylast = 1;
                                }
                                else
                                {
                                    label1.Text = "Ячейка уже занята";
                                }
                            }
                            if (e.Location.X > 200 && e.Location.X < 300 && e.Location.Y > 100 && e.Location.Y < 200)//6 ячейка
                            {
                                if (a[2, 1] == 0)
                                {
                                    Graphics gPanel = panel1.CreateGraphics();
                                    Pen p = new Pen(Color.Black, 3);
                                    gPanel.DrawEllipse(p, 204, 104, 92, 92);
                                    a[2, 1] = 2;
                                    xlast = 2;
                                    ylast = 1;
                                }
                                else
                                {
                                    label1.Text = "Ячейка уже занята";
                                }
                            }
                            if (e.Location.X > 0 && e.Location.X < 100 && e.Location.Y > 200 && e.Location.Y < 300)//7 ячейка
                            {
                                if (a[0, 2] == 0)
                                {
                                    Graphics gPanel = panel1.CreateGraphics();
                                    Pen p = new Pen(Color.Black, 3);
                                    gPanel.DrawEllipse(p, 4, 204, 92, 92);
                                    a[0, 2] = 2;
                                    xlast = 0;
                                    ylast = 2;
                                }
                                else
                                {
                                    label1.Text = "Ячейка уже занята";
                                }
                            }
                            if (e.Location.X > 100 && e.Location.X < 200 && e.Location.Y > 200 && e.Location.Y < 300)//8 ячейка
                            {
                                if (a[1, 2] == 0)
                                {
                                    Graphics gPanel = panel1.CreateGraphics();
                                    Pen p = new Pen(Color.Black, 3);
                                    gPanel.DrawEllipse(p, 104, 204, 92, 92);
                                    a[1, 2] = 2;
                                    xlast = 1;
                                    ylast = 2;
                                }
                                else
                                {
                                    label1.Text = "Ячейка уже занята";
                                }
                            }
                            if (e.Location.X > 200 && e.Location.X < 300 && e.Location.Y > 200 && e.Location.Y < 300)//9 ячейка
                            {
                                if (a[2, 2] == 0)
                                {
                                    Graphics gPanel = panel1.CreateGraphics();
                                    Pen p = new Pen(Color.Black, 3);
                                    gPanel.DrawEllipse(p, 204, 204, 92, 92);
                                    a[2, 2] = 2;
                                    xlast = 2;
                                    ylast = 2;
                                }
                                else
                                {
                                    label1.Text = "Ячейка уже занята";
                                }
                            }
                        }
                        hdpc = true;   //след ход переходит ИИ
                        hod();
                    }
                }
            }
        }   

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                pc = 1;   // выбран первый ход ИИ
            }
        }  

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                pc = 2;    // выбран первый ход пользователя
            }
        }   

        private void hod1()
        {
            if (a[1, 1] == 0)
            {
                a[1, 1] = 1;   // ИИ первым ходом по возможности всегда ходит в центр, независимо от того какими он играет
            }
            else
            {
                random(); // При невозможности ИИ походить в центр игрового поля он делает первый ход рандомно 
            }
            paint();
            hdpc = false;
            pervhod = false;
        }    
        private void hod()
        {
            nichia();    //есть ли свободное поле, если нет, то ничья
            pobeda();    //1 правило победы
            if (win == 0)
            {
                zachita();  // 2 правило защиты
                if (hdpc == true)   // если 1,2 правила невыполнены, то есть до сих пор ход ИИ, то он должен сделать противоположный игроку ход для защиты
                {                   // или любой ход ведущий к минимаксной победе
                    if (pc == 1)    // если первый сходил ИИ, значит по тактике нужно ходить точно противоположно ходу юзера
                    {
                        krestiki();// ход противоположный
                    }
                    else  // ИИ ходит вторым
                    {
                        if (xfir == 1 && yfir == 1)   // Юзер ходит в центр - ИИ ходит в углы
                        {
                            ugol();
                        }
                        else   // если пользователь ходит не в центр
                        {
                            if (pervhod)
                            {
                                hod1();   // Значит при первом ходе ИИ ходит в центр
                                pervhod = false;
                            }
                            else
                            {
                                ugol(); // Если ход ИИ после Юзера, то ИИ ходит в углы
                            }
                        }
                    }
                }    //конец противоположного хода
                nichia(); // проверка на ничью
            }
            else
            {
                winner(); // проверка на победу кого-либо
            }
        }   // ход ИИ, когда он ходит первый, а пользователь второй
        private void random()   // ИИ заполняет любую пустую клетку игрового поля, когда центр заполнен
        {
            bool rand = false;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (rand == false)
                    {
                        if (a[i, j] == 0)
                        {
                            a[i, j] = 1;
                            rand = true;
                            hdpc = false;
                            paint();
                        }
                    }
                }
            }
        }  
        private void paint()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (pc == 1)   //если ИИ начинал, то 1 в условии - это крестики
                    {
                        if (a[i, j] == 1)
                        {
                            Graphics gPanel = panel1.CreateGraphics();
                            Pen p = new Pen(Color.Black, 3);
                            gPanel.DrawLine(p, 2+i*100, 2+j*100, 98+i*100, 98+j*100);
                            gPanel.DrawLine(p, 98+i*100, 2+j*100, 2+i*100, 98+j*100);
                        }
                    }
                    else   // ИИ ходил вторым, 1 в условии - нолики
                    {
                        if (a[i, j] == 1)
                        {
                            Graphics gPanel = panel1.CreateGraphics();
                            Pen p = new Pen(Color.Black, 3);
                            gPanel.DrawEllipse(p, 4+i*100, 4+j*100, 92, 92);
                        }
                    }
                }
            }
        }            
        private void winner()
        { // проверяется условие победы, когда игровое поле полностью заполняется
            Graphics gPanel = panel1.CreateGraphics();
            Pen p = new Pen(Color.Blue, 6);
            switch (cherta)
            { // в случае победы проводится черта в одной из 8 победных комбинаций 
                case 1: gPanel.DrawLine(p, 2, 50, 298, 50); break;
                case 2: gPanel.DrawLine(p, 2, 150, 298, 150); break;
                case 3: gPanel.DrawLine(p, 2, 250, 298, 250); break;
                case 4: gPanel.DrawLine(p, 50, 2, 50, 298); break;
                case 5: gPanel.DrawLine(p, 150, 2, 150, 298); break;
                case 6: gPanel.DrawLine(p, 250, 2, 250, 298); break;
                case 7: gPanel.DrawLine(p, 2, 2, 298, 298); break;
                case 8: gPanel.DrawLine(p, 298, 2, 2, 298); break;
            }
            if (cherta > 0)
            {
                label1.Text = "Компьютер выиграл!";
            }
            else
            {
                label1.Text = "Ничья!";
            }
        }          
        private void pobeda() 
        {
            // Нападение ИИ, попытка выиграть если есть возможность
            if (((a[0, 0] + a[0, 1] + a[0, 2]) == 2) && (a[0, 0] == 1 || a[0, 1] == 1 || a[0, 2] == 1))  //1-4-7  - комбинация для нападения
            {
                for (int j = 0; j < 3; j++)
                {
                    if (a[0, j] == 0)
                    {
                        a[0, j] = 1;
                    }
                }
                win = 1;
                paint();
                cherta = 4;
            }
            else
            {
                if (((a[1, 0] + a[1, 1] + a[1, 2]) == 2) && (a[1, 0] == 1 || a[1, 1] == 1 || a[1, 2] == 1))   //2-5-8  
                {

                    for (int j = 0; j < 3; j++)
                    {
                        if (a[1, j] == 0)
                        {
                            a[1, j] = 1;
                        }
                    }
                    win = 1;
                    paint();
                    cherta = 5;
                }
                else
                {
                    if (((a[2, 0] + a[2, 1] + a[2, 2]) == 2) && (a[2, 0] == 1 || a[2, 1] == 1 || a[2, 2] == 1))   //3-6-9  
                    {

                        for (int j = 0; j < 3; j++)
                        {
                            if (a[2, j] == 0)
                            {
                                a[2, j] = 1;
                            }
                        }
                        win = 1;
                        paint();
                        cherta = 6;
                    }
                    else
                    {
                        if (((a[0, 0] + a[1, 0] + a[2, 0]) == 2) && (a[0, 0] == 1 || a[1, 0] == 1 || a[2, 0] == 1))   //1-2-3  
                        {

                            for (int i = 0; i < 3; i++)
                            {
                                if (a[i, 0] == 0)
                                {
                                    a[i, 0] = 1;
                                }
                            }
                            win = 1;
                            paint();
                            cherta = 1;
                        }
                        else
                        {
                            if (((a[0, 1] + a[1, 1] + a[2, 1]) == 2) && (a[0, 1] == 1 || a[1, 1] == 1 || a[2, 1] == 1))  //4-5-6  
                            {

                                for (int i = 0; i < 3; i++)
                                {
                                    if (a[i, 1] == 0)
                                    {
                                        a[i, 1] = 1;
                                    }
                                }
                                win = 1;
                                paint();
                                cherta = 2;
                            }
                            else
                            {
                                if (((a[0, 2] + a[1, 2] + a[2, 2]) == 2) && (a[0, 2] == 1 || a[1, 2] == 1 || a[2, 2] == 1))   //7-8-9  
                                {

                                    for (int i = 0; i < 3; i++)
                                    {
                                        if (a[i, 2] == 0)
                                        {
                                            a[i, 2] = 1;
                                        }
                                    }
                                    win = 1;
                                    paint();
                                    cherta = 3;
                                }
                                else
                                {
                                    if (((a[0, 0] + a[1, 1] + a[2, 2]) == 2) && (a[0, 0] == 1 || a[1, 1] == 1 || a[2, 2] == 1))   //1-5-9  
                                    {
                                        if (a[0, 0] == 0)
                                            a[0, 0] = 1;
                                        if (a[1, 1] == 0)
                                            a[1, 1] = 1;
                                        if (a[2, 2] == 0)
                                            a[2, 2] = 1;
                                        win = 1;
                                        paint();
                                        cherta = 7;

                                    }
                                    else
                                    {
                                        if (((a[2, 0] + a[1, 1] + a[0, 2]) == 2) && (a[2, 0] == 1 || a[1, 1] == 1 || a[0, 2] == 1))   //3-5-7  
                                        {
                                            if (a[2, 0] == 0)
                                                a[2, 0] = 1;
                                            if (a[1, 1] == 0)
                                                a[1, 1] = 1;
                                            if (a[0, 2] == 0)
                                                a[0, 2] = 1;
                                            win = 1;
                                            paint();
                                            cherta = 8;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }          
        private void zachita()
        {
            // защита ИИ, чтоб не проиграть
            if ((a[0, 0] + a[0, 1] + a[0, 2]) == 4 && a[0, 0] != 1 && a[0, 1] != 1 && a[0, 2] != 1)   //1-4-7  - комбинация для защиты
            {
                for (int j = 0; j < 3; j++)
                {
                    if (a[0, j] == 0)
                    {
                        a[0, j] = 1;
                        hdpc = false;  // указывает на то, что в первую очередь ИИ защищается и заканчивает ход
                        paint();
                    }
                }
            }
            else
            {
                if ((a[1, 0] + a[1, 1] + a[1, 2]) == 4 && a[1, 0] != 1 && a[1, 1] != 1 && a[1, 2] != 1)   //2-5-8  
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (a[1, j] == 0)
                        {
                            a[1, j] = 1;
                            hdpc = false;
                            paint();
                        }
                    }
                }
                else
                {
                    if ((a[2, 0] + a[2, 1] + a[2, 2]) == 4 && a[2, 0] != 1 && a[2, 1] != 1 && a[2, 2] != 1)   //3-6-9  
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (a[2, j] == 0)
                            {
                                a[2, j] = 1;
                                hdpc = false;
                                paint();

                            }
                        }
                    }
                    else
                    {
                        if ((a[0, 0] + a[1, 0] + a[2, 0]) == 4 && a[0, 0] != 1 && a[1, 0] != 1 && a[2, 0] != 1)   //1-2-3  
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                if (a[i, 0] == 0)
                                {
                                    a[i, 0] = 1;
                                    hdpc = false;
                                    paint();
                                }
                            }
                        }
                        else
                        {
                            if ((a[0, 1] + a[1, 1] + a[2, 1]) == 4 && a[0, 1] != 1 && a[1, 1] != 1 && a[2, 1] != 1)   //4-5-6  
                            {
                                for (int i = 0; i < 3; i++)
                                {
                                    if (a[i, 1] == 0)
                                    {
                                        a[i, 1] = 1;
                                        hdpc = false;
                                        paint();
                                    }
                                }
                            }
                            else
                            {
                                if ((a[0, 2] + a[1, 2] + a[2, 2]) == 4 && a[0, 2] != 1 && a[1, 2] != 1 && a[2, 2] != 1)   //7-8-9  
                                {
                                    for (int i = 0; i < 3; i++)
                                    {
                                        if (a[i, 2] == 0)
                                        {
                                            a[i, 2] = 1;
                                            hdpc = false;
                                            paint();
                                        }
                                    }
                                }
                                else
                                {
                                    if ((a[0, 0] + a[1, 1] + a[2, 2]) == 4 && a[0, 0] != 1 && a[1, 1] != 1 && a[2, 2] != 1)   //1-5-9  
                                    {
                                        if (a[0, 0] == 0)
                                            a[0, 0] = 1;
                                        if (a[1, 1] == 0)
                                            a[1, 1] = 1;
                                        if (a[2, 2] == 0)
                                            a[2, 2] = 1;
                                        hdpc = false;
                                        paint();
                                    }
                                    else
                                    {
                                        if ((a[2, 0] + a[1, 1] + a[0, 2]) == 4 && a[2, 0] != 1 && a[1, 1] != 1 && a[0, 2] != 1)   //3-5-7  
                                        {
                                            if (a[2, 0] == 0)
                                                a[2, 0] = 1;
                                            if (a[1, 1] == 0)
                                                a[1, 1] = 1;
                                            if (a[0, 2] == 0)
                                                a[0, 2] = 1;
                                            hdpc = false;
                                            paint();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }       //конец защиты по 2 правилу
        }           

        private void krestiki()   //противоположные игроку ходы, при условии, что ИИ ходит первый
        {
            if (xlast == 0 && ylast == 0)  //если 0,0
            {
                if (a[2, 2] == 0)
                {
                    a[2, 2] = 1;
                    hdpc = false; // В первую очередь ход ИИ в центр, далее по противоположным игроку углам
                    paint();
                }
                else
                {
                    random();
                }
            }
            else
            {
                if (xlast == 2 && ylast == 0)   //2.0
                {
                    if (a[0, 2] == 0)
                    {
                        a[0, 2] = 1;                
                        hdpc = false;
                        paint();
                    }
                    else
                    {
                        random();
                    }
                }
                else
                {
                    if (xlast == 0 && ylast == 2)   //0.2
                    {
                        if (a[2, 0] == 0)
                        {
                            a[2, 0] = 1;
                            hdpc = false;
                            paint();
                        }
                        else
                        {
                            random();
                        }
                    }
                    else
                    {
                        if (xlast == 2 && ylast == 2)   //2.2
                        {
                            if (a[0, 0] == 0)
                            {
                                a[0, 0] = 1;
                                hdpc = false;
                                paint();
                            }
                            else
                            {
                                random();
                            }
                        }
                        else
                        {
                            if (xlast == 0 && ylast == 1)   //0.1
                            {
                                if (a[2, 0] == 0)
                                {
                                    a[2, 0] = 1;
                                    hdpc = false;
                                    paint();
                                }
                                else
                                {
                                    if (a[2, 2] == 0)
                                    {
                                        a[2, 2] = 1;
                                        hdpc = false;
                                        paint();
                                    }
                                    else
                                    {
                                        random();
                                    }
                                }
                            }
                            else
                            {
                                if (xlast == 1 && ylast == 0)   //1.0
                                {
                                    if (a[0, 2] == 0)
                                    {
                                        a[0, 2] = 1;
                                        hdpc = false;
                                        paint();
                                    }
                                    else
                                    {
                                        if (a[2, 2] == 0)
                                        {
                                            a[2, 2] = 1;
                                            hdpc = false;
                                            paint();
                                        }
                                        else
                                        {
                                            random();
                                        }
                                    }
                                }
                                else
                                {
                                    if (xlast == 2 && ylast == 1)   //2.1
                                    {
                                        if (a[0, 0] == 0)
                                        {
                                            a[0, 0] = 1;
                                            hdpc = false;
                                            paint();
                                        }
                                        else
                                        {
                                            if (a[0, 2] == 0)
                                            {
                                                a[0, 2] = 1;
                                                hdpc = false;
                                                paint();
                                            }
                                            else
                                            {
                                                random();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (xlast == 1 && ylast == 2)   //1.2
                                        {
                                            if (a[0, 0] == 0)
                                            {
                                                a[0, 0] = 1;
                                                hdpc = false;
                                                paint();
                                            }
                                            else
                                            {
                                                if (a[2, 0] == 0)
                                                {
                                                    a[2, 0] = 1;
                                                    hdpc = false;
                                                    paint();
                                                }
                                                else
                                                {
                                                    random();
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }   
        private void nichia()
        {
            bool nich = true;   //если true - то ничья
            for (int i = 0; i < 3; i++)   //если находим 0, то получим false, то есть не ничья, можно еще ходить
            {
                for (int j = 0; j < 3; j++)
                {
                    if (nich)   
                    {
                        if (a[i, j] == 0)
                        {
                            nich = false;
                        }
                    }
                }
            }
            if (nich)
            {
                label1.Text = "Ничья";
                win = 3;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        a[i, j] = 0;
                    }
                }
            }
        }     
        private void newgame()
        {// при каждой новой игре игровое поле заново делится на координатные клетки
            qwe = false;
            label1.Text = "";
            Graphics gPanel = panel1.CreateGraphics();
            panel1.Controls.Clear();
            panel1.Invalidate();
            Pen p = new Pen(Color.Blue, 1);
            Pen p1 = new Pen(Color.Blue, 2);
            gPanel.DrawLine(p, new Point(0, 0), new Point(300, 0));
            gPanel.DrawLine(p, new Point(300, 0), new Point(300, 300));
            gPanel.DrawLine(p, new Point(0, 0), new Point(0, 300));
            gPanel.DrawLine(p, new Point(0, 300), new Point(300, 300));
            gPanel.DrawLine(p1, new Point(100, 0), new Point(100, 300));
            gPanel.DrawLine(p1, new Point(200, 0), new Point(200, 300));
            gPanel.DrawLine(p1, new Point(0, 100), new Point(300, 100));
            gPanel.DrawLine(p1, new Point(0, 200), new Point(300, 200));
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    a[i, j] = 0;
                }
            }
            first = true;
            cherta = 0;   // черта для вычеркивания выигрышной комбинации
            x = -1;
            y = -1;
            xfir = -1; // первый ход юзера
            yfir = -1; // когда он играет крестиками
            xlast = -1;//последний
            ylast = -1;// ход юзера
            win = 0;//если 1- выиграл комп, 2-пользователь, 3- ничья
            hdpc = false;//true - сейчас ход компьютера, false - ход пользователя
            pc = 0;     // кто ходит первым, 1 - ходит комп, 2 первый ходит юзер
            radioButton1.Visible = true;
            radioButton2.Visible = true;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }
        private void ugol() // защита ИИ в случае когда первым ходит пользователь
        {
            if (a[0, 0] == 0)
            {
                a[0, 0] = 1;
                hdpc = false;
                paint();
            }
            else
            {
                if (a[2, 0] == 0)
                {
                    a[2, 0] = 1;
                    hdpc = false;
                    paint();
                }
                else
                {
                    if (a[0, 2] == 0)
                    {
                        a[0, 2] = 1;
                        hdpc = false;
                        paint();
                    }
                    else
                    {
                        if (a[2, 2] == 0)
                        {
                            a[2, 2] = 1;
                            hdpc = false;
                            paint();
                        }
                        else
                        {
                            napad();
                        }
                    }
                }
            }
        }    

        private void button2_Click(object sender, EventArgs e)
        {
            newgame();
        }
        private void napad() // Нападение ИИ по возможности, в случае когда первым ходит пользователь
        {
            if ((a[0, 0] + a[0, 1] + a[0, 2]) == 1)  //1-4-7 - если одна из этих клеток заполнена ноликом ИИ, то заполняет еще одну  
            {
                for (int j = 0; j < 3; j++)
                {
                    if (a[0, j] == 0)
                    {
                        a[0, j] = 1;
                    }
                }
                paint();
            }
            else
            {
                if ((a[1, 0] + a[1, 1] + a[1, 2]) == 1)   //2-5-8  
                {

                    for (int j = 0; j < 3; j++)
                    {
                        if (a[1, j] == 0)
                        {
                            a[1, j] = 1;
                        }
                    }
                    paint();
                }
                else
                {
                    if ((a[2, 0] + a[2, 1] + a[2, 2]) == 1)   //3-6-9  
                    {

                        for (int j = 0; j < 3; j++)
                        {
                            if (a[2, j] == 0)
                            {
                                a[2, j] = 1;
                            }
                        }
                        paint();
                    }
                    else
                    {
                        if ((a[0, 0] + a[1, 0] + a[2, 0]) == 1)   //1-2-3  
                        {

                            for (int i = 0; i < 3; i++)
                            {
                                if (a[i, 0] == 0)
                                {
                                    a[i, 0] = 1;
                                }
                            }
                            paint();
                        }
                        else
                        {
                            if ((a[0, 1] + a[1, 1] + a[2, 1]) == 1)  //4-5-6  
                            {

                                for (int i = 0; i < 3; i++)
                                {
                                    if (a[i, 1] == 0)
                                    {
                                        a[i, 1] = 1;
                                    }
                                }
                                paint();
                            }
                            else
                            {
                                if ((a[0, 2] + a[1, 2] + a[2, 2]) == 1)   //7-8-9 
                                {

                                    for (int i = 0; i < 3; i++)
                                    {
                                        if (a[i, 2] == 0)
                                        {
                                            a[i, 2] = 1;
                                        }
                                    }
                                    paint();
                                }
                                else
                                {
                                    if ((a[0, 0] + a[1, 1] + a[2, 2]) == 1)   //1-5-9  
                                    {
                                        if (a[0, 0] == 0)
                                        {
                                            a[0, 0] = 1;
                                        }
                                        else
                                        {
                                            if (a[1, 1] == 0)
                                            {
                                                a[1, 1] = 1;
                                            }
                                            else
                                            {
                                                if (a[2, 2] == 0)
                                                    a[2, 2] = 1;
                                            }
                                        }
                                        paint();
                                    }
                                    else
                                    {
                                        if ((a[2, 0] + a[1, 1] + a[0, 2]) == 1)   //3-5-7  
                                        {
                                            if (a[2, 0] == 0)
                                            {
                                                a[2, 0] = 1;
                                            }
                                            else
                                            {
                                                if (a[1, 1] == 0)
                                                {
                                                    a[1, 1] = 1;
                                                }
                                                else
                                                {
                                                    if (a[0, 2] == 0)
                                                    {
                                                        a[0, 2] = 1;
                                                    }
                                                }
                                            }
                                            paint();
                                        }
                                        else
                                        {
                                            random();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }   
        }  
    }
}
