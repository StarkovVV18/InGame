using Domain.Common;

namespace Domain.Entities
{
    public class Book : BaseEntity
    {
        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Год издания.
        /// </summary>
        public string YearEdition { get; set; }
        
        /// <summary>
        /// Жанр.
        /// </summary>
        public Genre Genre { get; set; }

        /// <summary>
        /// ИД Жанра.
        /// </summary>
        public int GenreId { get; set; }
        
        /// <summary>
        /// Автор.
        /// </summary>
        public Author Author { get; set; }

        /// <summary>
        /// ИД Автора.
        /// </summary>
        public int AuthorId { get; set; }

        /// <summary>
        /// Редакция.
        /// </summary>
        public string Redaction { get; set; }
    }
}
