namespace Application
{
    public class RejectCandidateCommandHandler : IRequestHandler<RejectCandidateCommand>
    {
        private readonly ICandidateWorkflowRepository _repository;

        public RejectCandidateCommandHandler(ICandidateWorkflowRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task Handle(RejectCandidateCommand request, CancellationToken cancellationToken)
        {
            var candidate = await _repository.GetById(request.CandidateId, cancellationToken)
                ?? throw new KeyNotFoundException($"Candidate with ID {request.CandidateId} not found.");

            candidate.Reject(request.Rejector, request.Comment);
        }
    }
}