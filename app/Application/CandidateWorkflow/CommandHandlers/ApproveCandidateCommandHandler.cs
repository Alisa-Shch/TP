using Domain;

namespace Application
{
    public class ApproveCandidateCommandHandler : IRequestHandler<ApproveCandidateCommand>
    {
        private readonly ICandidateWorkflowRepository _repository;

        public ApproveCandidateCommandHandler(ICandidateWorkflowRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task Handle(ApproveCandidateCommand request, CancellationToken cancellationToken)
        {
            var candidate = await _repository.GetById(request.CandidateId, cancellationToken)
                ?? throw new KeyNotFoundException($"Candidate with ID {request.CandidateId} not found.");

            candidate.Approve(request.Approver, request.Comment);
        }
    }
}