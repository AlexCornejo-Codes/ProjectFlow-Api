namespace ProjectFlow.Api.Entities;

public sealed class Project
{
    public string Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string ClientName { get; set; } = string.Empty;
    public ProjectStatus Status { get; set; }
    public ProjectPriority Priority { get; set; }
    public Target Target { get; set; }
    public bool IsArchived { get; set; }
    public DateOnly? EndDate { get; set; }
    public Milestone? Milestone { get; set; }
    public DateTime CreatedAtUtc { get; set; }
    public DateTime? UpdatedAtUtc { get; set; }
    public DateTime? LastCompletedAtUtc { get; set; }
}

public enum ProjectStatus
{
    Inactive = 0,
    Active = 1,
    Completed = 2
}

public enum ProjectPriority
{
    Low = 0,
    Medium = 1,
    High = 2
}

public sealed class Target
{
    public int Value { get; set; }
    public string Unit { get; set; }
}

public sealed class Milestone
{
    public int Target { get; set; }
    public int Current { get; set; }
}
