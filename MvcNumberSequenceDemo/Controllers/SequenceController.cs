using MvcNumberSequenceDemo.ViewModels;
using SequenceGenerator;
using SequenceGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcNumberSequenceDemo.Controllers
{
    public class SequenceController : Controller
    {
        private ISequenceService _sequenceService;
        private ISequenceStrategyFactory _sequenceStrategyFactory;

        // Constructor
        public SequenceController(
            ISequenceService sequenceService, 
            ISequenceStrategyFactory sequenceStrategyFactory)
        {
            _sequenceService = sequenceService;
            _sequenceStrategyFactory = sequenceStrategyFactory;
        }


        // GET: Sequence
        public ActionResult Index()
        {
            var sequenceTypes = _sequenceService.GetAvailableSequenceTypesInfo();

            var model =
                new SequenceViewModel
                {
                    AvailableSequenceTypes = sequenceTypes,
                };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GenerateSequence(string selectedSequenceType, int requestedNumberOfItems)
        {
            var sequenceType = (SequenceType)Enum.Parse(typeof(SequenceType), selectedSequenceType, ignoreCase: true);
            var strategy = _sequenceStrategyFactory.CreateSequenceStrategy(sequenceType);
            var sequenceItems = _sequenceService.GenerateSequence(strategy, requestedNumberOfItems);
            var sequenceTypes = _sequenceService.GetAvailableSequenceTypesInfo();

            var model = 
                new SequenceViewModel
                {
                    AvailableSequenceTypes = sequenceTypes,
                    SelectedSequenceType = selectedSequenceType,
                    RequestedNumberOfItems = requestedNumberOfItems,
                    SequenceItems = sequenceItems
                };

            return View(viewName: "Index", model: model);
        }

    }
}