using System;
using System.Collections.Generic;

namespace UniCredit_GroupCo_Loan.BusinessEntities;

public partial class UserRegistration
{
    public int Id { get; set; }

    public string? UserName { get; set; }

    public string? Email { get; set; }

    public string? FirstName { get; set; }

    public string? Password { get; set; }
}
