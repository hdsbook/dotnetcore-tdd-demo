using System.Collections.Generic;

namespace DotnetCoreTDD.DesignPatterns.Builder
{
    /// <summary>
    /// Excel 欄位類別
    /// </summary>
    public class Cell
    {
        /// <summary>文字</summary>
        public string Text { get; set; }

        /// <summary>文字顏色</summary>
        public string Color { get; set; }

        /// <summary>欄合併數</summary>
        public int Colspan { get; set; }

        /// <summary>列合併數</summary>
        public int Rowspan { get; set; }

        /// <summary>對齊</summary>
        public string Alignment { get; set; }
    }
    
    
    /// <summary>
    /// Excel 欄位 Builder
    /// </summary>
    public class CellBuilder
    {
        public Cell Cell { get; set; }
        public CellBuilder(string text)
        {
            Cell = new Cell
            {
                Text = text,
                Colspan = 1,
                Rowspan = 1,
                Color = "black",
                Alignment = "left"
            };
        }

        #region build options

        public CellBuilder SetColspan(int colspan)
        {
            Cell.Colspan = colspan;
            return this;
        }
        
        public CellBuilder SetRowspan(int rowspan)
        {
            Cell.Rowspan = rowspan;
            return this;
        }

        public CellBuilder SetColor(string color)
        {
            Cell.Color = color;
            return this;
        }
        
        public CellBuilder SetAlignment(string alignment)
        {
            Cell.Alignment = alignment;
            return this;
        }
        
        /// <summary>
        /// 客製化的 footer 樣式 
        /// </summary>
        /// <returns></returns>
        public CellBuilder SetFooterStyle()
        {
            return SetColor("gray").SetColspan(10).SetRowspan(1).SetAlignment("right");
        }

        #endregion
        
        /// <summary>
        /// 回傳建構結果
        /// </summary>
        /// <returns></returns>
        public Cell Build()
        {
            return Cell;
        }
    }
}