using CommonUtility.Models.V1;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interfaces
{
    public interface IEmployeeService
    {
        Task<BaseResponse> GetAllAsync();
        Task<BaseResponse> GetAsync(int filter);
    }
}
