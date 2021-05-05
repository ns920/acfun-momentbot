using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sora.Entities;
using Sora.Entities.CQCodes;
using Sora.Entities.Base;

namespace acfun_momentbot
{
    public class cycle
    {
        /// <summary>
        /// 遍历动态循环
        /// </summary>
        public void Cycle(SoraApi api)
        {
            if (api==null) return;
            var path = "config.json";
            string jsonString;
            using (System.IO.StreamReader file = System.IO.File.OpenText(path))
            {
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    JObject o = (JObject)JToken.ReadFrom(reader);
                    //遍历up
                    for(int i=0;i<o["up"].Count();i++)
                    {
                        var up = o["up"][i];
                        int id = 0;
                        int.TryParse(up["id"].ToString(), out id);
                        if (id > 0)
                        {
                            // 获取entity
                            var entity = moment.GetMoment(id).Result;
                            if (entity.feedList == null || entity.feedList.Length == 0) continue;
                            var entity1 = entity.feedList.First();
                            //判断是否有更新
                            bool isUpdated=false;
                            try
                            {
                                isUpdated = (int.Parse(up["newmomentid"].ToString()) > int.Parse(entity1.moment.momentId));
                            }
                            catch(Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            if(isUpdated)
                            {
                                long uid = 0;
                                object[] msg = GetMessages(entity1);
                                //对每个提醒qq发送消息
                                foreach (var notifyqq in up["notifyqq"])
                                {
                                    long.TryParse(notifyqq.ToString(), out uid);
                                    if(uid>0 ) api.SendPrivateMessage(uid, msg);
                                }
                                //对每个提醒qq群发送消息
                                foreach (var notifygroup in up["notifygroup"])
                                {
                                    long.TryParse(notifygroup.ToString(), out uid);
                                    if (uid > 0) api.SendPrivateMessage(uid, msg);
                                }
                                //回写entityid
                                o["up"][i]["newmomentid"] = entity1.moment.momentId;
                            }
                            //撤回消息
                            bool isCalceled= (int.Parse(up["newmomentid"].ToString()) < int.Parse(entity1.moment.momentId));
                            if(isCalceled)
                            {
                                //回写entityid
                                o["up"][i]["newmomentid"] = entity1.moment.momentId;
                            }

                        }

                    }
                    //修改后存入字符串
                    jsonString = JsonConvert.SerializeObject(o);
                }
            }
            //回写config
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(path))
            {
                writer.WriteLine(jsonString);
                writer.Flush();
            }
        }

        /// <summary>
        /// 获取需要发送的消息
        /// </summary>
        /// <param name="entity">Feedlist</param>
        /// <returns></returns>
        public object[] GetMessages(Feedlist entity)
        {
            object[] o;
            //有图
            if (entity.moment.imgs != null)
            {
                o = new object[entity.moment.imgs.Length + 1];
                o[0] = entity.user.userName + ":" + entity.moment.replaceUbbText; ;
                for (int i = 1; i <= entity.moment.imgs.Length; i++)
                {
                    o[i] = CQCode.CQImage(entity.moment.imgs[i - 1].originUrl);
                }
            }
            //无图
            else
            {
                o = new object[1];
                o[0] = entity.user.userName+":"+entity.moment.replaceUbbText;
            }
            return o;
        }
    }
}
