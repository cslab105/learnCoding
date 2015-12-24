using System;

namespace EnglishLearningSoftware
{
    internal class Timer
    {
        private long startTime, endTime;

        public Timer()
        {
            StartTime();
         }

        private  void StartTime()
        {
            startTime = System.Environment.TickCount;
        }

        private  string Sumtime()
        {
            endTime = System.Environment.TickCount;
            int hour = 0;
            int minute = 0;
            int second = 0;
            second = (int)((endTime - startTime) / 1000);
            if (second > 60)
            {
                minute = second / 60;
                second = second % 60;
            }
            if (minute > 60)
            {
                hour = minute / 60;
                minute = minute % 60;
            }
            return "花费时间为：" + hour.ToString() + "小时" + minute.ToString() + "分钟"
                    + second.ToString() + "秒";
        }
        public override string ToString()
        {
            return Sumtime();
        }
    }
}
