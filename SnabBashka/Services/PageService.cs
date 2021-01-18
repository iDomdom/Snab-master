using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SnabBashka
{
    public class PageService
    {
        private Stack<Page> _history;
        //private Page _lastPage;

        public event Action<Page> OnPageChanged;
        public PageService()
        {
            _history = new Stack<Page>();
        }
        public void Navigate(Page page)
        {
            OnPageChanged?.Invoke(page);
            //_lastPage = page;
            //if (_lastPage != null) { _history.Push(page); }
        }
    }
}
