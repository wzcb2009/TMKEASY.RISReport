using System;
using System.Collections.Generic;
using System.Text;
using DCSoft.Writer.Data;
using System.Data;

namespace TMKEASY.RISReport
{
    class MyListItemsProvider_Class : IListItemsProvider
    {
        /// <summary>
        /// 初始化对象
        /// </summary>
        public MyListItemsProvider_Class()
        {
        }

        private static Dictionary<string, string> _ListSourceSQLs = null;
        public ListItemCollection GetListItems(ListItemsEventArgs args)
        {
            if (args.KBEntry != null && args.KBEntry.Style == KBEntryStyle.ListSQL)
            {
                string sql = args.KBEntry.Value;
                //if (string.IsNullOrEmpty(sql) == false)
                //{
                //    //using (IDbConnection conn = DataHelper.CreateConnection())
                //    //{
                //    //    conn.Open();
                //    //    using (IDbCommand cmd = conn.CreateCommand())
                //    //    {
                //    //        cmd.CommandText = sql;
                //    //        IDataReader reader = cmd.ExecuteReader();
                //    //        ListItemCollection list = CreateList(reader);
                //    //        reader.Close();
                //    //        return list;
                //    //    }//using
                //    //}//using
                //}//if
            }//if

            if (_ListSourceSQLs == null)
            {
                _ListSourceSQLs = new Dictionary<string, string>();
                try
                {
                    _ListSourceSQLs["advancedoclist"] = "Select userid listname, id listcode from userinfo where userflag='" + Share_Class.User.userflag + "' ";
                    _ListSourceSQLs["reportdoclist"] = "Select userid listname, id listcode from userinfo where userflag='" + Share_Class.User.userflag + "' ";
                    _ListSourceSQLs["radio_doctorlist"] = "Select userid listname, id listcode from userinfo where userflag='" + Share_Class.User.userflag + "' ";
                }
                catch { }
                _ListSourceSQLs["sqdeplist"] = "Select sqdep listname, id listcode From sqdep order by ID";
                _ListSourceSQLs["doctorlist"] = "Select userid listname, id listcode From EMR_SysCode Where SysType='0012' Order by SysDesc";
                _ListSourceSQLs["wardnolist"] = "Select userid listname, id listcode From EMR_SysCode Where SysType='0013' Order by SysDesc";
                _ListSourceSQLs["machinetype"] = "Select userid listname, id listcode From EMR_SysCode Where SysType='0014' Order by SysDesc";
                _ListSourceSQLs["diseasetypelist"] = "Select userid listname, id listcode From EMR_SysCode Where SysType='0015' Order by SysDesc";
                _ListSourceSQLs["reportdisease"] = "Select userid listname, id listcode From EMR_SysCode Where SysType='0016' Order by SysDesc";
                _ListSourceSQLs["otherchecklist"] = "Select userid listname, id listcode From EMR_SysCode Where SysType='0017' Order by SysDesc";
                _ListSourceSQLs["modalitylist"] = "Select userid listname, id listcode From EMR_SysCode Where SysType='0018' Order by SysDesc";
                _ListSourceSQLs["checktypelist"] = "Select userid listname, id listcode From EMR_SysCode Where SysType='0019' Order by SysDesc";
                _ListSourceSQLs["dengjipartlist"] = "Select userid listname, id listcode From EMR_SysCode Where SysType='0020' Order by SysDesc";
                _ListSourceSQLs["checkposlist"] = "Select userid listname, id listcode From EMR_SysCode Where SysType='0021' Order by SysDesc";

            }
            string sourceName = args.SourceName;
            if (sourceName == null)
            {
                sourceName = "";
            }
            sourceName = sourceName.Trim().ToUpper();
            if (_ListSourceSQLs.ContainsKey(sourceName))
            {
                string sql = _ListSourceSQLs[sourceName];
                //using (IDbConnection conn = DataHelper.CreateConnection())
                //{
                //    conn.Open();
                //    using (IDbCommand cmd = conn.CreateCommand())
                //    {
                //        cmd.CommandText = sql;
                //        IDataReader reader = cmd.ExecuteReader();
                //        ListItemCollection list = CreateList(reader);
                //        reader.Close();
                //        return list;
                //    }//using
                //}//using
            }//if
            return null;
        }

        /// <summary>
        /// 根据读取的数据生成项目列表
        /// </summary>
        /// <param name="reader">数据读取器</param>
        /// <returns>项目列表</returns>
        private ListItemCollection CreateList(IDataReader reader)
        {
            int fieldCount = reader.FieldCount;
            if (fieldCount == 0)
            {
                return null;
            }
            ListItemCollection list = new ListItemCollection();
            while (reader.Read())
            {
                ListItem item = new ListItem();
                if (reader.IsDBNull(0) == false)
                {
                    item.Text = Convert.ToString(reader.GetValue(0));
                }
                if (fieldCount == 1)
                {
                    item.Value = item.Text;
                }
                else
                {
                    if (reader.IsDBNull(1) == false)
                    {
                        item.Value = Convert.ToString(reader.GetValue(1));
                    }
                }
                if (fieldCount >= 3)
                {
                    if (reader.IsDBNull(2) == false)
                    {
                        item.SpellCode = Convert.ToString(reader.GetValue(2));
                    }
                }
                list.Add(item);
            }//while
            return list;
        }
    }
}
