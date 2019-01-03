using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDataHelp
{
    /// <summary>
    /// 此接口由DAL层继承
    /// </summary>
    /// <typeparam name="T">每一个model类名</typeparam>
    public interface IDataHelp<T> where T:class,new()
    {
        /// <summary>
        /// 添加方法
        /// </summary>
        /// <param name="t">需要添加的对象</param>
        /// <returns>返回受影响行数</returns>
        int Add(T t);

        /// <summary>
        /// 删除方法
        /// </summary>
        /// <param name="id">需要删除的id</param>
        /// <returns>返回受影响行数</returns>
        int Del(int id);

        /// <summary>
        /// 修改方法
        /// </summary>
        /// <param name="t">需要修改的对象</param>
        /// <returns>返回受影响行数</returns>
        int Upt(T t);

        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
        List<T> GetList();

        /// <summary>
        /// 反填方法
        /// </summary>
        /// <param name="id">需要反填的id</param>
        /// <returns>返回一个对象</returns>
        T GetT(int id);

        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <param name="t">条件的各个属性</param>
        /// <returns>返回list集合</returns>
        List<T> GetList(T t);
    }
}
