using Class03.Homework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Class03.Homework
{
    public static class StaticDB
    {
        public static List<Book> Books = new List<Book>()
        {
            new Book()
            {
                Author = "Tosho Malerot",
                Title = "Monologija"
            },
            new Book()
            {
                Author = "Donato Harizi",
                Title = "Shepnuvachot"
            },
            new Book()
            {
                Author = "Agata Kristi",
                Title = "Koj kje go fati branot"
            },
            new Book()
            {
                Author = "Stiven King",
                Title = "Trkachot"
            },
            new Book()
            {
                Author = "Agata Kristi",
                Title = "Azbuchnite ubistva"
            },
            new Book()
            {
                Author = "Robert Ladlam",
                Title = "Moskovski vektor"
            }
        };
    }
}
