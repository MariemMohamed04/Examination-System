﻿using AutoMapper;
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
            CreateMap<InstructorViewModel, Instructor>().ReverseMap();
            CreateMap<StudentViewModel, Student>().ReverseMap();
            CreateMap<CrsDeptViewModel, CourseDepartment>().ReverseMap();
            CreateMap<ReportOneViewModel, Student>().ReverseMap();
            CreateMap<ExamViewModel, Exam>().ReverseMap();
            CreateMap<QuestionViewModel, Question>().ReverseMap();
            CreateMap<ChoiceViewModel, Choice>().ReverseMap();



            CreateMap<CourseViewModel, Course>().ReverseMap();
            CreateMap<TopicViewModel, Topic>().ReverseMap();
            CreateMap<CrsInstViewModel, CourseInstructor>().ReverseMap();
            CreateMap<CrsStudentViewModel, CourseStudent>().ReverseMap();
        }
    }
}
