using System;
using System.Collections.Generic;

namespace ITCompanyApp2.Models;

public partial class User
{
    public short Id { get; set; }

    public string Fio { get; set; } = null!;

    public short IdPosition { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<AssignmentInProject> AssignmentInProjects { get; set; } = new List<AssignmentInProject>();

    public virtual Position Position { get; set; } = null!;

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
