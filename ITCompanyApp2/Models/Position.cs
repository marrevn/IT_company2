using System;
using System.Collections.Generic;

namespace ITCompanyApp2.Models;

public partial class Position
{
    public short Id { get; set; }

    public string PositionName { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
