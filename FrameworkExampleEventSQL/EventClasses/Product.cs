using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ToolsCSharp;
using EventPropsClasses;

// *** I had to change this
using ProductDB = EventDBClasses.ProductSQLDB;

// *** I added this
using System.Data;

namespace EventClasses
{
    public class Product : BaseBusiness
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
            mRules.RuleBroken("Code", true);
            mRules.RuleBroken("Description", true);
            mRules.RuleBroken("Price", true);
            mRules.RuleBroken("Quantity", true);
        }

        /// <summary>
        /// Instantiates mProps and mOldProps as new Props objects.
        /// Instantiates mbdReadable and mdbWriteable as new DB objects.
        /// </summary>
        protected override void SetUp()
        {
            mProps = new ProductProps();
            mOldProps = new ProductProps();

            if (this.mConnectionString == "")
            {
                mdbReadable = new ProductDB();
                mdbWriteable = new ProductDB();
            }

            else
            {
                mdbReadable = new ProductDB(this.mConnectionString);
                mdbWriteable = new ProductDB(this.mConnectionString);
            }
        }
        #endregion

        #region constructors
        public Product() : base()
        {
        }

        public Product(string cnString) : base(cnString)
        {
        }

        public Product(object key) : base(key)
        {
        }

        public Product(IBaseProps props) : base(props)
        {
        }

        public Product(object key, string cnString) : base(key, cnString)
        {
        }

        public Product(IBaseProps props, string cnString) : base(props, cnString)
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
        public int ID
        {
            get
            {
                return ((ProductProps)mProps).ID;
            }
        }

        /// <summary>
        /// Read/Write property. 
        /// </summary>
        public string ProductCode
        {
            get
            {
                return ((ProductProps)mProps).code;
            }

            set
            {
                if (!(value == ((ProductProps)mProps).code))
                {
                    if (value.Length >= 1 && value.Length <= 10)
                    {
                        mRules.RuleBroken("Code", false);
                        ((ProductProps)mProps).code = value;
                        mIsDirty = true;
                    }

                    else
                    {
                        throw new ArgumentOutOfRangeException("Code must be between 1 and 10 characters");
                    }
                }
            }
        }

        /// <summary>
        /// Read/Write property. 
        /// </summary>
        public string Description
        {
            get
            {
                return ((ProductProps)mProps).description;
            }

            set
            {
                if (!(value == ((ProductProps)mProps).description))
                {
                    if (value.Length >= 1 && value.Length <= 50)
                    {
                        mRules.RuleBroken("Description", false);
                        ((ProductProps)mProps).description = value;
                        mIsDirty = true;
                    }

                    else
                    {
                        throw new ArgumentOutOfRangeException("Description must be between 1 and 50 characters");
                    }
                }
            }
        }
        /// <summary>
        /// Read/Write property. 
        /// </summary>
        public decimal Price
        {
            get
            {
                return ((ProductProps)mProps).price;
            }

            set
            {
                if (!(value == ((ProductProps)mProps).price))
                    { 
                    if (value > 0)
                    {
                        mRules.RuleBroken("Price", false);
                        ((ProductProps)mProps).price = value;
                        mIsDirty = true;
                    }

                    else
                    {
                        throw new ArgumentException("Price must be a positive number");
                    }       
                }
            }
        }

        /// <summary>
        /// Read/Write property. 
        /// </summary>
        public int OnHandQuantity
        {
            get
            {
                return ((ProductProps)mProps).quantity;
            }

            set
            {
                if (!(value == ((ProductProps)mProps).quantity))
                {
                    if (value >= 0)
                    {
                        mRules.RuleBroken("Quantity", false);
                        ((ProductProps)mProps).quantity = value;
                        mIsDirty = true;
                    }

                    else
                    {
                        throw new ArgumentException("Quantity must be a positive number");
                    }
                }
            }
        }
        #endregion
    }
}
