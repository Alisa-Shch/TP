namespace Application
{
    public class GetWorkflowTemplateQueryHandler : IRequestHandler<GetWorkflowTemplateQuery, IReadOnlyCollection<Domain.WorkflowTemplate>>
    {
        private readonly IWorkflowTemplateRepository _repository;

        public GetWorkflowTemplateQueryHandler(IWorkflowTemplateRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<IReadOnlyCollection<Domain.WorkflowTemplate>> Handle(GetWorkflowTemplateQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetVacancies(cancellationToken);
        }
    }
}