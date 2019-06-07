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

namespace Lotto
{
    public partial class Form1 : Form
    {
        string filePath = @"user.dat";

        public Form1()
        {
            InitializeComponent();
            ExecuteLotto();
            GetUserName();
        }

        private void GetUserName()
        {
            if(File.Exists(filePath))
            {
                Text.Text = System.IO.File.ReadAllText(filePath);
            }
            else
            {
                Text.Text = Prompt.ShowDialog("문구를 입력해 주세요", Text.Text); ;
            }
        }

        private int[] GetLottoNumber()
        {
            HashSet<int> nums = new HashSet<int>();

            do
            {
                Random rnd = new Random(Guid.NewGuid().GetHashCode());
                nums.Add(rnd.Next(1, 46));
            } while (nums.Count < 6);

            return nums.ToArray();
        }

        private void SetLottoNumber(System.Windows.Forms.ListBox box)
        {
            int[] res = GetLottoNumber();
            Array.Sort(res);
            foreach (int num in res)
                box.Items.Add(num);
        }

        private void ExecuteLotto()
        {
            box1.Items.Clear();
            box2.Items.Clear();
            box3.Items.Clear();
            box4.Items.Clear();
            box5.Items.Clear();

            SetLottoNumber(box1);
            SetLottoNumber(box2);
            SetLottoNumber(box3);
            SetLottoNumber(box4);
            SetLottoNumber(box5);
        }

        private void Execute_Click(object sender, EventArgs e)
        {
            ExecuteLotto();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.IO.File.WriteAllText(filePath, Text.Text);
        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            Text.Text = Prompt.ShowDialog("문구를 입력해 주세요", Text.Text);
        }

        private void Text_DoubleClick(object sender, EventArgs e)
        {
            Text.Text = Prompt.ShowDialog("문구를 입력해 주세요", Text.Text);
        }
    }
}
