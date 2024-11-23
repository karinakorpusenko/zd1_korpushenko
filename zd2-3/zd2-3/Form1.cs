using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace zd2_3
{
    public partial class Form1 : Form

    {
        private Shop shop;
        private PlayList playlist;
        public Form1()
        {
            InitializeComponent();
            shop = new Shop();
            playlist = new PlayList();


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void UpdateProductList()
        {
            listBox1.Items.Clear(); // Очищаем текущий список
            foreach (var product in shop.GetProducts())
            {
                listBox1.Items.Add(product.Key.GetInfo() + $"; Количество: {product.Value}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != " " && numericUpDown1.Value != 0 && numericUpDown2.Value != 0)

            {
                string name = textBox1.Text;
                int count = (int)(numericUpDown2.Value);
                int price = (int)(numericUpDown1.Value);
                shop.CreateProduct(name, price, count);

                UpdateProductList();
            }




        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = textBox2.Text;
            int count = (int)(numericUpDown3.Value);
            shop.Sell(name, count);
            label8.Text = $"Прибыль: {shop.GetProfit()} руб.";
            UpdateProductList();
        }
        private void UpdateCurrentSong()
        {
            try
            {
                Song currentSong = playlist.CurrentSong(); // Получаем текущую песню
                label12.Text = $"Текущая песня: {currentSong.Title} - {currentSong.Author}"; // Обновляем Label
            }
            catch (IndexOutOfRangeException)
            {
                label12.Text = "Нет текущей песни."; // Обработка случая пустого плейлиста
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string author = textBox3.Text;
            string title = textBox4.Text;
            string filename = textBox5.Text;
            playlist.AddSong(author, title, filename);
            listBox2.Items.Add($"{title} - {author}"); // Отображаем в ListBox

            // Обновляем текущее состояние песни
            UpdateCurrentSong();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            playlist.NextSong();
            UpdateCurrentSong();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            playlist.PreviousSong();
            UpdateCurrentSong();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBox2.SelectedIndex;
            if (selectedIndex != -1)
            {
                playlist.RemoveSong(playlist.CurrentSong());
                listBox2.Items.RemoveAt(selectedIndex);
                label12.Text = "Нет текущей песни";
                listBox2.Items.Clear();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите песню для удаления.");
            }
             

        }

        private void button7_Click(object sender, EventArgs e)
        {
            playlist.ClearPlaylist();
            UpdateCurrentSong();
            listBox2.Items.Clear(); // Очистить ListBox
            label12.Text = "";
            MessageBox.Show("Плейлист очищен.");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            playlist.GoToStart();
            UpdateCurrentSong();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int selectedIndex = (int)(numericUpDown4.Value);
            playlist.GoToSong(selectedIndex);
            UpdateCurrentSong();
            
        }
    }
}
