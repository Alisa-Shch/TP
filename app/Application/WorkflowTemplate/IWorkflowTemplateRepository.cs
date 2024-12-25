namespace Application
{
    public interface IWorkflowTemplateRepository
    {
        Task Create(Domain.WorkflowTemplate template, CancellationToken cancellationToken);
        Task<IReadOnlyCollection<Domain.WorkflowTemplate>> GetVacancies(CancellationToken cancellationToken);
        Task<WorkflowTemplate> GetById(Guid id, CancellationToken cancellationToken);
    }
}