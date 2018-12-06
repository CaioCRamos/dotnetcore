using System;

namespace GraphQlApi.Domain
{
    public class Slide
    {
        public static Slide New(int order)
            => new Slide
            {
                Id = Guid.NewGuid(),
                Order = order
            };

        public static Slide Load(Guid id, int order)
            => new Slide 
            {
                Id = id,
                Order = order
            };

        private Slide() {}

        public Guid Id { get; private set; }

        public int Order { get; private set; }
    }
}