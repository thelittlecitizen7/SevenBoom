using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SevenBoom
{
    public class SevenBoomRunner : ISevenBoomRunner
    {
        private object locker = new object();
        private BoomNumber _boomNumber;
        public SevenBoomRunner()
        {
            _boomNumber = new BoomNumber();
        }

        public void Run(Action<string> callback)
        {
            using (ManualResetEvent resetEvent = new ManualResetEvent(false))
            {
                for (int i = 0; i <= 3; i++)
                {

                    ThreadPool.QueueUserWorkItem(
                            new WaitCallback(x =>
                            {
                                CheckSevenBoom(callback);
                                resetEvent.Set();
                            }));
                }
                resetEvent.WaitOne();
            }
        }

        public void CheckSevenBoom(Action<string> callback)
        {
            
            while (_boomNumber.Number < 200)
            {
                lock (locker)
                {
                    if (_boomNumber.Number % 7 == 0 || Utils.IsDigitExistInNumber(_boomNumber.Number, 7))
                    {
                        callback.Invoke($"{_boomNumber.Number} BOOM");
                    }
                    else
                    {
                        callback.Invoke($"{_boomNumber.Number.ToString()}");
                    }
                    _boomNumber.Number++;
                }
            }
        }
    }

}

