using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;


namespace NotePad__25022024
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            saveFileDialog1.Filter = "Text File(*.txt)|*.txt";
        }


        // Главное меню

        // редактирование
        private void удалениеСимволовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = string.Empty;
        }
        private void переносСтрокиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText(Environment.NewLine);
        }

        // работа с буфером
        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
            {
                richTextBox1.Copy();
            }
        }

        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                richTextBox1.Paste();
            }
        }

        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
            {
                richTextBox1.Cut();
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            string filename = saveFileDialog1.FileName;
            File.WriteAllText(filename, richTextBox1.Text);
            MessageBox.Show("Файл сохранен.");
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            string fileName = openFileDialog1.FileName;
            string fileText = File.ReadAllText(fileName);
            richTextBox1.Text = fileText;
            MessageBox.Show("Произошло открытие файла.");
        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        // текст
        private void шрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0) // Проверяем, что что-то выделено
            {
                FontDialog fontDialog = new FontDialog();
                Font originalFont = richTextBox1.SelectionFont;
                if (fontDialog.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.SelectionFont = fontDialog.Font;
                    // Возврат изначального шрифта после некоторого времени
                    Timer timer = new Timer();
                    timer.Interval = 1500; // Время в миллисекундах (например, полторы секунды)
                    timer.Tick += (s, _) =>
                    {
                        richTextBox1.SelectionFont = originalFont; // Возврат изначального шрифта
                        timer.Stop();
                    };
                    timer.Start();
                }
            }
            else
            {
                fontDialog1.ShowDialog();
                richTextBox1.SelectionStart = richTextBox1.TextLength; // Установка курсора в конец текста
                richTextBox1.SelectionFont = fontDialog1.Font; // Установка выбранного шрифта для нового текста
                richTextBox1.Focus(); // Перевод фокуса на RichTextBox
            }
        }

        private void цветТекстаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0) // Проверяем, что что-то выделено
            {
                ColorDialog colorDialog = new ColorDialog();
                Color originalColor = richTextBox1.SelectionColor;
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.SelectionColor = colorDialog.Color;
                    Timer timer = new Timer();
                    timer.Interval = 1500;
                    timer.Tick += (s, _) =>
                    {
                        richTextBox1.SelectionColor = originalColor;
                        timer.Stop();
                    };
                    timer.Start();
                }

            }
            else
            {
                colorDialog1.ShowDialog();
                richTextBox1.SelectionStart = richTextBox1.TextLength; // Установка курсора в конец текста
                richTextBox1.SelectionColor = colorDialog1.Color; // Установка выбранного цвета для нового текста
                richTextBox1.Focus(); // Перевод фокуса на RichTextBox
            }
        }

  
        private void печToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
        }


        private void справкаОПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Сведения (О программе)\n\nПриложение NotePad \n\nРазработано программой Microsoft Visual Studio Community 2022 (64-разрядная версия) - Current\r\nВерсия 17.7.3\r\n\nШарюкова Алина, группа 09-322 ");
        }

 
        
  
        
        // контекстное меню
        private void копироватьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
            {
                richTextBox1.Copy();
            }
        }
        private void вставитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                richTextBox1.Paste();
            }
        }

        private void удалениеСимволовToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = string.Empty;
        }

        private void переводСтрокиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText(Environment.NewLine);
        }

        private void шрифтToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0) // Проверяем, что что-то выделено
            {
                FontDialog fontDialog = new FontDialog();
                Font originalFont = richTextBox1.SelectionFont;
                if (fontDialog.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.SelectionFont = fontDialog.Font;
                    // Возврат изначального шрифта после некоторого времени
                    Timer timer = new Timer();
                    timer.Interval = 1500; // Время в миллисекундах (например, полторы секунды)
                    timer.Tick += (s, _) =>
                    {
                        richTextBox1.SelectionFont = originalFont; // Возврат изначального шрифта
                        timer.Stop();
                    };
                    timer.Start();
                }
            }
            else
            {
                fontDialog1.ShowDialog();
                richTextBox1.SelectionStart = richTextBox1.TextLength; 
                richTextBox1.SelectionFont = fontDialog1.Font; 
                richTextBox1.Focus(); 
            }
        }
        private void цветТекстаToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0) // Проверяем, что что-то выделено
            {
                ColorDialog colorDialog = new ColorDialog();
                Color originalColor = richTextBox1.SelectionColor;
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    richTextBox1.SelectionColor = colorDialog.Color;
                    Timer timer = new Timer();
                    timer.Interval = 1500; 
                    timer.Tick += (s, _) =>
                    {
                        richTextBox1.SelectionColor = originalColor; 
                        timer.Stop();
                    };
                    timer.Start();
                }

            }
            else
            {
                colorDialog1.ShowDialog();
                richTextBox1.SelectionStart = richTextBox1.TextLength; 
                richTextBox1.SelectionColor = colorDialog1.Color; 
                richTextBox1.Focus(); 
            }
        }

        private void richTextBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                richTextBox1.ContextMenuStrip = contextMenuStrip1;
            }
        }
    }
}
