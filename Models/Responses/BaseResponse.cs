using VehicleGarage.Common.Models.DTOs;

namespace VehicleGarage.Core.Models.Responses
{
    public class BaseResponse<T> where T : BaseDTO
    {
        public int StatusCode { get; set; }
        public string CodeDescription { get; set; }
        public T innerObject { get; set; }
        public string ErrorMessage { get; set; }
    }
}
