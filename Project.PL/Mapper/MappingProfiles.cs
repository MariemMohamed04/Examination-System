using AutoMapper;
using Project.DAL.Entities;
using Project.PL.ViewModel;

namespace Project.PL.Mapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
                CreateMap<BranchViewModel, Branch>().ReverseMap();
                CreateMap<DepartmentViewModel, Department>().ReverseMap();
        }
    }
}
