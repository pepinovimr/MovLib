using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovLib.Data.Models
{
    /// <summary>
    /// Model of director from database
    /// </summary>
    public class Director
    {
        /// <summary>
        /// Id of director
        /// </summary>
        [Column("id")]
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Full name of Director
        /// </summary>
        [Column("name")]
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Gender of director
        /// </summary>
        [Column("gender")]
        public int Gender { get; set; }
        /// <summary>
        /// Uid of director
        /// </summary>
        [Column("uid")]
        public int Uid { get; set; }
        /// <summary>
        /// Role of director (shouldn't be else than "Directing")
        /// </summary>
        [Column("department")]
        public string Department { get; set; } = "Directing";
        /// <summary>
        /// Reference to Movie table making it 1:N relation
        /// </summary>
        [Column("movies")]
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
