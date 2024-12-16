// Path: Mappings/MappingProfile.cs
using AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // User mappings
        CreateMap<User, UserDto>();
        CreateMap<UserCreateDto, User>();
        
        CreateMap<Role, RoleDto>();
        CreateMap<RoleCreateDto, Role>();

        // Customer mappings
        CreateMap<Customer, CustomerDto>();
        CreateMap<CustomerCreateDto, Customer>();

        // Post mappings
        CreateMap<Post, PostDto>();
        CreateMap<PostCreateDto, Post>();

        // Approval mappings
        CreateMap<Approval, ApprovalDto>();
        CreateMap<ApprovalCreateDto, Approval>();

        // Payment mappings
        CreateMap<Payment, PaymentDto>();
        CreateMap<PaymentCreateDto, Payment>();
    }
}
