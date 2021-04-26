using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace acfun_momentbot
{
    public static class moment
    {
        private static readonly HttpClient client = new HttpClient();
        /// <summary>
        /// 获取指定用户的动态
        /// </summary>
        /// <param name="id">用户id</param>
        /// <param name="count">获取数量</param>
        /// <returns></returns>
        public static async Task<MomentEntity> GetMoment(int id,int count=1)
        {
            var responseString = await client.GetStringAsync(String.Format("https://mini.pocketword.cn/api/acfun/user/moment?pcursor=0&userId={0}&count={1}",id.ToString(),count.ToString()));
            MomentEntity moments = JsonConvert.DeserializeObject<MomentEntity>(responseString);
            return moments;
        }
    }
}
