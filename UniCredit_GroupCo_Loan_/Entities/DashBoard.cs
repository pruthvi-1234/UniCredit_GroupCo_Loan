using System;
using System.Collections.Generic;

namespace UniCredit_GroupCo_Loan.BusinessEntities;

public partial class DashBoard
{
    public int Position { get; set; }

    public string? Name { get; set; }

    public string? Symbol { get; set; }

    public decimal? Weight { get; set; }

    public string? Location { get; set; }
}
