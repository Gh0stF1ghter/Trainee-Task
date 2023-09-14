using AutoMapper;
using Logic.Models;
using Warehouse_Trainee_Task.Resources;

namespace Warehouse_Trainee_Task.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Department, DepartmentResource>();
            CreateMap<Worker, WorkerResource>();
            CreateMap<Product, ProductResource>();

            CreateMap<DepartmentResource, Department>();
            CreateMap<WorkerResource, Worker>();
            CreateMap<ProductResource, Product>();
        }
    }
}
