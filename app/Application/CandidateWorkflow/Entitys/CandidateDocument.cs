namespace Application
{
    public class CandidateDocument
    {
        public string Name { get; }
        public string WorkExperience { get; }

        public CandidateDocument(string name, string workExperience)
        {
            ArgumentException.ThrowIfNullOrEmpty(nameof(name));
            ArgumentException.ThrowIfNullOrEmpty(nameof(workExperience));

            Name = name;
            WorkExperience = workExperience;
        }
    }
}