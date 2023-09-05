using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramwork;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BusinessLayer.Concrete
{
    public class CommentManager:ICommentService
    {

        ICommentDal _commandDal;

        public CommentManager(ICommentDal commandDal)
        {
            _commandDal = commandDal;
        }
        
        public List<Comment> CommentByStatusTrue()
        {
            return _commandDal.List(x => x.CommentStatus == true);
        }
        public List<Comment> CommentByStatusFalse()
        {
            return _commandDal.List(x => x.CommentStatus == false);
        }
        

        public void CommentStatusChangeToFalse(Comment com)
        {
            Comment comment = _commandDal.Find(x => x.CommentID == com.CommentID);
            comment.CommentStatus = false;
            _commandDal.Update(comment);

        }
        public void CommentStatusChangeToTrue(Comment com)
        {
            Comment comment = _commandDal.Find(x => x.CommentID == com.CommentID);
            comment.CommentStatus = true;
             _commandDal.Update(comment);

        }

        public List<Comment> GetList()
        {
            return _commandDal.List();
        }


        public Comment GetById(int id)
        {
            return _commandDal.GetById(id);
            //return _commentDal.List(x => x.BlogID == id);
        }

        public List<Comment> GetByIdList(int id)
        {
            return _commandDal.List(x => x.BlogID == id);
        }

        public void TAdd(Comment par)
        {
            _commandDal.Insert(par);
        }

        public void TDelete(Comment par)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Comment par)
        {
            _commandDal.Update(par);
        }
    }
}
