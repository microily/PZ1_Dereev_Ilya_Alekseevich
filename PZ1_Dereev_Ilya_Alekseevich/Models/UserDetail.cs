using System;
using System.Collections.Generic;

namespace PZ1_Dereev_Ilya_Alekseevich.Models;

public partial class UserDetail
{
    public long Id { get; set; }

    public long Userid { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Patronymic { get; set; }

    public virtual User User { get; set; } = null!;
}
