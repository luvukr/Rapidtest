namespace DBEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Gender")]
    public partial class Gender
    {
        
        public int GenderId { get; set; }

        [Required]
        [StringLength(10)]
        public string GenderValue { get; set; }
    }
}
