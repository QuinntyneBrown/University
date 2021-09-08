using System;
using University.Api.Models;

namespace University.Api.Features
{
    public static class CellphoneExtensions
    {
        public static CellphoneDto ToDto(this Cellphone cellphone)
        {
            return new ()
            {
                CellphoneId = cellphone.PhoneId
            };
        }
        
    }
}
