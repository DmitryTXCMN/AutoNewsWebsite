using System.Collections.Generic;

namespace AutoNewsWebsite.DAL
{
    public class SelectResult
    { 
        
        public int ColumnsCount { get; set; }
        public int RowCount => Data.Count;
        public readonly List<List<object>> Data;
        public readonly List<string> Header;

        public SelectResult(int rowCount, List<List<object>> list, List<string> header)
        {
            ColumnsCount = rowCount;
            Data = list;
            Header = header;
        }
    }
}