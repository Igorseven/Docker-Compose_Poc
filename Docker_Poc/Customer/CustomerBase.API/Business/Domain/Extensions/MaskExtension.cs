using CustomerBase.API.Business.Domain.Entities;
using System.Text;

namespace CustomerBase.API.Business.Domain.Extensions;

public static class MaskExtension
{
    public static string PhoneNumberMask(this Telephone telephone)
    {
        if (telephone is null) return string.Empty;

        StringBuilder phoneNumberCompose = new();

        phoneNumberCompose.Append('+')
                          .Append(telephone.Ddi)
                          .Append(' ');

        if (telephone.Ddd is not null)
        {
            phoneNumberCompose.Append('(')
                              .Append(telephone.Ddd)
                              .Append(") ");
        }

        if (telephone.PhoneNumber.Length <= 8)
        {
            phoneNumberCompose.Append(telephone.PhoneNumber[..4])
                              .Append('-')
                              .Append(telephone.PhoneNumber[4..]);

        }

        if (telephone.PhoneNumber.Length >= 9)
        {
            phoneNumberCompose.Append(telephone.PhoneNumber[..5])
                              .Append('-')
                              .Append(telephone.PhoneNumber[5..]);

        }

        return phoneNumberCompose.ToString();
    }
}
