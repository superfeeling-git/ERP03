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
using ERP.Utility;

namespace ERP.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //erp__Entities db = new erp__Entities();

            //Console.WriteLine(db.Admin.Last().UserName);

            int[] ClassID = new int[] { 1,2,3, 5 };

            Console.WriteLine(ClassID.Last());

            Console.ReadLine();




            //Supplier supplier = new Supplier { SupplierName = "Test" };

            //int[] ClassID = new int[] { 21, 22, 23 };

            //List<ProductClass_Supplier> productClass_Suppliers = ClassID.MapToList<int, ProductClass_Supplier>();            

            //supplier.ProductClass_Supplier = productClass_Suppliers;

            //db.Supplier.Add(supplier);

            //db.SaveChanges();



            //db.Supplier.Add(new Supplier { }).ProductClass_Supplier



            //IEnumerable<SupplierModel> suppliers = db.Supplier.AsEnumerable().MapToIEnumerable<Supplier, SupplierModel>();
            //foreach (var item in suppliers)
            //{
            //    Console.WriteLine(item.SupplierName);
            //}

            //Supplier supplier = new Supplier { SupplierName = "供应商主键获取测试" };

            //IList<ProductClass_Supplier> productClass_Suppliers = new List<ProductClass_Supplier>();
            //productClass_Suppliers.Add(new ProductClass_Supplier { ClassID = 21  });
            //productClass_Suppliers.Add(new ProductClass_Supplier { ClassID = 22  });
            //productClass_Suppliers.Add(new ProductClass_Supplier { ClassID = 23  });

            //supplier.ProductClass_Supplier = productClass_Suppliers;

            //db.Entry<Supplier>(supplier).State = System.Data.Entity.EntityState.Added;

            //Console.WriteLine($"保存前：{supplier.SupplierID}");

            //db.Supplier.Add(supplier);

            //db.SaveChanges();

            //Console.WriteLine($"保存后：{supplier.SupplierID}");


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

            //erp__Entities db = new erp__Entities();

            ////Console.WriteLine("A001".TrimEnd(','));

            //Console.ReadLine();

            //string Prefix = "GY";

            //for (int i = 65; i < 65 + 26; i++)
            //{
            //    Console.WriteLine((char)i);
            //}

            //Console.WriteLine("1".PadLeft(4, '0'));

            #region MyRegion
            //db.Role.Update<Role>(m => new Role { RoleID = 1, AddTime = DateTime.Now });



            //db.Role.Attach(new Role { });

            //db.Entry<ProductClass>(new ProductClass { ClassID = 1, ClassName = "test", ClassIntro = "", Depth = 0 }).State = EntityState.Modified;


            //db.Entry<Role>(new Role { AddTime = DateTime.Now, RoleName = "RoleName", RoleID = 3 }).State = EntityState.Modified;

            //db.SaveChanges();

            //foreach (var item in person.GetType().GetProperties())
            //{
            //    Console.WriteLine(item.GetValue(person));
            //}
            #endregion

            //Console.WriteLine(Generator("GY", "A999", 3, true));

            //Console.WriteLine('A'.GetType());

            //A001
            //001

            //Console.WriteLine(char.IsLetter('A'));
            //Console.WriteLine(char.IsLetter('0'));

            //Console.WriteLine(Generator("SL", "9999"));

            Console.Read();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Pre">GY</param>
        /// <param name="Code">A001/001</param>
        /// <param name="len"></param>
        /// <returns></returns>
        static string Generator(string Pre, string Code)
        {
            //第1个字符
            char firstChar = Code[0];

            //如果第1位是字母 A001
            if(char.IsLetter(firstChar))
            {
                int MaxNum = Convert.ToInt32(Code.TrimStart(firstChar));

                //判断字母是否增位
                //999  3
                if((MaxNum + 1).ToString().Length > Code.Length - 1)
                {
                    return $"{Pre}{(char)((byte)firstChar + 1)}{"1".PadLeft(Code.Length - 1, '0')}";
                }
                else
                {
                    return $"{Pre}{firstChar}{(MaxNum + 1).ToString().PadLeft(Code.Length - 1, '0')}";
                }
            }
            else
            {
                return $"{Pre}{(Convert.ToInt32(Code) + 1).ToString().PadLeft(Code.Length, '0')}";
            }
        }


        /// <summary>
        /// 生成编码
        /// </summary>
        /// <param name="Pre"></param>
        /// <param name="Code">数据库获取的最大编号</param>
        /// <param name="len">数字部分的长度</param>
        /// <param name="IsIdentity">是否存在字母增位</param>
        /// <returns></returns>
        static string Generator(string Pre, string Code, int len, bool IsIdentity)
        {
            //如果Code为NULL的空，返回GY A 001
            if (string.IsNullOrWhiteSpace(Code))
            {
                Code = "A" + "1".PadLeft(len, '0');
            }
            else
            {
                //存在字母增位
                if (IsIdentity)
                {
                    int number = Convert.ToInt32(Code.Substring(1, len));
                    if (number < Convert.ToInt32("9".PadLeft(len, '9')))
                    {
                        Code = Code.Substring(0, 1) + (number + 1).ToString().PadLeft(len, '0');
                    }
                    else
                    {
                        Code = (Convert.ToByte(Code.Substring(0, 1)) + 1).ToString() + (number + 1).ToString().PadLeft(len, '0');
                    }
                }
                else
                {
                    Code = Code.Substring(0, 1) + (Convert.ToInt32(Code.Substring(1, len)) + 1);
                }
            }
            return Pre + Code;
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
