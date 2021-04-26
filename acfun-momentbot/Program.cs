using System;
using System.Linq;
using System.Text;
using Sora.Net;
using Sora.OnebotModel;
using System.Threading.Tasks;
using YukariToolBox.Extensions;
using YukariToolBox.FormatLog;
using Quartz;
using Quartz.Impl;
using Quartz.Logging;

namespace acfun_momentbot
{
    class Program
    {
        static async Task Main(string[] args)
        {
            LogProvider.SetCurrentLogProvider(new ConsoleLogProvider());
            //建立触发器
            var trigger = TriggerBuilder.Create()
                        .WithCronSchedule("0 * * * * ?")
                        .Build();
            //作业调度池
            var schedulerFactory = new StdSchedulerFactory();
            IScheduler scheduler = await schedulerFactory.GetScheduler();
            await scheduler.ScheduleJob(JobBuilder.Create<cycleJob>().Build(), trigger);
            await scheduler.Start();
            //实例化Sora服务器
            var service = SoraServiceFactory.CreateInstance(new ServerConfig() { Host = "127.0.0.1", Port = 18080 });
            //连接成功事件
            service.Event.OnClientConnect += (type, eventArgs) =>
            {
                //存储api实例
                StaticEntity.api = eventArgs.SoraApi;

                return ValueTask.CompletedTask;
            };
            //TODO: 私聊命令处理
            service.Event.OnPrivateMessage += async (sender, eventArgs) =>
              {

              };

            //启动服务并捕捉错误
            await service.StartService().RunCatch(e => Log.Error("Sora Service", Log.ErrorLogBuilder(e)));




            await Task.Delay(-1);

        }
    }
}
