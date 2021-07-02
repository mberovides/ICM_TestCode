using AutoMapper;

namespace ICM.Integration.Mapping
{
    public class IntegrationProfile : Profile
    {
        public IntegrationProfile()
        {
            CreateMap<Models.LineItem, ICM.Taxes.Calculator.Models.LineItem>();

            CreateMap<Models.OrderInfo, ICM.Taxes.Calculator.Models.OrderInfo>()
                .ForMember(destination => destination.LineItems, opt => opt.Ignore())
                .ForMember(destination => destination.From, opt => opt.Ignore())
                .ForMember(destination => destination.To, opt => opt.Ignore());

            CreateMap<ICM.Taxes.Calculator.Models.LineItem, Models.LineItem>();
        }
    }
}
