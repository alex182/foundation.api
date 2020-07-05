﻿namespace Foundation.Api.Configuration
{
    using AutoMapper;
    using Foundation.Api.Data.Entities;
    using Foundation.Api.Models.ValueToReplaces;

    public class ValueToReplaceProfile : Profile
    {
        public ValueToReplaceProfile()
        {
            //createmap<to this, from this>
            CreateMap<ValueToReplace, ValueToReplaceDto>()
                .ReverseMap();
            CreateMap<ValueToReplaceForCreationDto, ValueToReplace>();
            CreateMap<ValueToReplaceForUpdateDto, ValueToReplace>()
                .ReverseMap();
        }
    }
}