using ProjectFlow.Api.Entities;

namespace ProjectFlow.Api.DTOs.Projects;

public sealed record ProjectsCollectionDto
{
    public List<ProjectDto> Data { get; init; }
}

public sealed record ProjectDto
{
    public required string Id { get; init; }
    public required string Name { get; init; }
    public string? Description { get; init; }
    public required string ClientName { get; init; }
    public required ProjectStatus Status { get; init; }
    public required ProjectPriority Priority { get; init; }
    public required TargetDto Target { get; init; }
    public required bool IsArchived { get; init; }
    public DateOnly? EndDate { get; init; }
    public MilestoneDto? Milestone { get; init; }
    public required DateTime CreatedAtUtc { get; init; }
    public DateTime? UpdatedAtUtc { get; init; }
    public DateTime? LastCompletedAtUtc { get; init; }
}

public sealed record TargetDto
{
    public required int Value { get; init; }
    public required string Unit { get; init; }
}

public sealed record MilestoneDto
{
    public required int Target { get; init; }
    public required int Current { get; init; }
}
