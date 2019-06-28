using AutoMapper;
using PostManager.Common.Models;
using PostManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostManager.BL.Profiles
{
    public class FeedsProfile : Profile
    {
        public FeedsProfile()
        {
            CreateMap<CreateFeedRequest, Feed>()
                .ForMember(dest => dest.RelatedToUser, 
                           opt => opt.MapFrom(src => src.RelatedToUser));
        }
    }
}
