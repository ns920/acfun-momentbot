using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acfun_momentbot
{
    class cycleJob:IJob
    {
        /// <summary>
        /// 执行循环Job
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Task Execute(IJobExecutionContext context)
        {
            return Task.Factory.StartNew(() =>
            {
                cycle c = new();
                c.Cycle(StaticEntity.api);

            });
        }
    }
}
