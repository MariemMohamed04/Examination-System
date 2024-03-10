using Project.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICourseRepo CourseRepo { get; }
        public ITopicRepo TopicRepo { get; }



        public UnitOfWork(ICourseRepo courseRepo, ITopicRepo topicRepo)
        {
            CourseRepo = courseRepo;
            TopicRepo = topicRepo;
        }
    }
}
