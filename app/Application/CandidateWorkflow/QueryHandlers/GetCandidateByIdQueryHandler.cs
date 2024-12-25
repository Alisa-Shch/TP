namespace Application
{
    public class GetCandidateByIdQueryHandler : IRequestHandler<GetCandidateByIdQuery, Domain.Candidate>
    {
        private readonly ICandidateWorkflowRepository _repository;

        public GetCandidateByIdQueryHandler(ICandidateWorkflowRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<Domain.Candidate> Handle(GetCandidateByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetById(request.CandidateId, cancellationToken)
                ?? throw new KeyNotFoundException($"Candidate with ID {request.CandidateId} not found.");
        }
    }
}