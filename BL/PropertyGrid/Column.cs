using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UTIL;

namespace BL.PropertyGrid
{
    public class Column
    {
        private bool enabledIsIdentity;
        private bool enabledIdentityIncrement;
        private bool enabledIdentitySpeed;
        private bool enabledSize;
        private DataTypeForSQLServer _dataType;

        public Column()
        {
            Name = "";
            //AllowNull = null;
            DataType = DataTypeForSQLServer.NCHAR;
            DefaultValue = "";
            Formule = "";
            Description = "";
            //IsIdentity = isIdentity;
            //IdentityIncrement = identityIncrement;
            //IdentitySpeed = identitySpeed;
            //Size = size;
        }

        [Browsable(false)]
        public bool EnabledIsIdentity
        {
            get { return enabledIsIdentity; }
            set
            {
                enabledIsIdentity = value;
                PropertyDescriptor Desc = TypeDescriptor.GetProperties(this)["IsIdentity"];
                ReadOnlyAttribute att = (Desc.Attributes[typeof(ReadOnlyAttribute)] as ReadOnlyAttribute);
                FieldInfo fi = att.GetType().GetField("isReadOnly", BindingFlags.NonPublic | BindingFlags.Instance);
                fi.SetValue(att, !enabledIsIdentity);
            }
        }

        [Browsable(false)]
        public bool EnabledIdentityIncrement
        {
            get { return enabledIdentityIncrement; }
            set
            {
                enabledIdentityIncrement = value;
                PropertyDescriptor Desc = TypeDescriptor.GetProperties(this)["IdentityIncrement"];
                ReadOnlyAttribute att = (Desc.Attributes[typeof(ReadOnlyAttribute)] as ReadOnlyAttribute);
                FieldInfo fi = att.GetType().GetField("isReadOnly", BindingFlags.NonPublic | BindingFlags.Instance);
                fi.SetValue(att, !enabledIdentityIncrement);
            }
        }

        [Browsable(false)]
        public bool EnabledIdentitySpeed
        {
            get { return enabledIdentitySpeed; }
            set
            {
                enabledIdentitySpeed = value;
                PropertyDescriptor Desc = TypeDescriptor.GetProperties(this)["IdentitySpeed"];
                ReadOnlyAttribute att = (Desc.Attributes[typeof(ReadOnlyAttribute)] as ReadOnlyAttribute);
                FieldInfo fi = att.GetType().GetField("isReadOnly", BindingFlags.NonPublic | BindingFlags.Instance);
                fi.SetValue(att, !enabledIdentitySpeed);
            }
        }

        [Browsable(false)]
        public bool EnabledSize
        {
            get { return enabledSize; }
            set
            {
                enabledSize = value;
                PropertyDescriptor Desc = TypeDescriptor.GetProperties(this)["Size"];
                ReadOnlyAttribute att = (Desc.Attributes[typeof(ReadOnlyAttribute)] as ReadOnlyAttribute);
                FieldInfo fi = att.GetType().GetField("isReadOnly", BindingFlags.NonPublic | BindingFlags.Instance);
                fi.SetValue(att, !enabledSize);
            }
        }

        public string Name { get; set; }
        public bool AllowNull { get; set; }

        public bool IsPrimaryKey { get; set; }

        public DataTypeForSQLServer DataType
        {
            get { return _dataType; }
            set
            {
                _dataType = value;
                if (Data.DataTypeSQLServerNumeric().Contains(_dataType.ToString().ToLower()))
                {
                    EnabledIdentityIncrement = true;
                    EnabledIsIdentity = true;
                    EnabledIdentitySpeed = true;
                    EnabledSize = false;
                }
                else if (Data.DataTypeSQLServerStrings().Contains(_dataType.ToString().ToLower()))
                {
                    EnabledIdentityIncrement = false;
                    EnabledIsIdentity = false;
                    EnabledIdentitySpeed = false;
                    EnabledSize = true;
                }
                else
                {
                    EnabledIdentityIncrement = false;
                    EnabledIsIdentity = false;
                    EnabledIdentitySpeed = false;
                    EnabledSize = false;
                }
            }
        }

        public string DefaultValue { get; set; }
        public Data.CollationSQL Collation { get; set; }

        [Browsable(true)]
        [ReadOnly(false)]
        public string Formule { get; set; }

        public string Description { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        public bool IsIdentity { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        public string IdentityIncrement { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        public string IdentitySpeed { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        public string Size { get; set; }
    }
}