using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERP.ViewModel;
using Autofac;
using AutoMapper;
using System.Reflection;
using System.Data.Entity;
using ERP.Domain;
using EntityFramework.Extensions;

namespace ERP.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            #region MyRegion
            ////AdminBLL adminBLL = new AdminBLL();
            ////adminBLL.Add(new AdminModel { AddTime = DateTime.Now, AdminId = 1, Password = Guid.NewGuid().ToString(), UserName = "Admin" });

            ////创建容器
            //var builder = new ContainerBuilder();

            ////向容器注册类型
            //builder.RegisterType<WriteString>().As<IOutput>();
            //builder.RegisterType<DateWriter>().As<IDateWriter>();

            ////已配置组件注册的新容器
            //IContainer Container = builder.Build();

            //using (ILifetimeScope scope = Container.BeginLifetimeScope())
            //{
            //    //解析
            //    //自动创建实现这个接口的类的对象
            //    IDateWriter writer = scope.Resolve<IDateWriter>();
            //    writer.Writedate();
            //}
            #endregion

            erp__Entities db = new erp__Entities();

            db.Role.Update<Role>(m => new Role { RoleID = 1, AddTime = DateTime.Now });


            //db.Role.Attach(new Role { });

            //db.Entry<ProductClass>(new ProductClass { ClassID = 1, ClassName = "test", ClassIntro = "", Depth = 0 }).State = EntityState.Modified;


            //db.Entry<Role>(new Role { AddTime = DateTime.Now, RoleName = "RoleName", RoleID = 3 }).State = EntityState.Modified;

            //db.SaveChanges();

            //foreach (var item in person.GetType().GetProperties())
            //{
            //    Console.WriteLine(item.GetValue(person));
            //}

            Console.Read();
        }
    }

    public static class AutoMapper
    {
        public static T MapTo<T>(this object source)
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(m => m.CreateMap(source.GetType(), typeof(T)));
            IMapper mapper = mapperConfiguration.CreateMapper();
            return mapper.Map<T>(source);
        }

        public static List<TDestination> MapToList<TSource, TDestination>(this IEnumerable<TSource> objList)
        {
            MapperConfiguration config = new MapperConfiguration(m => m.CreateMap<TSource, TDestination>());
            IMapper mapper = config.CreateMapper();
            return mapper.Map<IEnumerable<TSource>, List<TDestination>>(objList);
        }
    }

    public class People
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }


    #region AutoFac
    /// <summary>
    /// 接口，输出字符串
    /// </summary>
    public interface IOutput
    {
        void Write(string content);
    }

    /// <summary>
    /// 接口的实现方法
    /// </summary>
    public class WriteString : IOutput
    {
        public void Write(string content)
        {
            Console.WriteLine(content);
        }
    }

    public interface IDateWriter
    {
        void Writedate();
    }

    public class DateWriter : IDateWriter
    {
        private IOutput _output;

        /// <summary>
        /// 构造函数
        /// </summary>
        public DateWriter(IOutput output)
        {
            //注入
            this._output = output;
        }

        public void Writedate()
        {
            _output.Write(DateTime.Now.ToString());
        }
    }
    #endregion
}
