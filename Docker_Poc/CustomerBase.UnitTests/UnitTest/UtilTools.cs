using CustomerBase.API.Business.Domain.Handlers.PaginationHandler;
using Microsoft.EntityFrameworkCore.Query;
using Moq;
using System.Linq.Expressions;

namespace CustomerBase.UnitTests.UnitTest;
public sealed class UtilTools
{
    //public static IFormFile BuildIFormFile(string extension = "pdf")
    //{
    //    var bytes = Encoding.UTF8.GetBytes("This is a dummy file");

    //    return new FormFile(new MemoryStream(bytes), 0, bytes.Length, "Data", $"image.{extension}")
    //    {
    //        Headers = new HeaderDictionary(),
    //        ContentType = "image/jpeg",
    //        ContentDisposition = $"form-data; name=\"Image\"; filename=\"image.{extension}\""
    //    };
    //}

    //public static ClaimsPrincipal BuildClaimPrincipal(string name, EUserType userType)
    //{
    //    return new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
    //    {
    //            new (ClaimTypes.Name, name),
    //            new (ClaimTypes.Actor, EUserType.Client.ToString())
    //    }));
    //}

    public static PageList<T> BuildPageList<T>(List<T> entityList, int nextPage = 1) where T : class
    {
        var pageSize = 10;
        var pageNumber = 1;

        return new PageList<T>(entityList, entityList.Count, pageNumber, pageSize);
    }

    public static PageParams BuildPageParams(int pageNumber = 1, int pageSize = 10)
    {
        return new PageParams
        {
            PageNumber = pageNumber,
            PageSize = pageSize,
        };
    }

    public static Func<IQueryable<T>, IIncludableQueryable<T, object>> BuildQueryableIncludeFunc<T>() where T : class =>
           It.IsAny<Func<IQueryable<T>, IIncludableQueryable<T, object>>>();

    public static Expression<Func<T, bool>> BuildPredicateFunc<T>() where T : class =>
           It.IsAny<Expression<Func<T, bool>>>();

    public static Expression<Func<T, T>> BuildSelectorFunc<T>() where T : class =>
        It.IsAny<Expression<Func<T, T>>>();
}
