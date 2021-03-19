using Core.Entities;

namespace Core.Specifications
{
    public class ReaderWithFiltersSpec : BaseSpecification<Reader>
    {
        public ReaderWithFiltersSpec(ReaderSpecParams bookParams)
            : base(x => 
                (string.IsNullOrEmpty(bookParams.FirstName) || x.FirstName.ToLower().Contains(bookParams.FirstName)) &&
                (string.IsNullOrEmpty(bookParams.LastName) || x.FirstName.ToLower().Contains(bookParams.LastName)) &&
                (string.IsNullOrEmpty(bookParams.MiddleName) || x.FirstName.ToLower().Contains(bookParams.MiddleName))
            )
        {

        }

        public ReaderWithFiltersSpec(int id)
            : base(x => x.Id == id)
        {

        }
    }
}