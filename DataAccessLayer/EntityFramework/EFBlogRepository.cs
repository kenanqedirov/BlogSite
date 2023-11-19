using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
	public class EFBlogRepository : GenericRepository<Blog>, IBlogDAL
	{
		public List<Blog> GetListWithCategory()
		{
			using(var c = new Context())
			{
				return c.Blogs.Include(b => b.Category).ToList();
			}
			 
		}
	}
}
