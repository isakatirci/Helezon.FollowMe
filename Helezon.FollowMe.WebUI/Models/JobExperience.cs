using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FollowMe.Web.Models
{
    public class JobExperience
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public Guid CompanyId { get; set; }
        public Guid PersonId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public int DepartmentId { get; set; }
        public int PositionId { get; set; }
        public string LeavingReason { get; set; }
    }
}