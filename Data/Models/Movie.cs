using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovLib.Data.Models
{
    /// <summary>
    /// Model of Movie from database
    /// </summary>
    public class Movie
    {
        /// <summary>
        /// Id of movie
        /// </summary>
        [Key]
        public int id { get; set; }
        /// <summary>
        /// Original title of movie
        /// </summary>
        public string original_title { get; set; }
        /// <summary>
        /// Budget of movie in US$
        /// </summary>
        public long budget { get; set; }
        /// <summary>
        /// Popularity of movie described in numbers
        /// </summary>
        public int popularity { get; set; }
        /// <summary>
        /// Release date of movie
        /// </summary>
        public DateOnly release_date { get; set; }
        /// <summary>
        /// Revenue of movie inUS$
        /// </summary>
        public long revenue { get; set; }
        /// <summary>
        /// Name of the movie
        /// </summary>
        [Required]
        public string title { get; set; }
        /// <summary>
        /// Average vote on scale from 1-10
        /// </summary>
        public float vote_average { get; set; }
        /// <summary>
        /// Number of people who voted
        /// </summary>
        public int vote_count { get; set; }
        /// <summary>
        /// Description of movie
        /// </summary>
        public string? overview { get; set; }
        /// <summary>
        /// Short description or comment on a movie that is displayed on movie posters
        /// </summary>
        public string? tagline { get; set; }
        /// <summary>
        /// UID of movie
        /// </summary>
        public int uid { get; set; }
        /// <summary>
        /// Id of director from Directors table/model
        /// </summary>
        public int director_id { get; set; }
        /// <summary>
        /// Foreign key for director
        /// </summary>
        [ForeignKey("director_id")]
        public virtual Director Director { get; set; }
    }
}
