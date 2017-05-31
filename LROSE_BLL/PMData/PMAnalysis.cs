using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LROSE_Model.PMData;

namespace LROSE_BLL.PMData
{
    public class PMAnalysis
    {
        /// <summary>
        /// 指标计算
        /// </summary>
        /// <param name="dt_counter">指标公式表</param>
        /// <returns>指标列表</returns>
        public List<Counter> CounterAnalysis(DataTable dt_counter)
        {
            int a=1;
            List<Counter> counterList = new List<Counter>();
            //循环STS结构表
            foreach (DataTable dt_STS in PMDataShow.ds.Tables)
            {
                if (dt_STS.Rows.Count == 0)
                {
                    continue;
                }

                foreach (DataRow dr in dt_counter.Rows)
                {
                    string counterAlgorithm = dr["algorithm"].ToString();
                    bool hasCounter =HasCounter(dt_STS, counterAlgorithm);
                    if (hasCounter)
                    {
                        foreach (DataRow dr_STS in dt_STS.Rows)
                        {
                            Counter counter = new Counter();
                            counter.counterValue = CounterAlgorithm(dr_STS, counterAlgorithm).ToString() ;
                            counter.counterName = dr["counter"].ToString();
                            counter.counterAlgorithm = dr["algorithm"].ToString();
                            counter.fileName = dt_STS.TableName;
                            counter.fileCreateTime = dr_STS["RecordTime"].ToString();
                            counter.Sector = "";//暂时不能解决 （扇区）
                            counter.id = a;
                            counterList.Add(counter);
                            a++;
                        }
                    }
                }
            }
            return counterList;
        }


        /// <summary>
        /// 是否含有对应原始计数器
        /// </summary>
        /// <param name="dt">STS结构表</param>
        /// <param name="counterAlgorithm">指标计算公式</param>
        /// <returns></returns>
        private bool HasCounter(DataTable dt, string counterAlgorithm)
        {
            return false;
        }

        /// <summary>
        /// 指标计算
        /// </summary>
        /// <param name="dr">某一条数据</param>
        /// <param name="counterAlgorithm">指标计算公式</param>
        /// <returns>计算的值</returns>
        private int CounterAlgorithm(DataRow dr, string counterAlgorithm)
        {
            return 0;
        }
    }
}
