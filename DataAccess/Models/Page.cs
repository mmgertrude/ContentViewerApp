using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.Models
{
    public class Page
    {
        [Required]
        [Display(Name = "Title")]
        [Column(TypeName = "nvarchar(max)")]
        public string PageTitle { get; set; }

        [Required]
        [EnumDataType(typeof(Status))]
        [Display(Name = "Page Status")]
        public Status PageStatus { get; set; }

               
        [Key]
        [Display(Name = "Page Id")]
        public int PageId { get; set; }


        [Required]
        [Display(Name = "Content")]
        [Column(TypeName = "nvarchar(max)")]
        public string Content { get; set; }


    }

    public enum Status
    {
        Active,
        Inactive
    }
}
