﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
  public class Min18YearIfMember : ValidationAttribute
  {
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
      var customer = (Customer)validationContext.ObjectInstance;
      if (customer.MembershipTypeId == 0)
        return ValidationResult.Success;
      if (customer.Birthdate == null)
        return new ValidationResult("Birthdate is required");
      var age = DateTime.Today.Year - customer.Birthdate.Value.Year;

      return (age >= 18)
        ? ValidationResult.Success
        : new ValidationResult("Customer age must be more than 18");

    }
  }
}