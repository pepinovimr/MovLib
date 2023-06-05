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
        [Column("id")]
        public int Id { get; set; }
        /// <summary>
        /// Original title of movie
        /// </summary>
        [Column("original_title")]
        public string OriginalTitle { get; set; }
        /// <summary>
        /// Budget of movie in US$
        /// </summary>
        [Column("budget")]
        public long Budget { get; set; }
        /// <summary>
        /// Popularity of movie described in numbers
        /// </summary>
        [Column("popularity")]
        public int Popularity { get; set; }
        /// <summary>
        /// Release date of movie
        /// </summary>
        [Column("release_date")]
        public DateOnly ReleaseDate { get; set; }
        /// <summary>
        /// Revenue of movie inUS$
        /// </summary>
        [Column("revenue")]
        public long Revenue { get; set; }
        /// <summary>
        /// Name of the movie
        /// </summary>
        [Column("title")]
        [Required]
        public string Title { get; set; }
        /// <summary>
        /// Average vote on scale from 1-10
        /// </summary>
        [Column("vote_average")]
        public float VoteAverage { get; set; }
        /// <summary>
        /// Number of people who voted
        /// </summary>
        [Column("vote_count")]
        public int VoteCount { get; set; }
        /// <summary>
        /// Description of movie
        /// </summary>
        [Column("overview")]
        public string? Overview { get; set; }
        /// <summary>
        /// Short description or comment on a movie that is displayed on movie posters
        /// </summary>
        [Column("tagline")]
        public string? Tagline { get; set; }
        /// <summary>
        /// UID of movie
        /// </summary>
        [Column("uid")]
        public int Uid { get; set; }
        ///// <summary>
        ///// Id of director from Directors table/model
        ///// </summary>
        //[ForeignKey("director_id")]
        //public int DirectorId { get; set; }
        /// <summary>
        /// Foreign key for director
        /// </summary>
        [ForeignKey("director_id")]
        public virtual Director Director { get; set; }
    }
}
