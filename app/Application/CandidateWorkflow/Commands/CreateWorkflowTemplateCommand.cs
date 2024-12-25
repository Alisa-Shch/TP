namespace Application
{
    public class CreateWorkflowTemplateCommand : IRequest<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}