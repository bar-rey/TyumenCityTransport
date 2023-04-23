using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TyumenCityTransport.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICryptography
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string MD5FromInput(string input);
    }
}
