using backend.Queries;
using backend.Results;
using backend.Validators;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Handler
{

    public class SortNumberHandler   : ISortNumberHandler
    {
        private readonly IValidator<GetStringNumber> _validator;
        ILogger<SortNumberHandler> _logger;

        public SortNumberHandler(IValidator<GetStringNumber> validator, ILogger<SortNumberHandler> logger)
        {
            _validator = validator;
            _logger = logger;
        }

        public IEnumerable<ActualSortResult> GetHistory()
        {
            return Global.listActualSortResrult;
            //throw new NotImplementedException();
        }

        private void SaveHistory(ActualSortResult actualSortResult)
        {
            var result = Global.listActualSortResrult;
            result.Add(actualSortResult);
            Global.listActualSortResrult = result;

        }

        public ActualSortResult SortNumber(GetStringNumber request)
        {
            ActualSortResult result = new ActualSortResult();
            var validationResult = _validator.Validate(request);
            if(!validationResult.IsValid)
            {
                List<ValidationFailure> failures = validationResult.Errors;
                throw new Exception(string.Join(", ", failures));
            }
            string[] subs = request.values.Split(',');
            List<float> subResult = subs.Select(x => float.Parse(x)).OrderBy(x => x).ToList();

            result.ActualResult = string.Join(",", subResult.ConvertAll<string>(x => x.ToString()));
            SaveHistory(result);
            return result;
        }
    }
}
