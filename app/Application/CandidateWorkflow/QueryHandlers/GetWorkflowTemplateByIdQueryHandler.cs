namespace Application
{
    public class GetWorkflowTemplateByIdQueryHandler : IRequestHandler<GetWorkflowTemplateByIdQuery, Domain.WorkflowTemplate>
    {
        private readonly IWorkflowTemplateRepository _repository;

        public GetWorkflowTemplateByIdQueryHandler(IWorkflowTemplateRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<Domain.WorkflowTemplate> Handle(GetWorkflowTemplateByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetById(request.WorkflowTemplateId, cancellationToken)
                ?? throw new KeyNotFoundException($"Vacancy with ID {request.WorkflowTemplateId} not found.");
        }
    }
}