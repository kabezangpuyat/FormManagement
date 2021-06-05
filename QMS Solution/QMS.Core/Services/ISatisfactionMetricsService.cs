using System;
using System.Collections.Generic;
using System.Text;

namespace QMS.Core.Services
{
    public interface ISatisfactionMetricsService
    {
        /// <summary>
        /// 0 – 6: Detractors
        /// 7 – 8: Passives
        /// 9-10: Promoters
        /// (Number of Promoters — Number of Detractors) / (Number of Respondents) x 100
        /// </summary>
        void CalculateNetPromoterScore();

        /// <summary>
        /// (#) positive responses / (#) total responses X 100 = (%) CSAT
        /// can be applied in true or false
        /// </summary>
        void CalculateCSAT();
    }
}
