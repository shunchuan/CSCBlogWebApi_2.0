using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSCBlogWebApi_2_0.Model.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CSCBlogWebApi_2_0.Extend
{
    public static class ModelStateExtend
    {
        /// <summary>
        /// 将modelState的第一条转为ResultMessage
        /// </summary>
        /// <param name="modelState"></param>
        /// <returns></returns>
        public static ResultMessage ToResultMessageFirst(this ModelStateDictionary modelState)
        {
            var list = modelState.ToList();
            if (list.Count() == 0)
            {
                return new ResultMessage() { Status = "0", Message = "Can not find ModelStateDictionary" };
            }
            ModelErrorCollection modelErrors = list[0].Value.Errors;
            if (modelErrors.Count() == 0)
            {
                return new ResultMessage() { Status = "0", Message = "Can not find ModelErrorCollection" };
            }
            return new ResultMessage() { Status = "0", Message = modelErrors[0].ErrorMessage };
        }

        public static IActionResult ToActionResult(ResultMessage result)
        {
            if (result.Status != "1")
            {
                return new BadRequestObjectResult(result);
            }
            else return new OkObjectResult(result);
        }
        public static IActionResult ToActionResultFirst(this ModelStateDictionary modelState)
        {
            var result = ToResultMessageFirst(modelState);
            return ToActionResult(result);
        }

    }
}
