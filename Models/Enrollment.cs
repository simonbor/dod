
namespace WipDod.Models
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public int AgentId { get; set; }
        public int OperationId { get; set; }
        public int Grade { get; set; }

        public virtual Agent Agent { get; set; }
        public virtual Operation Operation { get; set; }
    }
}