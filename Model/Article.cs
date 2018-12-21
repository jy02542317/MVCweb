﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Article
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set;}

        public bool IsValid { get; set; }

        public DateTime CreateTime { get; set; }

        public int FK_ArticleType { get; set; }

    }
}
