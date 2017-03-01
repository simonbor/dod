using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WipDod.Models
{
    public class Operation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OperationId { get; set; }
        public DateTime TimeStamp { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(MAX)")]    // ntext, text, image types will be removed in a future version of SQL Server
        public string Desc { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}