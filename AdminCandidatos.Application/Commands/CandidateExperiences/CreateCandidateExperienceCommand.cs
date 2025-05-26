namespace AdminCandidatos.Application.Commands.CandidateExperiences
{
    public class CreateCandidateExperienceCommand
    {
        public int IdCandidate { get; set; }
        public string Company { get; set; }
        public string Job { get; set; }
        public string Description { get; set; }
        public decimal Salary { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
