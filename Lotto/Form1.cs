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
using Microsoft.Win32;

namespace Lotto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ExecuteLotto();
            GetUserName();
        }

        private void GetUserName()
        {
            var key = Registry.CurrentUser.CreateSubKey(@"TAYLOR\Lotto");
            if (key.GetValue("LottoLabel") != null)
            {
                Text.Text = key.GetValue("LottoLabel").ToString();
            }
            else
            {
                Text.Text = Prompt.ShowDialog("문구를 입력해 주세요", Text.Text); ;
            }
        }

        private int[] GetLottoNumber(List<int> numbers)
        {
            HashSet<int> nums = new HashSet<int>();

            do
            {
                Random rnd = new Random(Guid.NewGuid().GetHashCode());
                nums.Add(numbers[rnd.Next(0, numbers.Count)]);
            } while (nums.Count < 6);

            return nums.ToArray();
        }

        private void SetLottoNumber(System.Windows.Forms.ListBox box, List<int> numbers)
        {
            int[] res = GetLottoNumber(numbers);
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

            List<LottoData> lottoDatas = LottoDataReader.GetAllLottoData();

            List<int> numbers = new List<int>();

            foreach(LottoData lottoData in lottoDatas)
            {
                for(int i = 0; i < lottoData.drwNo; i++)
                {
                    numbers.Add(lottoData.drwtNo1);
                    numbers.Add(lottoData.drwtNo2);
                    numbers.Add(lottoData.drwtNo3);
                    numbers.Add(lottoData.drwtNo4);
                    numbers.Add(lottoData.drwtNo5);
                    numbers.Add(lottoData.drwtNo6);
                }
            }

            SetLottoNumber(box1, numbers);
            SetLottoNumber(box2, numbers);
            SetLottoNumber(box3, numbers);
            SetLottoNumber(box4, numbers);
            SetLottoNumber(box5, numbers);
        }

        private void Execute_Click(object sender, EventArgs e)
        {
            ExecuteLotto();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var key = Registry.CurrentUser.CreateSubKey(@"TAYLOR\Lotto");
            key.SetValue("LottoLabel", Text.Text);
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
