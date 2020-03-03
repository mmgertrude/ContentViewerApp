using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess.Models
{
    public class Page
    {
        [Display(Name = "Title")]
        [Column(TypeName = "nvarchar(max)")]
        public string PageTitle { get; set; }


        [EnumDataType(typeof(Status))]
        [Display(Name = "Page Status")]
        public Status PageStatus { get; set; }


        [Display(Name = "Page Number")]
        public int PageNo { get; set; }


        [Key]
        [Display(Name = "Page Id")]
        public int PageId { get; set; }


        [Required]
        [Display(Name = "Description")]
        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; }


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
