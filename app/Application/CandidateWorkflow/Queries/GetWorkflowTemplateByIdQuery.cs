namespace Application
{
    public class GetWorkflowTemplateByIdQuery : IRequest<Domain.WorkflowTemplate>
    {
        public Guid WorkflowTemplateId { get; set; }
    }
}