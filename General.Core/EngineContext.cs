using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace General.Core
{
    public class EngineContext
    {
        private static IEngine _engine;


        /// <summary>
        /// MethodImpl(MethodImplOptions.Synchronized)  这个属性 保证 线程安全，从而保证 engine 的 单例唯一性；
        /// </summary>
        /// <param name="engine"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static IEngine Initialize(IEngine engine)
        {
            if (_engine == null)
            {
                _engine = engine;
            }
            return _engine;
        }

        public static IEngine Current
        {
            get
            {
                return _engine;
            }
        }
    }
}
