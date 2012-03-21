using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//namespace SR.Data.DB.SORM
//{

//    public interface IFrom
//    {
//        void From(ITable table);
//    }

//    public interface ISelect
//    {
//        void Select(IField field);
//    }

//    public interface IInsert
//    {
//        void Insert(string fieldName, IField field);
//    }

//    public interface IWhere
//    {
//        /// <summary>
//        /// 表示连接此条件的运算符
//        /// </summary>
//        CondtionLinkOperator Operator { get; set; }

//        void Where(IField field, CondtionLinkOperator oper, object val);
//    }

//    public interface IUpdate
//    {
//        void Update(IField field);
//    }

//    public interface IJoin
//    {
//        void Join(ITable table, IWhere where);
//    }

//    public interface IDelete
//    {

//    }

//    public interface IBaseSQLText : ISQLText, IFrom, IJoin, IWhere
//    {

//    }

//    public interface IDeleteSQLText : IDelete, IBaseSQLText
//    {

//    }

//    public interface IUpdateSQLText : IUpdate, IBaseSQLText
//    {

//    }

//    public interface ISelectSQLText : ISelect, IBaseSQLText
//    {

//    }

//    public interface IInsertSQLText : IInsert, IBaseSQLText
//    {

//    }

//    public interface ICommandTextPlan : IExecutePlan
//    {
//        string SQLText { get; }
//    }

//    public interface IStoredProcPlan : IExecutePlan
//    {
//        string StoreProcName { get; set; }
//    }

//    public interface ISelectPlan : IExecutePlan, ISelectSQLText
//    {

//    }

//    public interface IUpdatePlan : IExecutePlan, IUpdateSQLText
//    {

//    }

//    public interface IDeletePlan : IExecutePlan, IDeleteSQLText
//    {

//    }
//}
