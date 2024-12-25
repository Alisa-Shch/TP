namespace Application
{
    public class RejectCandidateCommand : IRequest
    {
        public Guid CandidateId { get; set; }
        public string Rejector { get; set; }
        public string Comment { get; set; }
    }
}
