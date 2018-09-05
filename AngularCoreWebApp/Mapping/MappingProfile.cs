
using AngularCoreWebApp.Controllers.Resources;
using AngularCoreWebApp.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularCoreWebApp.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to Api Resource
            CreateMap<Make, MakeResource>();
            CreateMap<Model, ModelResource>();
            CreateMap<Feature, FeatureResource>();
            CreateMap<Vehicle, VehicleResource>()
                .ForMember(vr => vr.Contact, opt => opt.MapFrom(v => new ContactResource { Name = v.ContactName, Email = v.ContactEmail, Phone = v.ContactPhone }))
                .ForMember(vr => vr.Features, opt => opt.MapFrom(v => v.Features.Select(vf => vf.FeatureId)));

            //API Resource to Domain
            CreateMap<VehicleResource, Vehicle>()
                .ForMember(v => v.Id, opt => opt.Ignore())
                .ForMember(v => v.ContactName, opt => opt.MapFrom(vr => vr.Contact.Name))
                .ForMember(v => v.ContactEmail, opt => opt.MapFrom(vr => vr.Contact.Email))
                .ForMember(v => v.ContactPhone, opt => opt.MapFrom(vr => vr.Contact.Phone))
                .ForMember(v => v.Features, opt => opt.Ignore())
                .AfterMap((vr, v) =>
                {
                    //look at section 4 lesson 58 on how to rewrite these code blocks into linq, which will be useful for unit testing

                    //remove unselected features

                    var removedFeatures = new List<VehicleFeature>();
                    foreach(var f in v.Features)
                    {
                        if (!vr.Features.Contains(f.FeatureId))
                            removedFeatures.Add(f);
                    }

                    foreach (var f in removedFeatures)
                    {
                        v.Features.Remove(f);
                    }
                    //Add new Features
                    foreach (var id in vr.Features)
                    {
                        if (!v.Features.Any(f => f.FeatureId == id))
                        {
                            v.Features.Add(new VehicleFeature { FeatureId = id });
                        }
                    }
                });
        }
    }
}
