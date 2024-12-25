namespace Application
{
    public class GetCandidatesQueryHandler : IRequestHandler<GetCandidatesQuery, IReadOnlyCollection<Domain.Candidate>>
    {
        private readonly ICandidateWorkflowRepository _repository;

        public GetCandidatesQueryHandler(ICandidateWorkflowRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<IReadOnlyCollection<Domain.Candidate>> Handle(GetCandidatesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetCandidates(cancellationToken);
        }
    }
}