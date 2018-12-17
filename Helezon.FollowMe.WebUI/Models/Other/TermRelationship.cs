//namespace FollowMe.Web.Models
//{
//    using System;
//    using System.Collections.Generic;
//    using System.ComponentModel.DataAnnotations;
//    using System.ComponentModel.DataAnnotations.Schema;
//    using System.Data.Entity.Spatial;

//    [Table("TermRelationship")]
//    public partial class TermRelationship
//    {
//        //InnerException = {"Cannot insert the value NULL into column 'TermRelationshipsId', table 'GLCEmas.dbo.Term_Relationships'; column does not allow nulls. INSERT fails.\r\nThe statement has been terminated."}
//        [Key]
//        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
//        public int Id { get; set; }
//        public Guid CompanyId { get; set; }
//        public int EntityType { get; set; }
//        public Guid EntityId { get; set; }
//        public int TermId { get; set; }
//        public string TermName{ get; set; }
//        public int TaxonomyId { get; set; }
//        public int TermOrder { get; set; }
//        public DateTime CreatedAt { get; set; }

//    }
//}
