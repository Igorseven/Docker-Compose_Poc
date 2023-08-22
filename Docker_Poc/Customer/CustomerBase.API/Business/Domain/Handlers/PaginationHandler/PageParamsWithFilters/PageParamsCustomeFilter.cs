using CustomerBase.API.Business.Domain.Enums;
using CustomerBase.API.Business.Domain.Handlers.PaginationHandler;

namespace CustomerBase.API.Business.Domain.Handlers.PaginationHandler.PageParamsWithFilters;
public sealed class PageParamsCustomeFilter : PageParams
{
    public EAddressType? AddressType { get; set; }
    public EEmailType? EmailType { get; set; }
}
