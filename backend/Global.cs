using backend.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend
{
    public  static class Global
    {

        private static List<ActualSortResult> _listActualSortResrult;

        public static List<ActualSortResult> listActualSortResrult
        {
            get { return _listActualSortResrult??new List<ActualSortResult>(); }
            set { _listActualSortResrult = value; }
        }


    }
}
