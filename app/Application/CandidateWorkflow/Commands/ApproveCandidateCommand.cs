namespace Application
{
    public class ApproveCandidateCommand : IRequest
    {
        public Guid CandidateId { get; set; }
        public string Approver { get; set; }
        public string Comment { get; set; }
    }
}