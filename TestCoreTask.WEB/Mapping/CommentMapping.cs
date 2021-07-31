using AutoMapper;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestCoreTask.WEB.Controllers.Models;

namespace TestCoreTask.WEB.Mapping
{
    public class CommentMapping : Profile
    {
        public CommentMapping()
        {
            CreateMap<Comment, CommentModel>().ReverseMap();
        }
    }
}
