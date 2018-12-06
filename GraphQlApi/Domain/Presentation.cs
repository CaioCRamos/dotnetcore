using System;
using System.Collections.Generic;

namespace GraphQlApi.Domain
{
    public class Presentation
    {
        public static Presentation New(string name, Category category, DateTime releaseDate)
            => new Presentation
            {
                Id = Guid.NewGuid(),
                Name = name,
                Category = category,
                ReleaseDate = releaseDate,
                _slides = new List<Slide>()
            };

        public static Presentation Load(Guid id, string name, Category category, DateTime releaseDate, List<Slide> slides)
            => new Presentation
            {
                Id = id,
                Name = name,
                Category = category,
                ReleaseDate = releaseDate,
                _slides = slides
            };

        private Presentation() {}

        private List<Slide> _slides;

        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public Category Category { get; private set; }

        public DateTime ReleaseDate { get; private set; }

        public IReadOnlyCollection<Slide> Slides => _slides;
    }
}