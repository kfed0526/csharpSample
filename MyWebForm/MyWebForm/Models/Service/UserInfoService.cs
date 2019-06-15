using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyWebForm.Models.SQL;

namespace MyWebForm.Models.Service
{
    public class UserInfoService
    {
        private MyFormEntities myFormEntities = new MyFormEntities();
        private SQLCommand sqlCmd = new SQLCommand();
        #region//getUserInfoList(int pageIndex, int pageNumber, string ascendingColumn);
        /// <summary>
        /// 依條件搜尋使用者資訊並排序
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageNumber"></param>
        /// <param name="ascendingColumn"></param>
        /// <returns></returns>
        public List<USER_INFO> getUserInfoList(int pageIndex, int pageSize, string ascendingColumn)
        {
            ascendingColumn = "US.USER_ID ";
            string ascending = " ASC ";
            if (pageIndex < 0) { pageIndex = 0; }
            int startPageIndex = pageSize * (pageIndex - 1);
            int endPageIndex = startPageIndex + pageSize;
            List<USER_INFO> userInfoList = myFormEntities.Database.SqlQuery<USER_INFO>(
                sqlCmd.getUserInfoList(ascendingColumn, ascending),
                new object[] {startPageIndex, endPageIndex }
            ).ToList<USER_INFO>();
            return userInfoList;
        }
        #endregion        
        public int getUserInfoListCount()
        {
            List<USER_INFO> userInfoList = myFormEntities.Database.SqlQuery<USER_INFO>(
                sqlCmd.getUserInfoListCount()
            ).ToList<USER_INFO>();
            return userInfoList.Count;
        }
        public List<USER_INFO> getUserInfoList()
        {
            List<USER_INFO> userInfoList = myFormEntities.USER_INFO.ToList<USER_INFO>();
            return userInfoList;
        }
        public USER_INFO getUserInfoByUserId(string userId)
        {
            USER_INFO userInfo = myFormEntities.USER_INFO.Where(c => c.USER_ID == userId).FirstOrDefault();
            return userInfo;
        }
        public long Insert(USER_INFO userInfo)
        {
            USER_INFO afterUserInfo = new USER_INFO();
            afterUserInfo = myFormEntities.USER_INFO.Add(userInfo);
            myFormEntities.SaveChanges();
            return afterUserInfo.USER_SEQNO;
        }
        public long Update(USER_INFO userInfo)
        {
            try
            {
                USER_INFO updateUserInfo = myFormEntities.USER_INFO.Where(c => c.USER_ID == userInfo.USER_ID).FirstOrDefault();
                updateUserInfo.USER_ADDRESS = userInfo.USER_ADDRESS;
                updateUserInfo.USER_BIRTHDAY = userInfo.USER_BIRTHDAY;
                updateUserInfo.USER_NAME = userInfo.USER_NAME;
                myFormEntities.SaveChanges();
                return updateUserInfo.USER_SEQNO;
            }catch(Exception ex){
                return 0L;
            }
        }
        public bool Delete(string userId)
        {
            try
            {
                USER_INFO deleteUserInfo = myFormEntities.USER_INFO.Where(c => c.USER_ID == userId).FirstOrDefault();
                myFormEntities.USER_INFO.Remove(deleteUserInfo);
                myFormEntities.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }
    }
}