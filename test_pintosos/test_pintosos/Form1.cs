using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace test_pintosos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int outs = 0, elem = 0;
        private string path;
        private string[] tests = new string[100];

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void outfile_Click(object sender, EventArgs e)
        {
            if(outs != 0)
            {
                StreamWriter f = new StreamWriter("test_lab.txt");
                f.Write("cd ");
                f.Write(path);
                f.WriteLine("pintos/src/threads");
                f.WriteLine("make");
                f.WriteLine();
                f.WriteLine("cd build");
                f.Write("make clean");
                f.WriteLine();
                for (int i = 0; i < elem; i++)
                {
                    f.Write("make tests/threads/");
                    f.Write(tests[i]);
                    f.Write(".rezult");
                    f.WriteLine();
                }
                f.WriteLine();
                f.Write("echo \"----------------------------------------------------------------------------\\n");
                f.Write(tests[0]);
                f.Write("\" >");
                f.Write(path);
                f.Write("Output.txt\ncat  tests/threads/");
                f.Write(tests[0]);
                f.Write(".result > ");
                f.Write(path);
                f.WriteLine("Output.txt");
                for (int i = 1; i < elem; i++)
                {
                    f.Write("echo \"----------------------------------------------------------------------------\\n");
                    f.Write(tests[i]);
                    f.Write("\" >>");
                    f.Write(path);
                    f.Write("Output.txt\ncat  tests/threads/");
                    f.Write(tests[i]);
                    f.Write(".result >> ");
                    f.Write(path);
                    f.WriteLine("Output.txt");
                }
                f.WriteLine();
                f.Write("echo \"\\n----------------------------------------------------------------------------\\n-----------------------------TESTS FINISHED---------------------------------\\n----------------------------------------------------------------------------\\n\"");
                f.WriteLine();
                f.WriteLine();
                f.Write("cd ");
                f.Write(path);
                f.WriteLine();
                f.Write("cat Output.txt");
                f.Close();
                Process.Start("test_lab.txt");
            }            
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamWriter f = new StreamWriter("Readme.txt");
            f.WriteLine("Вводите полный путь до папки с пинтосом с написанием в конце знака \"\\\"(слеш) и без указания самой папки pintos.");
            f.WriteLine("Если pintos в домашней папке - /home/user/.");
            f.WriteLine("Потом без пробелов вводите имена тестов (alarm-single, например)");
            f.WriteLine("Когда введы все имена тестов, нажмите кнопку Получить файл.");
            f.WriteLine("Загрузите полученный код из файла test_lab.txt в любой файл на linux'e.");
            f.WriteLine("В папке с этим файлом щелкните правой кнопкой мыши, откройте терминал и напишите 'sh имя_файла'.");
            f.WriteLine("Без кавычек, соответсвенно. Это запустит тестирование pintos'a.");
            f.WriteLine("По завершению тестирования внизу под надписью TESTS FINISHED будут результаты всех тестов с их названиями сверху.");
            f.Close();
            Process.Start("Readme.txt");
        }

        private void but_Click(object sender, EventArgs e)
        {
            if (outs == 1)
            {
                tests[elem++] = tex.Text;
                tex.Text = "Введите еще одно имя теста и нажмите \"Подтвердить\" или получите файл";
            }
            if (outs == 0) {
                outfile.Enabled = true;
                path = tex.Text;
                tex.Text = "Введите имя теста и нажмите \"Подтвердить\"";
                outs++;
            }
            
        }
    }
}
