using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDAL _blogDal;
        public BlogManager(IBlogDAL blogDal)
        {
            _blogDal = blogDal;
        }
		public List<Blog> GetBlogListWithCategory()
		{
			return _blogDal.GetListWithCategory();
		}
		public Blog GetById(int id)
        {
            return _blogDal.GetById(id);
        }
        public List<Blog> GetBlogById(int id)
        {
            return _blogDal.GetListAll(x=>x.BlogID == id);
        }
        public List<Blog> GetList()
        {
           return _blogDal.GetListAll();
        }
        public List<Blog> GetLastThreeBlog()
        {
            return _blogDal.GetListAll().TakeLast(3).ToList();
        }
		public List<Blog> GetBlogListByWriter(int id)
		{
            return _blogDal.GetListAll(a => a.WriterID == id);
		}

        public List<Blog> TGetListWithCategoryByWriter(int id)
        {
            return _blogDal.GetListWithCategoryByWriter(id);
        }
        public void TAdd(Blog t)
        {
           _blogDal.Insert(t);
        }
        public void TDelete(Blog t)
        {
            _blogDal.Delete(t);
        }
        public void TUpdate(Blog t)
        {
           _blogDal.Update(t);
        }
    }
}
