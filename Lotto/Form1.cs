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

        private int[] GetLottoNumber(Dictionary<int, int> factors, int maxValue)
        {
            HashSet<int> nums = new HashSet<int>();

            do
            {
                int rateSum = 0;

                Random rnd = new Random(Guid.NewGuid().GetHashCode());
                int targetFactor = rnd.Next(0, maxValue + 1);

                foreach(KeyValuePair<int, int> keyValuePair in factors)
                {
                    int number = keyValuePair.Key;
                    int numberFactor = keyValuePair.Value;

                    rateSum += numberFactor;

                    if(rateSum > targetFactor)
                    {
                        nums.Add(number);
                        break;
                    }
                }
            } while (nums.Count < 6);

            return nums.ToArray();
        }

        private void SetLottoNumber(System.Windows.Forms.ListBox box, Dictionary<int, int> factors, int maxValue)
        {
            int[] res = GetLottoNumber(factors, maxValue);
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
            if(lottoDatas == null)
            {
                return;
            }

            int maxValue = 0;
            Dictionary<int, int> factors = new Dictionary<int, int>();

            for(int i = 1; i <= 45; i++)
            {
                factors.Add(i, 0);
            }

            foreach(LottoData lottoData in lottoDatas)
            {
                factors[lottoData.drwtNo1] += lottoData.drwNo;
                factors[lottoData.drwtNo2] += lottoData.drwNo;
                factors[lottoData.drwtNo3] += lottoData.drwNo;
                factors[lottoData.drwtNo4] += lottoData.drwNo;
                factors[lottoData.drwtNo5] += lottoData.drwNo;
                factors[lottoData.drwtNo6] += lottoData.drwNo;
                maxValue += lottoData.drwNo * 6;
            }

            NumberRateGrid.Rows.Clear();

            NumberRateGrid.Columns["Number"].ValueType = typeof(int);

            foreach (KeyValuePair<int, int> keyValuePair in factors)
            {
                int number = keyValuePair.Key;
                int numberFactor = keyValuePair.Value;

                string[] datas = { number.ToString(), (((double)numberFactor / (double)maxValue) * 100.0).ToString() };
                NumberRateGrid.Rows.Add(datas);
            }

            SetLottoNumber(box1, factors, maxValue);
            SetLottoNumber(box2, factors, maxValue);
            SetLottoNumber(box3, factors, maxValue);
            SetLottoNumber(box4, factors, maxValue);
            SetLottoNumber(box5, factors, maxValue);
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

        private void NumberRateGrid_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            double a = double.Parse(e.CellValue1.ToString());
            double b = double.Parse(e.CellValue2.ToString());
            e.SortResult = a.CompareTo(b);
            e.Handled = true;
        }
    }
}
