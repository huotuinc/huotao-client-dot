using HotTaoCore.Models;
using HotCoreUtils.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotTaoCore.DAL
{
    public class GoodsDAL
    {
        /// <summary>
        /// 商品列表
        /// </summary>
        /// <returns></returns>
        public List<GoodsModel> getGoodsList()
        {
            string strSql = @"select top 30 id,goodsId,goodsName,goodsMainImgUrl,goodsDetailUrl,goodsType,goodsSupplier,
                goodsSalesAmount,goodsComsRate,goodsCommission,goodsPrice,couponPrice,startTime,endTime,couponUrl,updateTime,createTime,shareLink from goods_list  with(nolock)  order by updateTime desc";


            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(GlobalConfig.getConnectionString(), CommandType.Text, strSql))
            {
                return DbHelperSQL.GetEntityList<GoodsModel>(dr);
            }

        }
        /// <summary>
        /// 分页数据
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<GoodsModel> getGoodsList(int pageIndex, int pageSize)
        {
            string strSql = @"select id,goodsId,goodsName,goodsMainImgUrl,goodsDetailUrl,goodsType,goodsSupplier,
                goodsSalesAmount,goodsComsRate,goodsCommission,goodsPrice,couponPrice,startTime,endTime,couponUrl,updateTime,createTime,shareLink from goods_list  with(nolock) ";

            string querySql = DbHelperSQL.buildPageSql(pageIndex, pageSize, strSql, "id", true);
            using (SqlDataReader dr = DbHelperSQL.ExecuteReader(GlobalConfig.getConnectionString(), CommandType.Text, querySql))
            {
                return DbHelperSQL.GetEntityList<GoodsModel>(dr);
            }
        }

        /// <summary>
        /// 添加商品
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int addGoods(GoodsModel model)
        {
            string strSql = @"
                            if not exists (select * from goods_list where goodsId=@goodsId)
                            begin
                                insert into goods_list(goodsId,goodsName,goodsMainImgUrl,goodsDetailUrl,goodsType,goodsSupplier,goodsSalesAmount,goodsComsRate,goodsPrice,goodsCommission,couponPrice,startTime,endTime,couponUrl,shareLink,updateTime)
                                values(@goodsId,@goodsName,@goodsMainImgUrl,@goodsDetailUrl,@goodsType,@goodsSupplier,@goodsSalesAmount,@goodsComsRate,@goodsPrice,@goodsCommission,@couponPrice,@startTime,@endTime,@couponUrl,@shareLink,@updateTime)
                            end
                            else
                            begin
                                update goods_list set 
                                goodsName=@goodsName,
                                goodsMainImgUrl=@goodsMainImgUrl,
                                goodsDetailUrl=@goodsDetailUrl,
                                goodsType=@goodsType,
                                goodsSupplier=@goodsSupplier,
                                goodsSalesAmount=@goodsSalesAmount,
                                goodsComsRate=@goodsComsRate,
                                goodsPrice=@goodsPrice,
                                goodsCommission=@goodsCommission,
                                couponPrice=@couponPrice,
                                startTime=@startTime,
                                endTime=@endTime,
                                couponUrl=@couponUrl,
                                updateTime=@updateTime,
                                shareLink=@shareLink
                                where goodsId=@goodsId
                            end";
            var param = new[]
            {
                new SqlParameter("@goodsId",model.goodsId),
                new SqlParameter("@goodsName",model.goodsName),
                new SqlParameter("@goodsMainImgUrl",model.goodsMainImgUrl),
                new SqlParameter("@goodsDetailUrl",model.goodsDetailUrl),
                new SqlParameter("@goodsType",model.goodsType),
                new SqlParameter("@goodsSupplier",model.goodsSupplier),
                new SqlParameter("@goodsSalesAmount",model.goodsSalesAmount),
                new SqlParameter("@goodsComsRate",model.goodsComsRate),
                new SqlParameter("@goodsPrice",model.goodsPrice),
                new SqlParameter("@goodsCommission",model.goodsCommission),
                new SqlParameter("@couponPrice",model.couponPrice),
                new SqlParameter("@startTime",model.startTime),
                new SqlParameter("@endTime",model.endTime),
                new SqlParameter("@couponUrl",model.couponUrl),
                new SqlParameter("@shareLink",model.shareLink),
                new SqlParameter("@updateTime",DateTime.Now)
            };
            return DbHelperSQL.ExecuteNonQuery(GlobalConfig.getConnectionString(), CommandType.Text, strSql, param);
        }

        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteGoods(int id)
        {
            string strSql = "delete from goods_list where id=@id";
            string strSql2 = "update task_goods_pid_log set statusCode=1 where goodsid=@id";
            var param = new[]
            {
                new SqlParameter("@goodsId",id)
            };
            DbHelperSQL.ExecuteNonQuery(GlobalConfig.getConnectionString(), CommandType.Text, strSql, param);
            DbHelperSQL.ExecuteNonQuery(GlobalConfig.getConnectionString(), CommandType.Text, strSql2, param);
            return true;
        }

        public bool DeleteGoods(List<int> ids)
        {
            string strSql = string.Format("delete from goods_list where id in ({0})", string.Join(",", ids));
            string strSql2 = string.Format("update task_goods_pid_log set statusCode=1 where goodsid in ({0})", string.Join(",", ids));
            DbHelperSQL.ExecuteNonQuery(GlobalConfig.getConnectionString(), CommandType.Text, strSql);
            DbHelperSQL.ExecuteNonQuery(GlobalConfig.getConnectionString(), CommandType.Text, strSql2);
            return true;

        }

    }
}
