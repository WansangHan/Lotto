using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lotto
{
    class LottoDataReader
    {
        private static readonly string filePath = @"Lotto.txt";

        public static List<LottoData> GetAllLottoData()
        {
            Dictionary<int, JObject> lottoJObjects = new Dictionary<int, JObject>();

            if(File.Exists(filePath))
            {
                JArray jArray = JArray.Parse(System.IO.File.ReadAllText(filePath));

                foreach(JObject jObject in jArray)
                {
                    try
                    {
                        lottoJObjects.Add(int.Parse(jObject["drwNo"].ToString()), jObject);
                    }
                    catch
                    {
                        MessageBox.Show("Error Occured While Reed From File");
                        return null;
                    }
                }
            }

            bool isDirty = false;
            for (int i = 1; ; i++)
            {
                // Key를 이미 가지고있다면 웹에서 읽어올 필요가 없다.
                if(lottoJObjects.ContainsKey(i) == true)
                {
                    continue;
                }

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.dhlottery.co.kr/common.do?method=getLottoNumber&drwNo=+" + i);
                request.Method = "GET";

                using (WebResponse response = request.GetResponse())
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        StreamReader streamReader = new StreamReader(stream);
                        JObject jObject = JObject.Parse(streamReader.ReadLine());

                        // 실패했다면 종료한다.
                        if(jObject["returnValue"].ToString().Equals("success") == false)
                        {
                            break;
                        }

                        isDirty = true;

                        try
                        {
                            lottoJObjects.Add(int.Parse(jObject["drwNo"].ToString()), jObject);
                        }
                        catch
                        {
                            MessageBox.Show("Error Occured While Reed From Web Api");
                            return null;
                        }
                    }
                }
            }

            if(isDirty)
            {
                JArray array = new JArray();
                foreach(JObject jObject in lottoJObjects.Values)
                {
                    array.Add(jObject);
                }

                File.WriteAllText(filePath, array.ToString());
            }

            List<LottoData> lottoDatas = new List<LottoData>();

            foreach(JObject jObject in lottoJObjects.Values)
            {
                lottoDatas.Add(new LottoData(jObject));
            }

            return lottoDatas;
        }
    }
}
