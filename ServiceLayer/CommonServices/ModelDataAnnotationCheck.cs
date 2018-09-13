using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ServiceLayer.CommonServices
{
    public class ModelDataAnnotationCheck : IModelDataAnnotationCheck
    {
        public void ValidateModelDataAnnotations<TTaskModel>(TTaskModel taskModel)
        {
            ICollection<ValidationResult> validationResultList = new List<ValidationResult>();
            ValidationContext validationContext = new ValidationContext(taskModel, null, null);

            StringBuilder stringBuilder = new StringBuilder();
            if (!Validator.TryValidateObject(taskModel, validationContext, validationResultList, validateAllProperties: true))
            {
                foreach (ValidationResult validationResult in validationResultList)
                {
                    stringBuilder.Append(validationResult.ErrorMessage).AppendLine();
                }
            }

            if (validationResultList.Count > 0)
            {
                throw new ArgumentException(stringBuilder.ToString());
            }

        }
    }
}
