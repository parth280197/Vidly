﻿namespace Vidly.Models
{
  public class MembershipType
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public short SignUpFee { get; set; }
    public byte DurationInMonths { get; set; }
    public byte DiscountRate { get; set; }

    //MAGIC NUMBERS FOR CUSTOM VALIDATION
    public static readonly byte Unknown = 0;
    public static readonly byte PayAsYouGo = 1;
  }
}