using System;
using System.Collections.Generic;

namespace ITCompanyApp2.Models;

public partial class Project
{
    public int Id { get; set; }

    public string NameProject { get; set; } = null!;

    public short IdStatus { get; set; }

    public DateOnly DateStart { get; set; }

    public short IdManager { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<AssignmentInProject> AssignmentInProjects { get; set; } = new List<AssignmentInProject>();

    public virtual User User { get; set; } = null!;

    public virtual Status Status { get; set; } = null!;

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
