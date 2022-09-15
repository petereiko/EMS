namespace EMS.DatabaseEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Employee
    {
        public int Id { get; set; }

        public int? DepartmentId { get; set; }

        public int? UserId { get; set; }

        public int? LevelId { get; set; }

        public DateTime? DateCreated { get; set; }

        public virtual Department Department { get; set; }

        public virtual EmployeeLevel EmployeeLevel { get; set; }

        public virtual User User { get; set; }
    }
}
