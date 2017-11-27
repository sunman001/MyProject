using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Configuration;
using System.Net.Http;
using Dapper.Contrib.Extensions;
using Dapper.Infrastructure;
using Dapper.Model;

namespace Dapper
{
    /// <summary>
    /// orm 框架的核心思想是对象关系映射，orm 是将表与表之间的操作，映射成对象与对象之间的操作
    /// orm 叫做 Object Relationship Mapper 也就是可以用object 来map 我们的db 
    /// </summary>
   public  class DapperSql
    {
        private IDbConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

        /// <summary>
        /// 直接语句执行
        /// </summary>
        /// <returns></returns>
        public bool Insert()
        {
            var  result = connection.Execute("Insert into Users values (@UserName,@Email,@Address)",new {UserName="jack",Email="234567@qq.com",Address="上海"});

            return result>0;
        }


        /// <summary>
        /// 泛型执行插入方法
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public User Insert(User  user)
        {
            using (connection)
            {
               var id = connection.Insert(user);            
                return user;

            }
        }

        public bool InsertBulk()
        {
            var usersList = Enumerable.Range(0, 10).Select(i => new User()
            {
                Email = i + "qq.com",
                UserName = i + "Test"
            });
            var result = connection.Execute("Insert into Users values (@UserName,@Email,@Address)",usersList);
            return result > 0;
        }

        /// <summary>
        /// 查询列表
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public  List<User> SelectList(string userName)
        {
           
          var query=  connection.Query<User>("select * from Users where UserName=@UserName",
                new {userName = userName});
            return query.ToList();

        }

        /// <summary>
        /// 语句修改方法
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            var result = connection.Execute("Update User set UserName='111' where Userid=1");
            return result > 0;
        }

        public bool Update(User user)
        {
            using (connection)
            {
                return connection.Update(user);
            }
        }

        public bool Delete(User user)
        {
            var success = connection.Execute("delete user where userid=1");
            return success > 0;
        }

        public int SelectId()
        {
            var Id = connection.Query<int>("select ID from user where username='11'").FirstOrDefault();
            return Id;
        }

        public List<Customer> CustomersList()
        {
            var sql= @"select * from #Customer p 
                left join #Users u on u.Id = p.OwnerId 
                  Order by p.Id";
            var data = connection.Query<Customer, Role, Customer>(sql, (Customer, Role) =>
            {
                Customer.Role = Role;
                return Customer;
            });
            var customer = data.First();
            
            return data.ToList();
        }

       /// <summary>
       /// 可执行多条sql语句
       /// </summary>
        public void QueryMultiple()

        {
            var sql = @"
                     select * from Customers where CustomerId=@id
                     select * from User where UserId=@id
                    ";
            using (var multi=connection.QueryMultiple(sql,new {id=SelectId()}))
            {
                var customer = multi.Read<Customer>().Single();
                var user = multi.Read<User>().ToList();

            }
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        public User  StoredProcedures()
        {
            var User = connection.Query<User>("spGetUser", new {Id = 1}, commandType: CommandType.StoredProcedure)
                .SingleOrDefault();
            return User;
        }
        /// <summary>
        /// 存储过程扩展(可以接受存储过程输出的参数)
        /// </summary>
        public void StoreProceduresExent()
        {
            var p =new DynamicParameters();
            p.Add("@a", 11);
            p.Add("@b", dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
            connection.Execute("spMagicProc", p, commandType: CommandType.StoredProcedure);
            int b = p.Get<int>("@b");
            int c = p.Get<int>("@c");
        }

    }
}
