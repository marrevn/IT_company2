using System;
using System.Collections.Generic;

namespace ITCompanyApp2.Models;

public partial class Role
{
    public short Id { get; set; }

    public string RoleName { get; set; } = null!;

    public virtual ICollection<AssignmentInProject> AssignmentInProjects { get; set; } = new List<AssignmentInProject>();
}
