namespace Application
{
    public interface ICandidateWorkflowRepository
    {
        Task<IReadOnlyCollection<Domain.Candidate>> GetCandidates(CancellationToken cancellationToken);
        Task<Domain.Candidate> GetById(Guid candidateId, CancellationToken cancellationToken);
        Task Create(Domain.Candidate candidate, CancellationToken cancellationToken);
        Task<IReadOnlyCollection<Domain.CandidateWorkflow>> GetByUserId(Guid userId, bool isOpenOnly, CancellationToken cancellationToken);

    }
}