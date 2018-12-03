using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ToolsCSharp;
using EventDBClasses;
using EventPropsClasses;

// *** I added this
using System.Data;

namespace EventClasses
{
    public class Customer : BaseBusiness
    {
        #region SetUpStuff
        /// <summary>
        /// 
        /// </summary>		
        protected override void SetDefaultProperties()
        {
        }

        /// <summary>
        /// Sets required fields for a record.
        /// </summary>
        protected override void SetRequiredRules()
        {
            mRules.RuleBroken("Name", true);
            mRules.RuleBroken("Address", true);
            mRules.RuleBroken("City", true);
            mRules.RuleBroken("State", true);
            mRules.RuleBroken("ZipCode", true);
        }

        /// <summary>
        /// Instantiates mProps and mOldProps as new Props objects.
        /// Instantiates mbdReadable and mdbWriteable as new DB objects.
        /// </summary>
        protected override void SetUp()
        {
            mProps = new CustomerProps();
            mOldProps = new CustomerProps();

            if (this.mConnectionString == "")
            {
                mdbReadable = new CustomerSQLDB();
                mdbWriteable = new CustomerSQLDB();
            }

            else
            {
                mdbReadable = new CustomerSQLDB(this.mConnectionString);
                mdbWriteable = new CustomerSQLDB(this.mConnectionString);
            }
        }
        #endregion

        #region constructors
        public Customer() : base()
        {
        }

        public Customer(string cnString) : base(cnString)
        {
        }

        public Customer(object key) : base(key)
        {
        }

        public Customer(IBaseProps props) : base(props)
        {
        }

        public Customer(object key, string cnString) : base(key, cnString)
        {
        }

        public Customer(IBaseProps props, string cnString) : base(props, cnString)
        {
        }

        public override object GetList()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region properties

        /// <summary>
        /// Read-only ID property.
        /// </summary>
        public int CustomerID
        {
            get
            {
                return ((CustomerProps)mProps).customerID;
            }
        }

        /// <summary>
        /// Read/Write property. 
        /// </summary>
        public string CustomerName
        {
            get
            {
                return ((CustomerProps)mProps).name;
            }

            set
            {
                if (!(value == ((CustomerProps)mProps).name))
                {
                    if (value.Length >= 1 && value.Length <= 100)
                    {
                        mRules.RuleBroken("Name", false);
                        ((CustomerProps)mProps).name = value;
                        mIsDirty = true;
                    }

                    else
                    {
                        throw new ArgumentOutOfRangeException("Name must be between 1 and 100 characters");
                    }
                }
            }
        }

        /// <summary>
        /// Read/Write property. 
        /// </summary>
        public string Address
        {
            get
            {
                return ((CustomerProps)mProps).address;
            }

            set
            {
                if (!(value == ((CustomerProps)mProps).address))
                {
                    if (value.Length >= 1 && value.Length <= 50)
                    {
                        mRules.RuleBroken("Address", false);
                        ((CustomerProps)mProps).address = value;
                        mIsDirty = true;
                    }

                    else
                    {
                        throw new ArgumentOutOfRangeException("Address must be between 1 and 50 characters");
                    }
                }
            }
        }
        /// <summary>
        /// Read/Write property. 
        /// </summary>
        public string City
        {
            get
            {
                return ((CustomerProps)mProps).city;
            }

            set
            {
                if (!(value == ((CustomerProps)mProps).city))
                {
                    if (value.Length >= 1 && value.Length <= 20)
                    {
                        mRules.RuleBroken("City", false);
                        ((CustomerProps)mProps).city = value;
                        mIsDirty = true;
                    }

                    else
                    {
                        throw new ArgumentOutOfRangeException("City must be between 1 and 20 characters");
                    }
                }
            }
        }

        /// <summary>
        /// Read/Write property. 
        /// </summary>
        public string State
        {
            get
            {
                return ((CustomerProps)mProps).state;
            }

            set
            {
                if (!(value == ((CustomerProps)mProps).state))
                {
                    if (value.Length >= 1 && value.Length <= 2)
                    {
                        mRules.RuleBroken("State", false);
                        ((CustomerProps)mProps).state = value;
                        mIsDirty = true;
                    }

                    else
                    {
                        throw new ArgumentOutOfRangeException("State must be 2 characters");
                    }
                }
            }
        }

        /// <summary>
        /// Read/Write property. 
        /// </summary>
        public string ZipCode
        {
            get
            {
                return ((CustomerProps)mProps).zipCode;
            }

            set
            {
                if (!(value == ((CustomerProps)mProps).zipCode))
                {
                    if (value.Length >= 1 && value.Length <= 15)
                    {
                        mRules.RuleBroken("ZipCode", false);
                        ((CustomerProps)mProps).address = value;
                        mIsDirty = true;
                    }

                    else
                    {
                        throw new ArgumentOutOfRangeException("ZipCode must be between 15");
                    }
                }
            }
        }
        #endregion
    }
}
