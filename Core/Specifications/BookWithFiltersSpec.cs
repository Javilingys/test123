using Core.Entities;

namespace Core.Specifications
{
    public class BookWithFiltersSpec : BaseSpecification<Book>
    {
        public BookWithFiltersSpec(BookSpecParams bookParams)
    : base(x =>
        (string.IsNullOrEmpty(bookParams.Search) || x.Name.ToLower().Contains(bookParams.Search))
    )
        {
            AddInclude(x => x.Readers);
        }

        public BookWithFiltersSpec(int id)
            : base(x => x.Id == id)
        {
            AddInclude(x => x.Readers);
        }
    }
}