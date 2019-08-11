using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
  public class Customer
  {
    public int Id { get; set; }
    [Required]
    [StringLength(255)]
    public string Name { get; set; }

    [Display(Name = "Date of birth")]
    [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
    public DateTime? Birthdate { get; set; }

    public bool IsSubscribedToNewsletter { get; set; }

    [Display(Name = "Membership type")]
    public int MembershipTypeId { get; set; }
    public virtual MembershipType MembershipType { get; set; }

  }
}