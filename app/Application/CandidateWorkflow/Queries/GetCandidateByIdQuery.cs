namespace Application
{
    public class GetCandidateByIdQuery : IRequest<Domain.Candidate>
    {
        public Guid CandidateId { get; set; }
    }
}