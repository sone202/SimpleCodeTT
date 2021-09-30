using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SimpleCodeTT.DataAccess.Models
{
    /// <summary>
    /// Сотрудник
    /// </summary>
    [Table("employees", Schema ="dbo")]
    public class Employee
    {
        /// <summary>
        /// ID 
        /// </summary>
        [Key]
        [Column("id", TypeName ="int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Имя 
        /// </summary>
        [Required]
        [Column("name", TypeName = "ntext")]
        public string Name { get; set; }

        /// <summary>
        /// Email 
        /// </summary>
        [Column("email", TypeName = "ntext")]
        public string? Email { get; set; }

        /// <summary>
        /// День рождения 
        /// </summary>
        [Column("birthday", TypeName = "date")]
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// Зарплата
        /// </summary>
        [Column("salary", TypeName = "money")] 
        public double? Salary { get; set; }

        /// <summary>
        /// Последняя дата изменения 
        /// </summary>
        [Column("last_modified_date", TypeName = "datetime2")] 
        public DateTime? LastModifiedDate { get; set; }
    }
}
