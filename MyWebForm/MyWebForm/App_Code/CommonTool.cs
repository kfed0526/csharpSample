using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyWebForm.Models.DTO;

namespace MyWebForm.App_Code
{
    public class CommonTool
    {
        public void ucPageVisible(PageSite.UsPager ucPage, int cCount)
        {
            if (cCount > 0)
            {
                ucPage.Total = int.Parse(cCount.ToString());
                ucPage.IsStartBind = true;
                if (cCount <= 10)
                {
                    ucPage.Visible = false;
                }
                else
                {
                    ucPage.Visible = true;
                }
            }
            else
            {
                ucPage.Visible = false;
            }
        }

        #region//ddlDataBind(List<DropDownListDTO> DDLDtoList, DropDownList returnDDL);傳入DropDownListDTO，回傳DropDownList
        /// <summary>
        /// 傳入List<DropDownListDTO>, 下拉式選單物件DropDownList, 預設文字defaultText, 預設值defaultValue
        /// 無回傳
        /// </summary>
        /// <param name="DDLDtoList"></param>
        /// <param name="returnDDL"></param>
        /// <param name="defaultText"></param>
        /// <param name="defaultValue"></param>
        public void ddlDataBind(List<DropDownListDTO> DDLDtoList, DropDownList returnDDL, string defaultText, string defaultValue)
        {
            int ddlCount = returnDDL.Items.Count;
            for (int i = 0; i < ddlCount; i++)
            {
                returnDDL.Items.RemoveAt(0);
            }

            if (defaultText != "")
            {
                returnDDL.Items.Add(new ListItem(defaultText, defaultValue));
            }

            foreach (DropDownListDTO DDLDto in DDLDtoList)
            {
                if (DDLDto.DDL_TEXT != null && DDLDto.DDL_VALUE != null)
                {
                    returnDDL.Items.Add(new ListItem(DDLDto.DDL_TEXT.ToString(), DDLDto.DDL_VALUE.ToString()));
                }
            }
        }
        #endregion
        #region//DisplayMode();Panel顯示
        public void DisplayMode(int[] pIndex, List<Panel> PanelList)
        {
            foreach (Panel panel in PanelList)
            {
                panel.Visible = false;
            }
            foreach (int i in pIndex)
            {
                PanelList[i].Visible = true;
            }
        }
        #endregion
    }
}