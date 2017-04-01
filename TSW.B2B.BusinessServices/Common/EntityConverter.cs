namespace TSW.B2B.BusinessServices.Common {
	using System;
	using System.Collections.Generic;
	using AutoMapper;
	using BusinessObjects;
	public static class EntityConverter {

		public static readonly IMapper TswMapper = new MapperConfiguration(
							 cfg =>
							 {
								 //cfg.AddProfile(new AutoMapLogInfoToContextReader());
								 //cfg.AddProfile(new ConvertUIToISOFormDetails());
								 cfg.CreateMissingTypeMaps = true;

								 //cfg.CreateMap<Entities.ProjectEntity, BusinessObjects.MyProjectGridDetails>()
								 //     .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.ProjectId))
								 //     .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.ProjectName));

								 cfg.CreateMap<Entities.User, BusinessObjects.User>();

								 cfg.CreateMap<BusinessObjects.User, Entities.User>();
								 cfg.CreateMap<Entities.Item, BusinessObjects.Item>();

								 cfg.CreateMap<BusinessObjects.Item, Entities.Item>();

							 }).CreateMapper();

		public static TDestination ConvertEntityToModel<TSource, TDestination>(TSource data) {
			MapperConfiguration mapperConfiguration = new MapperConfiguration(
						 cfg =>
						 {
							 cfg.CreateMap<TSource, TDestination>();
						 });
			var mapper = mapperConfiguration.CreateMapper();
			return mapper.Map<TDestination>(data);
		}

		public static IEnumerable<TDestination> ConvertEntityToModel<TSource, TDestination>(IEnumerable<TSource> data) {
			MapperConfiguration mapperConfiguration = new MapperConfiguration(
						 cfg =>
						 {
							 cfg.CreateMap<TSource, TDestination>();
						 });
			var mapper = mapperConfiguration.CreateMapper();
			return mapper.Map<IEnumerable<TDestination>>(data);
		}

		public static BusinessObjects.User ConvertEntityToModel(Entities.User entityData) {
			return TswMapper.Map<BusinessObjects.User>(entityData);
		}
		public static Entities.User ConvertModelToEntity(BusinessObjects.User entityData) {
			return TswMapper.Map<Entities.User>(entityData);
		}
		public static TDestination ConvertModelToEntity<TSource, TDestination>(TSource modelData) {
			return TswMapper.Map<TDestination>(modelData);
		}
		public static IEnumerable<TDestination> ConvertDataEntityToModel<TSource, TDestination>(IEnumerable<TSource> entityList) {
			return TswMapper.Map<IEnumerable<TDestination>>(entityList);
		}
	}
}