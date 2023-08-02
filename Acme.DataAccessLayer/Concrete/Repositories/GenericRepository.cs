using Acme.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Acme.DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class 
    {
        public GenericRepository() 
        {
            
        }  
        public SqlConnection DbConnect()
        {
            SqlConnection conn = new SqlConnection("Server=localhost;uid=BURAK\\LENOVO;pwd=252525;Database=AcmeDb;Trusted_Connection=True;");
            conn.Open();
            return conn;
        }

        public int Delete(List<int> id)
        {
            throw new NotImplementedException();
        }
		//Func<T, bool>> filter
		public T Get(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(T P)
        {
            throw new NotImplementedException();
        }

        public List<T> List()
        {
            throw new NotImplementedException();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public int Update(T P)
        {
            throw new NotImplementedException();
        }
    }
}
