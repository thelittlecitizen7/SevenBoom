using System;
using System.Collections.Generic;
using System.Text;

namespace SevenBoom
{
    public interface ISevenBoomRunner
    {
        void Run(Action<string> callback);
    }

}
