using Domain.Common;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Author : BaseEntity
    {
        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime Birthdate { get; set; }
        
        /// <summary>
        /// Книги.
        /// </summary>
        public virtual ICollection<Book> Books { get; set; }
    }
}
