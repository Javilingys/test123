namespace Core.Specifications
{
    public class BookSpecParams
    {
        private string _search;
        public string Search 
        {
            get => _search;
            // всегда ковертирует в лоуеркейс
            set => _search = value.ToLower();
        }
    }
}