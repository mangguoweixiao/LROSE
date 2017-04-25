﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LROSE_Model.MrData;
using LROSE_DAL;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace LROSE_BLL.MR
{
    /// <summary>
    /// 单例模式，Mr数据的单例
    /// </summary>
    public class SingletonMrData
    {
        public static List<MrTableAllColumn> mrAllcolumnL = new List<MrTableAllColumn>() ;
        public static List<MRTableList> mrTableL = new List<MRTableList> ();

        /// <summary>
        /// 得到表数据，表头信息
        /// </summary>
        public void MrInitializeComponent(string dbname)
        {
            if (mrAllcolumnL.Count() == 0 || mrTableL.Count() == 0)
            {
                using (var db = new LROSRDbContext(dbname))
                {
                    var column = from q in db.MrTableAllColumn select q;
                    var table1 = from q in column
                                 group q by new
                                 {
                                     q.fileFormatVersion,
                                     q.tabletype,
                                     q.mrName
                                 }
                                     into m
                                     select m.Key;
                    var table2 = from q in table1
                                 select new MRTableList
                                 {
                                     tabletype = q.tabletype,
                                     Version = q.fileFormatVersion,
                                     tableName = q.mrName
                                 };
                    
                    foreach (MrTableAllColumn item in column)
                    {
                        MrTableAllColumn mrTableAllColumn = SingletonMrData.DeepCopy<MrTableAllColumn>(item);
                        mrAllcolumnL.Add(mrTableAllColumn);
                    }
                   
                    foreach(MRTableList item in table2 )
                    {
                        MRTableList mRTableList = SingletonMrData.DeepCopy<MRTableList>(item);
                        mrTableL.Add(item);    
                    }
                }
            }
        }

        /// <summary>
        /// 深拷贝(使用反射的方式)
        /// </summary>
        public static T DeepCopy<T>(T serializableObject)
       {
           object objCopy = null;

           MemoryStream stream = new MemoryStream();
           BinaryFormatter binFormatter = new BinaryFormatter();
           binFormatter.Serialize(stream, serializableObject);
           stream.Position = 0;
           objCopy = (T)binFormatter.Deserialize(stream);
           stream.Close();
           return (T)objCopy;

       }





    }
}