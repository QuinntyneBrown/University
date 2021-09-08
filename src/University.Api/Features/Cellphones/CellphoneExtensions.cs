using University.Api.Models;

namespace University.Api.Features
{
    public static class CellphoneExtensions
    {
        public static CellphoneDto ToDto(this Cellphone cellphone)
        {
            return new()
            {
                PhoneId = cellphone.PhoneId,
                PhoneName = cellphone.PhoneName,
                PhoneModel = cellphone.PhoneModel,
                PhoneYear = cellphone.PhoneYear,
                Color = cellphone.Color
            };
        }
    }
}
