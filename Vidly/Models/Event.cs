using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter event name")]
        [StringLength(150)]
        public string EventName { get; set; }

        [Range(10, 60000)]
        public int? NumberOfAttendees { get; set; }

        [DataType(DataType.Date)]
        public DateTime? EventDate { get; set; }

        public DressCode DressCode { get; set; }
        [Display(Name = "Dress Code")]
        public byte DressCodeId { get; set; }

        public FunctionType FunctionType { get; set; }
        [Display(Name = "Function Type")]
        public byte FunctionTypeId { get; set; }

        [Display(Name = "Food & Drinks Provided?")]
        public bool IsFoodIncluded { get; set; }

        [StringLength(250)]
        public string Notes { get; set; }

        [Required(ErrorMessage = "Please enter Address of Event")]
        [StringLength(150)]
        public string Address { get; set; }

    }
}