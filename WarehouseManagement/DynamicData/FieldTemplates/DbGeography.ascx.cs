using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Web.DynamicData;


namespace WarehouseManagement.DynamicData.FieldTemplates
{
    public partial class DbGeography : System.Web.DynamicData.FieldTemplateUserControl
    {
        public System.Data.Entity.Spatial.DbGeography geo;

        protected override void OnDataBinding(EventArgs e)
        {
            base.OnDataBinding(e);
            System.Data.Entity.Spatial.DbGeography geo = (System.Data.Entity.Spatial.DbGeography)(FieldValue);
            location.Text = geo.Latitude + "," + geo.Longitude;    
        }       

        public override Control DataControl
        {
            get
            {
                return location;
            }
        }
    }
}
