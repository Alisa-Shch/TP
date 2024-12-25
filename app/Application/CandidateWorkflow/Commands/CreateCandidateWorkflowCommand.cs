namespace Application
{
    public class CreateCandidateWorkflowCommand : IRequest<Guid>
    {
        public Guid VacancyId { get; private set; }
        public Guid? ReferralId { get; private set; }
        public Domain.CandidateDocument Document { get; private set; }
        public Guid WorkflowTemplateId { get; private set; }

        public CreateCandidateWorkflowCommand(Guid vacancyId, Guid referralId, Domain.CandidateDocument document)
        {
            ArgumentException.ThrowIfNullOrEmpty(nameof(vacancyId));
            ArgumentException.ThrowIfNullOrEmpty(nameof(referralId));
            ArgumentNullException.ThrowIfNull(nameof(document));

            VacancyId = vacancyId;
            ReferralId = referralId;
            Document = document;        }
    }
}