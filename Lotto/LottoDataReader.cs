using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Lotto
{
    class LottoDataReader
    {
        public static List<LottoData> GetAllLottoData()
        {
            List<LottoData> lottoDatas = new List<LottoData>();

            for (int i = 1; ; i++)
            {
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

                        LottoData lottoData = new LottoData(jObject);
                        lottoDatas.Add(lottoData);
                    }
                }
            }

            return lottoDatas;
        }
    }
}
