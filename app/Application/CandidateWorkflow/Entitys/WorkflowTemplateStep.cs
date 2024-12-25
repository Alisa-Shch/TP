namespace Application
{
    public class WorkflowTemplateStep
    {
        public string Name { get; init; }
        public int Order { get; init; }

        public WorkflowTemplateStep(string name, int order)
        {
            ArgumentException.ThrowIfNullOrEmpty(nameof(name));
            ArgumentException.ThrowIfNullOrEmpty(nameof(order));

            Name = name;
            Order = order;
        }
    }
}