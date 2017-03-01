using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WipDod.Models
{
    public class Agent
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string FullName { get; set; }
        public string Address { get; set; }
        [StringLength(20)]
        public string Phone { get; set; }
        public int Age { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}