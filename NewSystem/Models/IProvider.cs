using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewSystem.Models
{
    /// <summary>
    /// 数据库操作类的接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal interface IProvider<T> where T:class
    {
        /// <summary>
        /// 选择全部数据
        /// </summary>
        /// <returns></returns>
        List<T> Select();

        /// <summary>
        /// 插入一条新数据
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        int Insert(T t);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        int Delete(T t);

        /// <summary>
        /// 修改一条数据
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        int Update(T t);

    }
}
