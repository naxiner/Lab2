using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        // Список створених студій
        List<RecStudio> recStudios = new List<RecStudio>();

        public Form1()
        {
            InitializeComponent();
        }

        // Обробник натискання клавіші "Додати студію"
        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            if (name.Length == 0)
            {
                MessageBox.Show("Поле для вводу даних пусте!", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                recStudios.Add(new RecStudio(name));
                listBox1.Items.Add(name);
            }

        }
        
        // Обробник натискання клавіші "Відобразити дані"
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Не обрано жодної студії!", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                listBox2.Items.Clear();
                listBox2.Items.Add("Назва студії: " + recStudios[listBox1.SelectedIndex].nameOfStudio);                     // назва студії
                listBox2.Items.Add("Адреса студії: " + recStudios[listBox1.SelectedIndex].adressOfStudio);                  // адреса
                listBox2.Items.Add("Кількість робітників студії: " + recStudios[listBox1.SelectedIndex].countOfWorkers);    // кількість робітників
                listBox2.Items.Add("Вартість створення треку: " + recStudios[listBox1.SelectedIndex].trackCreationCost);    // вартість створення одного треку
                listBox2.Items.Add("Заробітна плата одного робітника: " + recStudios[listBox1.SelectedIndex].oneWorkerSalary);  // заробітна плата робітника
                listBox2.Items.Add("Заробітна плата всіх робітників: " + recStudios[listBox1.SelectedIndex].allWorkersSalary);  // заробітна плата всіх робітників
                listBox2.Items.Add("Кількість інструментів: " + recStudios[listBox1.SelectedIndex].numberOfInstruments);    // кількість інструментів
                listBox2.Items.Add("Кількість кімнат: " + recStudios[listBox1.SelectedIndex].numbersOfRooms);               // кількість кімнат
            }
        }

        // Обробник натискання клавіші "Змінити параметр"
        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Не обрано жодної студії!", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0: // назва
                        int nameIndex = listBox1.SelectedIndex;
                        recStudios[listBox1.SelectedIndex].nameOfStudio = textBox1.Text;
                        listBox1.Items.RemoveAt(nameIndex);
                        listBox1.Items.Insert(nameIndex, textBox1.Text);
                        break;

                    case 1: // адреса
                        recStudios[listBox1.SelectedIndex].adressOfStudio = textBox1.Text; break;

                    case 2: // кількість робітників
                        try
                        {
                            recStudios[listBox1.SelectedIndex].countOfWorkers = Convert.ToInt32(textBox1.Text);
                            recStudios[listBox1.SelectedIndex].allWorkersSalary = Convert.ToInt32(textBox1.Text) * recStudios[listBox1.SelectedIndex].oneWorkerSalary;
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Дані мають бути у вигляді цілого числа!", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        break;

                    case 3: // вартість створення одного треку
                        try
                        {
                            recStudios[listBox1.SelectedIndex].trackCreationCost = Convert.ToDouble(textBox1.Text);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Дані мають бути у вигляді числа!", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        break;

                    case 4: // заробітна плата робітника
                        try
                        {
                            recStudios[listBox1.SelectedIndex].oneWorkerSalary = Convert.ToDouble(textBox1.Text);
                            recStudios[listBox1.SelectedIndex].allWorkersSalary = Convert.ToDouble(textBox1.Text) * recStudios[listBox1.SelectedIndex].countOfWorkers;
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Дані мають бути у вигляді числа!", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        break;

                    case 5: // кількість інструментів
                        try
                        {
                            recStudios[listBox1.SelectedIndex].numberOfInstruments = Convert.ToInt32(textBox1.Text);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Дані мають бути у вигляді цілого числа!", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        break;

                    case 6: // кількість кімнат
                        try
                        {
                            int numOfRooms = Convert.ToInt32(textBox1.Text);
                            int numOfWorkers = recStudios[listBox1.SelectedIndex].countOfWorkers;
                            int numOfInstruments = recStudios[listBox1.SelectedIndex].numberOfInstruments;

                            // Умова, що на одну кімнату має бути щонайменш 2 робітника та 2 інструмента
                            if ((numOfRooms * 2) > numOfWorkers || (numOfRooms * 2) > numOfInstruments)
                                MessageBox.Show("На одну кімнату мають бути хоча б 2 робітники та 2 ніструмента!", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            else
                                recStudios[listBox1.SelectedIndex].numbersOfRooms = numOfRooms;
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Дані мають бути у вигляді цілого числа!", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        break;

                    default: break;
                }
            }
        }

        // Обробник натискання клавіші "Додати кімнату"
        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
                MessageBox.Show("Не обрано жодної студії!", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                recStudios[listBox1.SelectedIndex].AddRoom();
        }

        // Обробник натискання клавіші "Видалити кімнату"
        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
                MessageBox.Show("Не обрано жодної студії!", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                recStudios[listBox1.SelectedIndex].RemoveRoom();
        }

        // Обробник натискання клавіші "Найняти робітника"
        private void button6_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
                MessageBox.Show("Не обрано жодної студії!", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                recStudios[listBox1.SelectedIndex].HireWorker();
        }

        // Обробник натискання клавіші "Звільнити робітника"
        private void button7_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
                MessageBox.Show("Не обрано жодної студії!", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                recStudios[listBox1.SelectedIndex].FireWorker();
        }

        // Обробник натискання клавіші "++"
        private void button8_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
                MessageBox.Show("Не обрано жодної студії!", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                recStudios[listBox1.SelectedIndex]++;
        }

        // Обробник натискання клавіші "--"
        private void button9_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
                MessageBox.Show("Не обрано жодної студії!", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                recStudios[listBox1.SelectedIndex]--;
        }
    }
}
