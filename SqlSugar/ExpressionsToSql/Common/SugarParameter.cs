﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SqlSugar
{
    public class SugarParameter : DbParameter
    {
        public SugarParameter(string name, object value)
        {
            this.Value = value;
            this.ParameterName = name;
        }
        public SugarParameter(string name, object value, Type type)
        {
            this.Value = value;
            this.ParameterName = name;
            if (type == PubConst.ByteArrayType)
            {
                this.DbType = System.Data.DbType.Binary;
            }
            else if (type == PubConst.GuidType)
            {
                this.DbType = System.Data.DbType.Guid;
            }
            else if (type == PubConst.IntType)
            {
                this.DbType = System.Data.DbType.Int32;
            }
            else if (type == PubConst.DateType)
            {
                this.DbType = System.Data.DbType.Date;
            }
        }
        public SugarParameter(string name, object value, bool isOutput)
        {
            this.Value = value;
            this.ParameterName = name;
            if (isOutput)
            {
                this.Direction = ParameterDirection.Output;
            }
        }
        public override System.Data.DbType DbType
        {
            get; set;
        }

        public override ParameterDirection Direction
        {
            get; set;
        }

        public override bool IsNullable
        {
            get; set;
        }

        public override string ParameterName
        {
            get; set;
        }

        public int _Size;

        public override int Size
        {
            get
            {
                if (_Size == 0 && Value != null)
                {
                    var length = Value.ToString().Length;
                    if (length < 4000)
                    {
                        _Size = 4000;
                    }
                    else
                    {
                        _Size = -1;
                    }
                }
                if (_Size == 0)
                {
                    _Size = 4000;
                }
                return _Size;
            }
            set
            {
                _Size = value;
            }
        }

        public override string SourceColumn
        {
            get; set;
        }

        public override bool SourceColumnNullMapping
        {
            get; set;
        }
        public string UdtTypeName
        {
            get;
            set;
        }

        public override object Value
        {
            get; set;
        }

        public Dictionary<string, object> TempDate
        {
            get; set;
        }

        public override DataRowVersion SourceVersion
        {
            get; set;
        }

        public override void ResetDbType()
        {
            this.DbType = System.Data.DbType.String;
        }
    }
}
