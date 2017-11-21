﻿<%@ WebService Language="C#" Class="ServiceSXB" %>

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web.Services;
using nrWebClass;
using Newtonsoft.Json;
using LiLanzModel;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
// [System.Web.Script.Services.ScriptService]
public class ServiceSXB : System.Web.Services.WebService
{

    public ServiceSXB()
    {

        //如果使用设计的组件，请取消注释以下行 
        //InitializeComponent(); 
    }

    /// <summary>
    /// 水洗标信息
    /// </summary>
    /// <param name="data">外部参数</param>
    /// <returns></returns>
    [WebMethod]
    public string orderDetail(string data)
    {
        //货号1|尺码1|尺码2|,货号2|尺码1|尺码2
        //货号1,货号2,....
        //string data = Context.Request.QueryString["data"].ToString();
        string sphhSql = "";
        //构造货号范围表   //
        foreach (string item in data.Split(','))
        {
            if (item.Contains("|"))
            {
                for (int i = 1; i < item.Split('|').Length; i++)
                {
                    sphhSql = sphhSql + " select '" + item.Split('|')[0] + "' as sphh,'cm" + item.Split('|')[i] + "' as cm union ";
                }
            }
            else
            {
                sphhSql = sphhSql + " select '" + item + "' as sphh,'cm24' as cm union ";
            }
        }
        string sql = "select a.sphh,a.cm into #sphh from (" + sphhSql.Substring(0, sphhSql.Length - 6) + ") a ;";
        sql += " select distinct sphh.lydjid as xzid,sphh.sphh into #range  ";
        sql += " from yf_v_rinsing_sphh_all sphh ";
        sql += " inner join (select distinct sphh from #sphh) hh on hh.sphh=sphh.sphh where  sphh.djzt=0 ";
        //构造货号范围表 end //

        //合格证信息           
        sql += " select f.id,f.lydjid,f.dbhg,f.dbtg,f.ddh as '水洗材料',f.fk as '水洗材料下装',f.dbxx as '西服三件套马甲',pm.mc '品名',isnull(bsz.mc,'') '品名上装',isnull(bxz.mc,'') '品名下装',isnull(bmj.mc,'') as '品名西服三件套马甲' ,";
        sql += " gb.dm '版型',yp.yphh '样号',case f.dsqk when '' then '' else f.dsqk+'：' end +f.shqk '洗涤方法',case f.dekz when '' then '' else f.dekz+'：' end +f.desz '洗涤方法上装',case f.jfk when '' then '' else f.jfk+'：' end+f.ghsyj '洗涤方法下装',xt.mc '警告语',g.mc '执行标准',f.jpg '等级',h.mc '安全技术类别',sphh.sphh '货号', m.notice '注意事项',m.store '使用和贮藏',";
        sql += " sx.notice 'sx注意事项',sx.store 'sx使用和贮藏',kusx.notice 'kusx注意事项',kusx.store 'kusx使用和贮藏' ";
        sql += " into #myzb  ";
        sql += " from yf_T_bjdlb f ";
        sql += " inner join #range r on r.xzid=f.id   ";
        sql += " inner join yf_v_rinsing_sphh_all sphh on f.id=sphh.lydjid  and sphh.sphh=r.sphh ";
        sql += " inner join Yf_T_bjdbjzb pm on pm.id=f.tplx";
        sql += " left join Yf_T_bjdbjzb bsz on f.dycs=bsz.id  ";
        sql += " left join Yf_T_bjdbjzb bxz on f.wtlx=bxz.id  ";
        sql += " left join Yf_T_bjdbjzb bmj on f.sftj=bmj.id  ";
        sql += " inner join Yf_T_bjdbjzb g on g.id=f.ddid";
        sql += " inner join yx_T_spdmb sp on sp.sphh=sphh.sphh";
        sql += " inner join yx_v_ypdmb yp on yp.yphh=sp.yphh ";
        sql += " left join  Yf_T_bjdbjzb gb on gb.id=yp.bhks  ";
        sql += " inner join Yf_T_bjdbjzb h on h.lx=905 and f.sylx=h.id and h.tzid=1 ";
        sql += " left join ghs_t_xtdm xt on xt.id=isnull(f.kzx4,0) ";
        sql += " inner join yf_v_rinsingtemplate  m on m.id=f.lydjid  ";
        sql += " left join yf_v_rinsingtemplate sx on sx.id=f.dbhg ";
        sql += " left join yf_v_rinsingtemplate kusx on kusx.id=f.dbtg ";
        sql += "  where   f.lxid=903 and  f.tzid='1' ; ";
        //table0 标签信息,一个货号一条记录
        sql += "  select * from #myzb; ";
        //table1 纤维含量
        sql += " select zb.货号,  ROW_NUMBER() OVER(PARTITION BY zb.货号 order by xw.sytjid) sytjid, ";
        sql += " /*case when isnull(xw.sz,'')='/' or isnull(xw.pdjg,'')='' then xw.sz else xw.pdjg+':'+xw.sz end as mxsz*/xw.pdjg,xw.sz,xw.glz   ";
        sql += " from #myzb zb   inner join yf_T_bjdmxb xw on zb.id=xw.mxid  and xw.lxid=903 ; ";
        //table2图标
        sql += " select a.* from ( ";
        sql += "   SELECT '主模版' lx, zb.货号, b.path,b.mc,b.dm FROM yf_v_rinsingtemplateico a INNER JOIN yf_V_rinsingico b ON a.icodm=b.dm  ";
        sql += "   inner join #myzb zb on zb.lydjid=a.mxid      ";
        sql += "   union all";
        sql += "   SELECT '上装' lx ,zb.货号, b.path,b.mc,b.dm FROM yf_v_rinsingtemplateico a INNER JOIN yf_V_rinsingico b ON a.icodm=b.dm  ";
        sql += "   inner join #myzb zb on zb.dbhg=a.mxid     ";
        sql += "   union all";
        sql += "   SELECT '下装' lx,zb.货号, b.path,b.mc,b.dm FROM yf_v_rinsingtemplateico a INNER JOIN yf_V_rinsingico b ON a.icodm=b.dm  ";
        sql += "   inner join #myzb zb on zb.dbtg=a.mxid      ";
        sql += "  ) a order by a.lx, cast( a.dm as int)   ";
        //table3 各尺寸绒含量
        sql += " SELECT a.货号, hjyl=(mx.hsz+mx.bzsh),gg.hx crlhx,mx.cmdm ";
        sql += " FROM #myzb a ";
        sql += " inner join yx_T_spdmb sp on sp.sphh=a.货号";
        sql += " INNER JOIN dbo.YX_T_Ypdmb yp ON sp.yphh=yp.yphh ";
        sql += " INNER JOIN YF_T_Bom b ON b.yphh=yp.yphh  AND b.cmfj=1 ";
        sql += " inner join cl_v_chdmb_all ch on ch.chdm=b.chdm ";
        sql += " inner join yf_T_bjdlb bj on bj.id=ch.bjid and bj.kzx1 =297";
        sql += " INNER JOIN YF_T_Bomcmmx mx ON b.id=mx.id ";
        sql += " inner JOIN yx_V_sphxggb gg ON 'cm'+mx.cmdm=gg.cmdm AND yp.yphh=gg.yphh";
        //table4 水洗标材料
        sql += " select b.货号,b.lx, a.* from YF_v_SXBCHDM a inner join ( select 货号, 水洗材料 chdm,'上装' lx from #myzb union select 货号, 水洗材料下装 chdm,'下装' lx from #myzb union select 货号, 西服三件套马甲 chdm,'西服三件套马甲' lx from #myzb ) b on a.chdm=b.chdm ;";
        //5号型规格
        sql += " select  a.货号, zh.cmdm,isnull(k.hx,case when lw.id is not  null then  '不打印' else '未维护' end )  as hx, ";
        sql += " isnull(k.hx2,case when lw.id is not  null then  '不打印' else '未维护' end)  as hx2,";
        sql += " hx2isExists= case isnull(k.hx2,'') when '' then 0 else 1 end , ";
        sql += " isnull(k.gg,case when lw.id is not  null then  '不打印' else '未维护' end)  as gg ";
        sql += " from #myzb a";
        sql += " inner join yx_T_spdmb sp on sp.sphh=a.货号";
        sql += " inner join yx_v_ypdmb yp on yp.yphh=sp.yphh ";
        sql += " inner join yx_t_cmzh zh on zh.tml=yp.tml ";
        sql += " inner join (select distinct sphh from #sphh) kz on kz.sphh=a.货号  ";
        sql += " left join yx_V_sphxggb k on k.yphh=yp.yphh and zh.cmdm=k.cmdm";
        sql += " left join yx_V_noneedhxgg lw on lw.id=yp.splbid ";
        //6要显示哪些尺码
        sql += " select * from #sphh;";
        sql += " drop table #myzb; drop table #sphh;drop table #range;";
        DataSet htzinfoDs = null;
        string ConnectionString = "Server=192.168.35.10;Database=TLSOFT;Uid=ABEASD14AD;Pwd=+AuDkDew;";
        using (LiLanzDALForXLM dal = new LiLanzDALForXLM(ConnectionString))
        {
            dal.ExecuteQuery(sql, out htzinfoDs);
        }
        DataTable htzinfo = htzinfoDs.Tables[0].Copy();//'水洗信息
        DataTable hlinfo = htzinfoDs.Tables[1].Copy(); //纤维成份'
        DataTable icoinfo = htzinfoDs.Tables[2].Copy();// '图标'
        DataTable crlinfo = htzinfoDs.Tables[3].Copy();// '各尺寸绒含量
        DataTable chdminfo = htzinfoDs.Tables[4].Copy();// '水洗标材料
        DataTable hxgginfo = htzinfoDs.Tables[5].Copy();// '尺码表
        DataTable showinfo = htzinfoDs.Tables[6].Copy();// '要显示哪些尺码
        List<SphhInfo> sphhInfoList = new List<SphhInfo>();
        foreach (DataRow sphhdr in htzinfo.Rows)
        {
            SphhInfo sphhInfo = new SphhInfo();
            if (string.Compare(sphhdr["洗涤方法"].ToString(), "/") == 0)
            {
                sphhInfo.Xdff = "";
            }
            else
            {
                sphhInfo.Xdff = sphhdr["洗涤方法"].ToString();
            }
            if (string.Compare(sphhdr["洗涤方法上装"].ToString(), "/") == 0)
            {
                sphhInfo.Xdff_sz = "";
            }
            else
            {
                sphhInfo.Xdff_sz = sphhdr["洗涤方法上装"].ToString();
            }
            if (string.Compare(sphhdr["洗涤方法下装"].ToString(), "/") == 0)
            {
                sphhInfo.Xdff_xz = "";
            }
            else
            {
                sphhInfo.Xdff_xz = sphhdr["洗涤方法下装"].ToString();
            }
            //成份
            foreach (DataRow dr in hlinfo.Select("货号='" + sphhdr["货号"].ToString() + "'   "))
            {
                MaterialInfo2 cf = new MaterialInfo2();
                cf.Glz = int.Parse(dr["Glz"].ToString());
                cf.Sytjid = int.Parse(dr["Sytjid"].ToString());
                cf.Value = dr["sz"].ToString();
                cf.Title = dr["Pdjg"].ToString();
                sphhInfo.CfList.Add(cf);
            }
            //图标        
            foreach (DataRow dr in icoinfo.Select("货号='" + sphhdr["货号"].ToString() + "'   "))
            {
                Ico ico = new Ico();
                ico.Path = dr["path"].ToString();
                ico.Mc = dr["mc"].ToString();
                ico.Lx = dr["lx"].ToString();
                sphhInfo.IcoList.Add(ico);
            }
            //水洗标材料
            foreach (DataRow dr in chdminfo.Select("货号='" + sphhdr["货号"].ToString() + "'   "))
            {
                SxChdmDataContent sx = new SxChdmDataContent();
                sx.Lx = dr["lx"].ToString();
                sx.Sm = dr["sm"].ToString();
                sphhInfo.SxChdmList.Add(sx);
            }

            foreach (DataRow cmdr in hxgginfo.Select("货号='" + sphhdr["货号"].ToString() + "'   "))
            {
                SphhCmInfo s = new SphhCmInfo();
                s.Sphh = sphhdr["货号"].ToString();
                s.Cm = cmdr["cmdm"].ToString();
                s.Gg = cmdr["gg"].ToString();

                DataRow[] clrdr = crlinfo.Select("货号='" + sphhdr["货号"].ToString() + "' and 'cm'+cmdm='" + cmdr["cmdm"].ToString() + "'");
                if (clrdr.Length == 1)
                {
                    if (Decimal.Parse(clrdr[0]["hjyl"].ToString()) > 0)
                    {
                        s.Clr = String.Format("{0:####.#}", Math.Round(Decimal.Parse(clrdr[0]["hjyl"].ToString()) * 1000, 1)) + "g";
                        s.Clrgg = clrdr[0]["crlhx"].ToString();
                    }
                    else
                    {
                        s.Clr = s.Clrgg = "";
                    }

                }
                else
                {
                    s.Clr = s.Clrgg = "";
                }
                s.Hx2isExists = int.Parse(cmdr["hx2isExists"].ToString());
                s.Hx = cmdr["hx"].ToString();
                s.Hx2 = cmdr["hx2"].ToString();
                sphhInfo.SphhCmInfo.Add(s);
            }
            sphhInfo.Sphh = sphhdr["货号"].ToString();
            foreach (DataRow dr in showinfo.Select("sphh='" + sphhdr["货号"].ToString() + "'"))
            {
                sphhInfo.Cm.Add(dr["cm"].ToString(), 1);
            }
            //sphhInfo.Cm = showinfo.Select("sphh='" + sphhdr["货号"].ToString() + "'")[0]["cm"].ToString();
            sphhInfo.Pm = sphhdr["品名"].ToString();
            sphhInfo.Pm_sz = sphhdr["品名上装"].ToString();
            sphhInfo.Pm_xz = sphhdr["品名下装"].ToString();
            sphhInfo.Pm_mj3 = sphhdr["品名西服三件套马甲"].ToString();
            sphhInfo.Yphh = sphhdr["样号"].ToString();
            sphhInfo.Bx = sphhdr["版型"].ToString();
            sphhInfo.Aqjb = sphhdr["安全技术类别"].ToString();
            sphhInfo.Jgy = sphhdr["警告语"].ToString();
            sphhInfo.Zysx = sphhdr["注意事项"].ToString();
            sphhInfo.Sycc = sphhdr["使用和贮藏"].ToString();
            sphhInfo.Zysx_sx = sphhdr["sx注意事项"].ToString();
            sphhInfo.Sycc_sx = sphhdr["sx使用和贮藏"].ToString();
            sphhInfo.Zysx_kusx = sphhdr["kusx注意事项"].ToString();
            sphhInfo.Sycc_kusx = sphhdr["kusx使用和贮藏"].ToString();
            sphhInfo.Zxbz = sphhdr["执行标准"].ToString();
            sphhInfoList.Add(sphhInfo);
        }
        return JsonConvert.SerializeObject(sphhInfoList);

      
    }

}