using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lotto
{
    public class LottoData
    {
        public int drwNo { get; }
        public int drwtNo1 { get; }
        public int drwtNo2 { get; }
        public int drwtNo3 { get; }
        public int drwtNo4 { get; }
        public int drwtNo5 { get; }
        public int drwtNo6 { get; }
        public int bnusNo { get; }

        public LottoData(JObject obj)
        {
            try
            {
                drwNo = int.Parse(obj["drwNo"].ToString());
                drwtNo1 = int.Parse(obj["drwtNo1"].ToString());
                drwtNo2 = int.Parse(obj["drwtNo2"].ToString());
                drwtNo3 = int.Parse(obj["drwtNo3"].ToString());
                drwtNo4 = int.Parse(obj["drwtNo4"].ToString());
                drwtNo5 = int.Parse(obj["drwtNo5"].ToString());
                drwtNo6 = int.Parse(obj["drwtNo6"].ToString());
                bnusNo = int.Parse(obj["bnusNo"].ToString());
            }
            catch
            {
                MessageBox.Show("에러가 발생했습니다");
                Application.Exit();
            }
        }
    }
}
