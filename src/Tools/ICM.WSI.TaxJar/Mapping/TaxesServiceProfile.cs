using AutoMapper;

namespace ICM.Taxes.Calculator.Mapping
{
    public class TaxesServiceProfile : Profile
    {
        public TaxesServiceProfile()
        {
            CreateMap<Models.GeoLocation, ICM.WSI.TaxJar.Models.TaxJarRate>().ReverseMap();

            CreateMap<ICM.WSI.TaxJar.Models.TaxJarRateData, Models.TaxRateResult>()
                .ForMember(destination => destination.CityRate, opts => opts.MapFrom(source => source.city_rate))
                .ForMember(destination => destination.CountyRate, opts => opts.MapFrom(source => source.county_rate))
                .ForMember(destination => destination.StateRate, opts => opts.MapFrom(source => source.state_rate));

            CreateMap<Models.OrderInfo, ICM.WSI.TaxJar.Models.TaxJarOrder>()
                .ForMember(destination => destination.from_zip, opts => opts.MapFrom(source => source.From.ZipCode))
                .ForMember(destination => destination.from_state, opts => opts.MapFrom(source => source.From.State))
                .ForMember(destination => destination.to_zip, opts => opts.MapFrom(source => source.To.ZipCode))
                .ForMember(destination => destination.to_state, opts => opts.MapFrom(source => source.To.State))
                .ForMember(destination => destination.line_items, opt => opt.Ignore());

            CreateMap<Models.LineItem, ICM.WSI.TaxJar.Models.TaxJarLineItemOrder>();

            CreateMap<WSI.TaxJar.Models.TaxJarOrderData, Models.TaxOrderResult>()
             .ForMember(destination => destination.AmountToCollect, opts => opts.MapFrom(source => source.amount_to_collect))
             .ForMember(destination => destination.OrderTotalAmount, opts => opts.MapFrom(source => source.order_total_amount))
             .ForMember(destination => destination.Rate, opts => opts.MapFrom(source => source.rate))
             .ForMember(destination => destination.Shipping, opts => opts.MapFrom(source => source.shipping))
             .ForMember(destination => destination.TaxSource, opts => opts.MapFrom(source => source.tax_source))
             .ForMember(destination => destination.TaxableAmount, opts => opts.MapFrom(source => source.taxable_amount));

        }
    }
}
