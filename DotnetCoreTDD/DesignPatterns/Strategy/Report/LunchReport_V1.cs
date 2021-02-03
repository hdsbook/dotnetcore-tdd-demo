using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetCoreTDD.DesignPatterns.Strategy.Report
{
    /// <summary>
    /// 午餐明細報表
    /// </summary>
    public class LunchReport_V1
    {

        public void Export(string exportType, string fileName)
        {
            // get data ...

            switch (exportType)
            {
                case "excel":
                    // export excel ...
                    break;
                case "pdf":
                default:
                    // export pdf ...
                    break;
            }
        }
    }
}
