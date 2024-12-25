﻿namespace Application
{
    public class CandidateWorkflow
    {
        public Guid Id { get; }
        public DateTime CreatedAt { get; }
        public Candidate Candidate { get; }
        public IReadOnlyCollection<CandidateWorkflowStep> Steps { get; }

        public CandidateWorkflow(Guid id, IReadOnlyCollection<CandidateWorkflowStep> steps, DateTime createdAt, Candidate candidate)
        {
            ArgumentException.ThrowIfNullOrEmpty(nameof(id));
            ArgumentException.ThrowIfNullOrEmpty(nameof(steps));
            ArgumentException.ThrowIfNullOrEmpty(nameof(createdAt));
            ArgumentException.ThrowIfNullOrEmpty(nameof(candidate));

            Id = id;
            Steps = steps;
            CreatedAt = createdAt;
            Candidate = candidate;
        }
    }
}