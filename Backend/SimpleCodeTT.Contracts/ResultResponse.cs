using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCodeTT.Contracts
{
    public class ResultResponse<T>
    {
        public bool IsSuccess { get; set; }
        public T Result { get; set; }
        //public string ErrorMessage { get; set; }

        public static ResultResponse<T> GetSuccessResponse()
        {
            return new ResultResponse<T>
            {
                IsSuccess = true
            };
        }

        public static ResultResponse<T> GetSuccessResponse(T result)
        {
            return new ResultResponse<T>
            {
                Result = result,
                IsSuccess = true
            };
        }

        public static ResultResponse<T> GetFailResponse()
        {
            return new ResultResponse<T>
            {
                IsSuccess = false,
                //ErrorMessage = errorMessage
            };
        }
    }
}
