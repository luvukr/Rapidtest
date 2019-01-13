using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RapiddAssignment.Models
{

    public class EmployeeDisplayModel
    {
        public Guid EmpId { get; set; }
        [StringLength(50)]

        public string EmpName { get; set; }
        public DateTime DOB { get; set; }
        public int EmpLocationId { get; set; }

        public string EmpLocation { get; set; }
        [Required]

        public string Address { get; set; }
        [Required]

        [DataType(DataType.PhoneNumber)]

        public string PhoneNo { get; set; }
        public bool IsActive { get; set; }
        public DateTime DOJ { get; set; }
        public DateTime? DOL { get; set; }
        public decimal? Experience { get; set; }
        public int EmpPositionId { get; set; }
        public string EmpPosition { get; set; }
        [Required]
        [StringLength(200)]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = " Invalid Email Address")]

        public string Email { get; set; }
        [StringLength(200)]

        public string Languages { get; set; }
        [StringLength(200)]

        public string PerAdd { get; set; }

        public bool IsMale { get; set; }

    }

    public class EmployeeCreateModel
    {
        [StringLength(50)]

        public string EmpName { get; set; }
        public DateTime DOB { get; set; }
        public int EmpLocationId { get; set; }
        [Required]

        public string Address { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneNo { get; set; }
        public DateTime DOJ { get; set; }
        public DateTime? DOL { get; set; }
        public decimal? Experience { get; set; }
        public int EmpPositionId { get; set; }
        [Required]
        [StringLength(200)]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = " Invalid Email Address")]

        public string Email { get; set; }
        [StringLength(200)]

        public string Languages { get; set; }
        [StringLength(200)]

        public string PerAdd { get; set; }

        public bool IsMale { get; set; }

    }

    public class EmployeeUpdateModel
    {
        public Guid EmpId { get; set; }

        public int EmpLocationId { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public DateTime? DOL { get; set; }
        public decimal? Experience { get; set; }
        public int EmpPositionId { get; set; }
        public string Email { get; set; }
        public string Languages { get; set; }
        public string PerAdd { get; set; }


    }

}