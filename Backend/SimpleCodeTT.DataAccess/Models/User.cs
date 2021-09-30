
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SimpleCodeTT.DataAccess.Models
{
    /// <summary>
    /// пользователь
    /// </summary>
    [Table("users", Schema ="dbo")]
    public class User
    {
        /// <summary>
        /// ID 
        /// </summary>
        [Key]
        [Column("id", TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// логин 
        /// </summary>
        [Required]
        [Column("username", TypeName = "ntext")]
        public string Username { get; set; }

        /// <summary>
        /// пароль 
        /// </summary>
        [Required]
        [Column("password", TypeName = "ntext")]
        public string Password { get; set; }
    }
}
