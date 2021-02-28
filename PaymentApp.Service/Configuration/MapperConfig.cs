using AutoMapper;
using PaymentApp.Entity.Model.Payment;
using PaymentApp.ViewModel.Payment;

namespace PaymentApp.Service.Configuration
{
    public class MapperConfig
    {
        public static MapperConfiguration Configure()
        {
            var mappingConfig = new MapperConfiguration(m =>
            {
                m.CreateMap<PaymentVM, Payment>().ReverseMap();

            });
            return mappingConfig;
        }
        
    }
}
