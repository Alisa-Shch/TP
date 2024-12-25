namespace Application
{
    public class CreateWorkflowTemplateCommandHandler : IRequestHandler<CreateWorkflowTemplateCommand, Guid>
    {
        private readonly IWorkflowTemplateRepository _repository;

        public CreateWorkflowTemplateCommandHandler(IWorkflowTemplateRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<Guid> Handle(CreateWorkflowTemplateCommand request, CancellationToken cancellationToken)
        {
            var vacancy = Domain.WorkflowTemplate.Create(request.Title, request.Description);
            await _repository.Create(vacancy, cancellationToken);
            return vacancy.Id;
        }
    }
}