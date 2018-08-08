using MvcNumberSequenceDemo.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcNumberSequenceDemo.ViewModels
{
    public class SequenceViewModel
    {
        public IEnumerable<SequenceTypeSummary> AvailableSequenceTypes { get; set; }

        public string SelectedSequenceType { get; set; }

        [Range(0, 100)]
        public int RequestedNumberOfItems { get; set; }

        public IEnumerable<string> SequenceItems { get; set; }

    }
}