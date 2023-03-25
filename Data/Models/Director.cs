using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
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
        [Key]
        public int id { get; set; }
        /// <summary>
        /// Full name of Director
        /// </summary>
        [Required]
        public string name { get; set; }
        /// <summary>
        /// Gender of director
        /// </summary>
        public int gender { get; set; }
        /// <summary>
        /// Uid of director
        /// </summary>
        public int uid { get; set; }
        /// <summary>
        /// Role of director (shouldn't be else than "Directing")
        /// </summary>
        public string department { get; set; } = "Directing";

        public virtual ICollection<Movie> movies { get; set; }
    }
}
