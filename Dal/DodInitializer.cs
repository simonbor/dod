using System.Collections.Generic;
using WipDod.Models;

namespace WipDod.Dal
{
    public class DodInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<DodContext>
    {
        protected override void Seed(DodContext context)
        {
            var agents = new List<Agent>
            {
                new Agent {FullName = "Carson Alexander"},
                new Agent {FullName = "Meredith Alonso"},
                new Agent {FullName = "Arturo Anand"},
                new Agent {FullName = "Gytis Barzdukas"},
                new Agent {FullName = "Yan Li"},
                new Agent {FullName = "Peggy Justice"},
                new Agent {FullName = "Laura Norman"},
                new Agent {FullName = "Nino Olivetto"}
            };
            agents.ForEach(s => context.Agents.Add(s));
            context.SaveChanges();

            var operations = new List<Operation>
            {
                new Operation{OperationId=1001,Name="Tzuk Eithan",TimeStamp=System.DateTime.Parse("2015-09-01 10:10:59"), Desc = "תיאור פעולה - טקסט ארוך"},
                new Operation{OperationId=2002,Name="Amud Anan",TimeStamp=System.DateTime.Parse("2016-12-01")},
                new Operation{OperationId=3003,Name="Oferet Yatzuka",TimeStamp=System.DateTime.Parse("2016-09-11")},
                new Operation{OperationId=4004,Name="Livanon Shniya",TimeStamp=System.DateTime.Parse("2005-09-10")}
            };
            operations.ForEach(s => context.Operations.Add(s));
            context.SaveChanges();

            var enrollments = new List<Enrollment>
            {
                new Enrollment {AgentId = 1, OperationId = 1001, Grade = 10},
                new Enrollment {AgentId = 1, OperationId = 4004, Grade = 8},
                new Enrollment {AgentId = 1, OperationId = 2002, Grade = 1},
                new Enrollment {AgentId = 1, OperationId = 3003, Grade = 9},
                new Enrollment {AgentId = 3, OperationId = 3003, Grade = 3},
                new Enrollment {AgentId = 3, OperationId = 2002, Grade = 3},
                new Enrollment {AgentId = 3, OperationId = 1001, Grade = 3},
                new Enrollment {AgentId = 5, OperationId = 1001, Grade = 8},
                new Enrollment {AgentId = 6, OperationId = 4004, Grade = 8}
            };
            enrollments.ForEach(s => context.Enrollments.Add(s));
            context.SaveChanges();

            context.Database.ExecuteSqlCommand(@"
                CREATE PROCEDURE [dbo].getAgentsByOperationWithTheirAvarage
	                @start nvarchar(20),
	                @end nvarchar(20)
				AS
					SELECT agents.FullName, AVG(agents.Grade) AvgGrade
					FROM (SELECT ag.Id, ag.FullName, enrol.Grade
							from Agent ag join Enrollment enrol on ag.Id = enrol.AgentId
								join Operation op on enrol.OperationId = op.OperationId
							where op.TimeStamp between CAST(@start as datetime) and CAST(@end as datetime)) agents
					GROUP BY agents.FullName

                RETURN 0
            ");
        }
    }
}