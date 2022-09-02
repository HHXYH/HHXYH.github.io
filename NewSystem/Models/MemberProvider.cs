using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewSystem.Models
{
    /// <summary>
    /// member表的操作类
    /// </summary>
    public class MemberProvider : IProvider<member>
    {
        private NewsDBEntities db = new NewsDBEntities();
        public int Delete(member t)
        {
            if (t == null) return 0;
            var model = db.member.ToList().FirstOrDefault(item => item.Name == t.Name);
            if (model == null) return 0;
            db.member.Remove(model);
            int count = db.SaveChanges();
            return count;

        }

        public int Insert(member t)
        {
            if (t == null) return 0;
            db.member.Add(t);
            int count = db.SaveChanges();
            return count;
        }

        public List<member> Select()
        {
            return db.member.ToList();
        }

        public int Update(member t)
        {
            if (t == null) return 0;
            var model = db.member.ToList().FirstOrDefault(item => item.Name == t.Name);
            if (model == null) return 0;
            model.Password = t.Password;
            int count = db.SaveChanges();
            return count;
        }
    }
}