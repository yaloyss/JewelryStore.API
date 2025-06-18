namespace JewelryStore.DAL.Pagination
{
	public class PagedRequest
	{
        private const int MaxPageSize = 30;
        private int _pageSize = 10;

        public int PageNumber { get; set; } = 1;

        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value > MaxPageSize ? MaxPageSize : value; }
        }
    }
}

