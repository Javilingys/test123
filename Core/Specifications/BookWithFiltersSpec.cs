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

        }
    }
}