using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyWebForm.PageSite
{
    public partial class UsPager : System.Web.UI.UserControl
    {
        #region 屬性
        //private int intTotal;
        public int Total { get { return int.Parse(HiddenField_Total.Value); } set { HiddenField_Total.Value = value.ToString(); } }

        //private int intSize;
        public int Size { get { return int.Parse(HiddenField_Size.Value); } set { HiddenField_Size.Value = value.ToString(); } }

        //private int intIndex;
        public int Index { get { return int.Parse(HiddenField_Index.Value); } set { HiddenField_Index.Value = value.ToString(); } }

        private int maxPageIndex;

        public int MaxPageIndex
        {
            get
            {
                if (Size > 0)
                {
                    int intSize = int.Parse((Total / Size).ToString());
                    if ((Total % Size) == 0)
                        return intSize;
                    else
                        return intSize + 1;
                }
                else return 1;
            }
        }

        private string strCommand;
        public string Command { get { return strCommand; } set { strCommand = value; } }

        public bool IsStartBind { set { if (value == true) BindGrid(); } }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            BindGrid();
        }

        void BindGrid()
        {
            try
            {
                this.pl.Controls.Clear();
                ////////get the n number of record///////////
                int n = (Total % Size) > 0 ? (Total / Size) + 1 : Total / Size;

                //generate dynamic paging 
                int start;
                if (Index <= 5) start = 1;
                else start = Index - 4;
                for (int i = start; i < start + 7; i++)
                {
                    if (i > n) continue;
                    //create dynamic HyperLinks 
                    HyperLink lnk = new HyperLink();

                    lnk.ID = "lnk_" + i.ToString();
                    if (i == Index)//current page
                    {
                        lnk.CssClass = "page-numbers current";
                        lnk.Text = i.ToString();
                        Label_Page.Text = i.ToString();
                    }
                    else
                    {
                        lnk.Text = i.ToString();
                        lnk.CssClass = "page-numbers";
                    }

                    //add links to page
                    lnk.Style["cursor"] = "pointer";
                    lnk.Attributes.Add("onclick", "var lnk = document.getElementById('" + LinkButton_Go.ClientID + "');document.getElementById('" + HiddenField_Index.ClientID + "').value='" + lnk.Text + "';lnk.click();");
                    this.pl.Controls.Add(lnk);
                }
                //------------------------------------------------------------------
                //set up the ist page and the last page
                if (n > 7)
                {
                    if (Index < 6)
                    {
                        lblLast.Visible = true;
                        lblIst.Visible = false;
                        lblLast.Text = "..." + n.ToString();
                    }

                    if (Index >= 6)
                    {
                        lblLast.Visible = true;
                        lblIst.Visible = true;
                        lblLast.Text = "..." + n.ToString();
                    }

                    if (Index >= ((int)n) - 2)
                    {
                        lblLast.Visible = false;
                        lblIst.Visible = true;
                    }
                }
                else
                {
                    lblLast.Visible = false;
                    lblIst.Visible = false;
                }
            }
            catch (Exception ee)
            {
                //catch the exception
            }
        }

        protected void lnk_Click(object sender, EventArgs e)
        {
            strCommand = HiddenField_Index.Value;// lbtn.Text;
            SetCommand(strCommand);
            if (PageIndexChanged != null)
                PageIndexChanged(sender, e);
        }

        protected void lblpre_Click(object sender, EventArgs e)
        {
            strCommand = "PrePage";
            SetCommand(strCommand);
            if (PageIndexChanged != null)
                PageIndexChanged(sender, e);
        }

        protected void lblnext_Click(object sender, EventArgs e)
        {
            strCommand = "NextPage";
            SetCommand(strCommand);
            if (PageIndexChanged != null)
                PageIndexChanged(sender, e);
        }

        protected void lblIst_Click(object sender, EventArgs e)
        {
            strCommand = "FirstPage";
            SetCommand(strCommand);
            if (PageIndexChanged != null)
                PageIndexChanged(sender, e);
        }

        protected void lblLast_Click(object sender, EventArgs e)
        {
            strCommand = "LastPage";
            SetCommand(strCommand);
            if (PageIndexChanged != null)
                PageIndexChanged(sender, e);
        }

        private void SetCommand(string strCommand)
        {
            switch (strCommand)
            {
                case "PrePage":
                    Index = (Index != 1 ? Index - 1 : 1);
                    break;
                case "NextPage":
                    Index = (Index != MaxPageIndex ? Index + 1 : MaxPageIndex);
                    break;
                case "FirstPage":
                    Index = 1;
                    HiddenField_Index.Value = "1";
                    break;
                case "LastPage":
                    Index = MaxPageIndex;
                    HiddenField_Index.Value = MaxPageIndex.ToString();
                    break;
                default:
                    Index = int.Parse(strCommand);
                    break;
            }
        }

        #region 處理分頁事件觸發
        /// <summary>
        /// 加入委派方便檔案異動時事件處理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void PageIndexChangedHandle(object sender, EventArgs e);
        public event PageIndexChangedHandle PageIndexChanged;
        #endregion
    }
}