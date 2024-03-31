using HackAUBG6.Core.Contracts;
using HackAUBG6.Core.DTOs;
using HackAUBG6.Infrastructure;
using HackAUBG6.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HackAUBG6.Controllers
{
    [Authorize]
    public class SortingController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IGetDataService service;
        private readonly IDisplayDataService serviceDisplay;

        public SortingController(ILogger<HomeController> _logger, IGetDataService _service, IDisplayDataService _serviceDisplay)
        {
            logger = _logger;
            service = _service;
            serviceDisplay = _serviceDisplay;
        }

        public async Task<IActionResult> Sorting()
        {
           var models = await serviceDisplay.GetAllBillsAndOrdersByUserId(User.Id());

            return View(models);
        }

        public async Task<IActionResult> Data()
        {
            try
            {
                GetDataBillDTO dataBillDTO = null;
                using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
                {
                    string jsonData = reader.ReadToEndAsync().Result;

                    dataBillDTO = service.AllBill(jsonData);
                    PerformValidationForModel<GetDataBillDTO>(dataBillDTO, ModelState);

                    if (!ModelState.IsValid)
                    {
                        return BadRequest();
                    }

                    if (!await service.SaveBillAsync(dataBillDTO))
                    {
                        ModelState.AddModelError(dataBillDTO.DateTime, "The date wasn't in the correct format");
                    }
                    //Changing this later if we can
                    if (!ModelState.IsValid)
                    {
                        return BadRequest();
                    }
                }
                return Ok();
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                return BadRequest("Error processing data: " + ex.Message);
            }

        }

        private void PerformValidationForModel<T>(T formModel, ModelStateDictionary modelState)
        {
            var validationResults = new List<ValidationResult>();

            // validation
                var currentValidationResults = new List<ValidationResult>();
                var context = new ValidationContext(formModel, null, null);
                bool isValid = Validator.TryValidateObject(formModel, context, currentValidationResults, true);
                if (currentValidationResults.Count > 0)
                {
                    validationResults.AddRange(currentValidationResults);
                }
           

            if (validationResults.Count > 0)
            {
                foreach (ValidationResult validationResult in validationResults)
                {
                    modelState.AddModelError("error", validationResult.ErrorMessage);
                }
            }
        }
    }
}
