namespace Application
{
    public class CreateCandidateWorkflowCommandHandler : IRequestHandler<CreateCandidateWorkflowCommand, Guid>
    {
        private readonly ICandidateWorkflowRepository _workflowRepository;
        private readonly IWorkflowTemplateRepository _workflowTemplateRepository;

        public CreateCandidateWorkflowCommandHandler(IWorkflowTemplateRepository workflowTemplateRepository, ICandidateWorkflowRepository workflowRepository)
        {
            ArgumentException.ThrowIfNullOrEmpty(nameof(workflowTemplateRepository));
            ArgumentException.ThrowIfNullOrEmpty(nameof(workflowRepository));

            _workflowTemplateRepository = workflowTemplateRepository;
            _workflowRepository = workflowRepository;
        }

        public async Task<Guid> Handle(CreateCandidateWorkflowCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var workflowTemplate = await _workflowTemplateRepository.GetById(request.WorkflowTemplateId, cancellationToken);
            if (workflowTemplate == null)
            {
                throw new InvalidOperationException(nameof(workflowTemplate));
            }

            var workflowSteps = workflowTemplate.Steps.Select(s => Domain.CandidateWorkflowStep.Create(templateStep)).ToList();
            var workflow = Domain.CandidateWorkflow.Create(workflowSteps);
            var candidate = Domain.Candidate.Create(request.VacancyId, request.ReferralId, request.Document, workflow);

            await _workflowRepository.Create(candidate, cancellationToken);

            return candidate.Id;
        }
    }
}