using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FollowMe.Web.Models
{
    public class LanguageLevel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public Guid PersonId { get; set; }
        public int LanguageId { get; set; }
        public int? ReadingLevel { get; set; }
        public int? WritingLevel { get; set; }
        public int? SpeakingLevel { get; set; }
    }
}