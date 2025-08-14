using Homework_02.Models;

namespace Homework_03.Data
{
    public static class StaticDb
    {
        public static List<Books> Books = new List<Books>
        {
            new Books { Author = "David Sedaris", Title = "Me Talk Pretty One Day" },
            new Books { Author = "Korney Chukovsky", Title = "Doktor Ofboli" },
            new Books { Author = "J.K. Rowling", Title = "Harry Potter and the order of the Phoenix" }
        };
    }
}