using Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Application.Features.Authors
{
    public class GetAllPAuthorViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Birthdate { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
