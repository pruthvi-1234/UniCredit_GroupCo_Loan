﻿using System;
using System.Collections.Generic;

namespace UniCredit_GroupCo_Loan.BusinessEntities;

public partial class Hotel
{
    public int HotelId { get; set; }

    public string? HotelName { get; set; }

    public string? HotelLocation { get; set; }

    public string? HotelImage { get; set; }

    public string? HotelDescription { get; set; }
}
