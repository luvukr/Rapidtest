namespace DBEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        [Key]
        public Guid EmpId { get; set; }

        public int GenderId { get; set; }

        [Required]
        [StringLength(50)]
        public string EmpName { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DOB { get; set; }

        public int EmpLocation { get; set; }

        [Required]
        [StringLength(200)]
        public string Address { get; set; }

        [Required]
        [StringLength(10)]
        public string PhoneNo { get; set; }

        public bool IsActive { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DOJ { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DOL { get; set; }

        public decimal? Experience { get; set; }

        public int EmpPosition { get; set; }

        [Required]
        [StringLength(200)]
        public string Email { get; set; }

        [StringLength(200)]
        public string Languages { get; set; }

        [StringLength(200)]
        public string PerAdd { get; set; }

        public bool IsMale { get; set; }

        public virtual EmployeeLocation EmployeeLocation { get; set; }

        public virtual EmployeePosition EmployeePosition { get; set; }
    }
}
