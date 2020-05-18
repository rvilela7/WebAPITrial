using System;

namespace SportShop.API.Controllers
{
    public class PagingParameters
    {
        private const int _maxsize = 10;
        private int _size = 5;
        public int Page { get; set; }
        public int Size
        {
            get
            {
                return _size;
            }
            set{
                _size = Math.Min(_maxsize, Math.Abs(value));
            }
        }
    }
}