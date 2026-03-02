using System;
using System.Collections.Generic;

namespace ITCompanyApp2.Models;

public partial class AssignmentInProject
{
    public int Id { get; set; }

    public int IdProject { get; set; }

    public short IdUser { get; set; }

    public short IdRole { get; set; }

    public virtual Project Project { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
